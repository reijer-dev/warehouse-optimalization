using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WarehouseOptimization.Models
{
		public class UndirectedGraph
		{
				public UndirectedGraph FinalGraph { get; set; }
				public Dictionary<int, Point> Points { get; } = new();
				public Dictionary<Point, int> PointNumbers { get; } = new();
				public Dictionary<int, List<int>> AdjacencyList { get; set; } = new();
				public Dictionary<(int, int), double> Weights { get; set; } = new();
				public Dictionary<(int, int), (double, List<int>)> NetWeights { get; set; } = new();
				public List<Point> FoundPath { get; set; } = new();

				public void AddPoint(Point p)
				{
						p.Number = Points.Count;
						Points.Add(p.Number, p);
						PointNumbers.Add(p, p.Number);
						AdjacencyList.Add(p.Number, new());
				}

				public void AddEdge(Point v, Point w)
				{
						if (!Points.Values.Contains(v) || !Points.Values.Contains(w))
								throw new Exception("Invalid point");

						var dx = Math.Abs(v.X - w.X);
						var dy = Math.Abs(v.Y - w.Y);
						var weight = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

						if (!AdjacencyList[v.Number].Contains(w.Number))
								AdjacencyList[v.Number].Add(w.Number);
						if (!AdjacencyList[w.Number].Contains(v.Number))
								AdjacencyList[w.Number].Add(v.Number);
						Weights.Add((v.Number, w.Number), weight);
						Weights.Add((w.Number, v.Number), weight);
				}

				public double GetDistance(int a, int b)
				{
						var v = Points[a];
						var w = Points[b];
						return Math.Sqrt(Math.Pow(Math.Abs(v.X - w.X), 2) + Math.Pow(Math.Abs(v.Y - w.Y), 2));
				}

				public List<int> GetConnectedPoints(int v) => AdjacencyList[v];

				public void CalculateNetWeights()
				{
						foreach (var point1 in Points.Keys)
						{
								foreach (var point2 in Points.Keys)
								{
										if (point1 == 0 && point2 == 49 || point1 == 49 && point2 == 0)
										{

										}
										if (point1 == point2)
												continue;
										if (NetWeights.ContainsKey((point1, point2)))
												continue;
										var (weight, path) = GetNetWeigth(point1, point2);

										NetWeights.Add((point1, point2), (weight, path));
										var path2 = new int[path.Count];
										path.CopyTo(path2);
										NetWeights.Add((point2, point1), (weight, path2.Reverse().ToList()));
								}
						}
				}
				//for x = 0;     x < i - 1; x++
				//for x = k - 1; x >= k-i; x--   0 45 46 47 48 49
				//for x = k;     x <             0 45 47 46 48 49
				//                               0-45 45-47 47-46 46-48
				public double GetSwappedPathWeight(List<int> path, int i, int k)
				{
						var temp = new List<int>();
						double weight = 0;
						var prev = path[0];
						for (var x = 0; x < i - 1; x++)
						{
								temp.Add(prev);
								weight += NetWeights[(prev, path[x + 1])].Item1;
								prev = path[x + 1];
						}
						for(var x = k; x >= i; x--)
						{
								temp.Add(prev);
								weight += NetWeights[(prev, path[x])].Item1;
								prev = path[x];
						}
						for (var x = k + 1; x < path.Count; x++)
						{
								temp.Add(prev);
								weight += NetWeights[(prev, path[x])].Item1;
								prev = path[x];
						}
						temp.Add(prev);
						return weight;
				}

				public double GetPathWeight(List<int> path)
				{
						double weight = 0;
						for (var i = 0; i < path.Count - 1; i++)
						{
								if (path[i] != path[i + 1])
								{
										if (Weights.ContainsKey((path[i], path[i + 1])))
												weight += Weights[(path[i], path[i + 1])];
										else
												weight += NetWeights[(path[i], path[i + 1])].Item1;
								}
						}
						return weight;
				}

				public List<int> GetFullPath(List<int> path)
				{
						var fullPath = new List<int>() { path.First() };
						for (var i = 0; i < path.Count - 1; i++)
						{
								fullPath.AddRange(NetWeights[(path[i], path[i + 1])].Item2.Skip(1));
						}
						for (var x = fullPath.Count - 1; x > 0; x--)
						{
								if (fullPath[x] == fullPath[x - 1])
										fullPath.RemoveAt(x);
						}
						return fullPath;
				}

				public (List<int>, Dictionary<long, double>) GetOptimalPath(int start, int end, int timeLimit)
				{
						var answer = new List<int>();
						var pointsToVisit = Points.Where(x => x.Value.NeedsVisit).Select(x => x.Key).ToList();
						var existingRoute = new List<int>() { start };
						existingRoute.AddRange(pointsToVisit);
						existingRoute.Add(end);

						//The second way
						//existingRoute = GetFullPath(existingRoute);
						var bestDistance = GetPathWeight(existingRoute);
						var counter = 0;
						var improvements = new Dictionary<long, double>()
						{
								{ 0, bestDistance }
						};
						long lastImprovementAt = 0;
						var stopWatch = new Stopwatch();
						stopWatch.Start();
						var betterSolutionFound = true;
						while (betterSolutionFound && stopWatch.ElapsedMilliseconds <= timeLimit * 1000)
						{
								betterSolutionFound = false;
								for (var i = 2; i <= existingRoute.Count - 1; i++)
								{
										if (betterSolutionFound)
												break;
										for (var k = i + 1; k <= existingRoute.Count - 1; k++)
										{
												var newDistance = GetSwappedPathWeight(existingRoute, i, k);
												if (newDistance < bestDistance)
												{
														betterSolutionFound = true;
														if (improvements.ContainsKey(stopWatch.ElapsedMilliseconds))
																improvements.Remove(stopWatch.ElapsedMilliseconds);
														improvements.Add(stopWatch.ElapsedMilliseconds, newDistance);
														lastImprovementAt = stopWatch.ElapsedMilliseconds;
														existingRoute = TwoOptSwap(existingRoute, i, k).ToList();
														bestDistance = newDistance;
														break;
												}
										}
								}
						}
						return (GetFullPath(existingRoute), improvements);
				}
				//2 3 4 5 6 7 8 9
				//i = 3, k = 5
				//4 5 6 7 8
				//4 5 7 6 8
				//for x = 0;     x < i - 1; x++
				//for x = k - 1; x >= k-i; x--
				//for x = k;     x < 
				public IEnumerable<int> TwoOptSwap(List<int> path, int i, int k)
				{
						double weight = 0;
						for (var x = 0; x < i; x++)
								yield return path[x];
						for (var x = k; x >= i; x--)
								yield return path[x];
						for (var x = k + 1; x < path.Count; x++)
								yield return path[x];
				}

				public (double, List<int>) GetNetWeigth(int v, int w)
				{
						var path = GetShortestPath(v, w);

						return (GetPathWeight(path), path);
				}

				public List<int> GetShortestPath(int start, int goal)
				{
						Func<int, double> h = x => GetDistance(x, goal);
						var openSet = new List<int>() { start };
						var cameFrom = new Dictionary<int, int>();

						var gScore = new Dictionary<int, double>();
						foreach (var point in Points.Keys)
						{
								gScore.Add(point, point == start ? 0 : double.MaxValue);
						}

						var fScore = new Dictionary<int, double>();
						fScore.Add(start, h(start));

						var counter = 0;

						while (openSet.Any() && counter++ <= 1000)
						{
								var current = openSet.First();
								if (current == goal)
										return ReconstructPath(cameFrom, current);

								openSet.Remove(current);
								foreach (var neighbor in GetConnectedPoints(current))
								{
										// tentative_gScore is the distance from start to the neighbor through current
										var tentativeGScore = gScore[current] + Weights[(current, neighbor)];
										if (tentativeGScore < gScore[neighbor])
										{
												// This path to neighbor is better than any previous one. Record it!
												cameFrom[neighbor] = current;
												gScore[neighbor] = tentativeGScore;
												fScore[neighbor] = gScore[neighbor] + h(neighbor);
												if (!openSet.Contains(neighbor))
														openSet.Add(neighbor);
										}
								}
						}

						return new List<int>();
				}

				public List<int> ReconstructPath(Dictionary<int, int> cameFrom, int current)
				{
						var totalPath = new List<int>() { current };
						while (cameFrom.ContainsKey(current))
						{
								current = cameFrom[current];
								totalPath.Insert(0, current);
						}
						return totalPath;
				}
		}
}
