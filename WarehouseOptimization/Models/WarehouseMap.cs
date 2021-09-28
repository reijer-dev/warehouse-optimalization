using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WarehouseOptimization.Models
{
		public class WarehouseMap
		{
				public int Id { get; set; }
				public int Width { get; set; }
				public int Height { get; set; }
				public List<Scaffold> Scaffolds { get; set; }
				public UndirectedGraph Graph { get; set; }
				public static Random Random = new Random();

				public IEnumerable<Location> PickSomeLocations(int l)
				{
						for (var q = 0; q < l; q++)
						{
								var scaffold = Scaffolds.GetRandom();
								var side = scaffold.Sides.GetRandom();
								var row = Random.Next(1, side.Rows - 1);
								var column = Random.Next(5, side.Columns - 1);
								var location = new Location()
								{
										Label = $"Loc {q}]",
										TopRow = row,
										BottomRow = row,
										LeftColumn = column,
										RightColumn = column,
										ScaffoldSideId = side.Id,
										ScaffoldId = scaffold.Id
								};
								
								side.Locations.Add(location);
								yield return location;
						}
				}

				public void BuildGraph(int l)
				{
						Graph = new UndirectedGraph();
						Graph.AddPoint(new Point(0, 0) { NeedsVisit = false });

						var allScaffoldCorners = Scaffolds.SelectMany(x => x.Corners.Select(x => x.Point)).ToList();
						foreach (var corner in allScaffoldCorners)
						{
								Graph.AddPoint(corner);
						}
						var filePath = $@"picklocations-{l}.json";
						var pickLocations = PickSomeLocations(l).ToList();
						if (System.IO.File.Exists(filePath))
						{
								pickLocations = JsonSerializer.Deserialize<List<Location>>(System.IO.File.ReadAllText(filePath));
						}
						else
						{
								System.IO.File.WriteAllText(filePath, JsonSerializer.Serialize(pickLocations));
						}
						foreach (var location in pickLocations)
						{
								var scaffold = Scaffolds.FirstOrDefault(x => x.Id == location.ScaffoldId);
								var point = scaffold.GetLocationPoint(location);
								point.NeedsVisit = true;
								Graph.AddPoint(point);
						}

						var scaffoldLines = new List<Line>();
						foreach (var scaffold in Scaffolds)
						{
								var corners = scaffold.Corners;

								//Draw blocking lines from each corner to each other, to ensure no pass through internally
								foreach (var me in corners)
								{
										foreach (var other in corners)
										{
												if (other == me)
														continue;
												//TODO remove duplicates
												scaffoldLines.Add(new Line(me.Point, other.Point));
										}
								}
						}

						foreach (var me in Graph.Points.Values)
						{
								foreach (var other in Graph.Points.Values)
								{
										//I can't see myself
										if (other == me)
												continue;

										//Check for already seen connection
										if (Graph.GetConnectedPoints(me.Number).Contains(other.Number))
												continue;

										//I try to see him
										var directLine = new Line(me, other);
										var exists = true;
										foreach (var line in scaffoldLines)
										{
												if (LineIntersectsLine(directLine.Left, directLine.Right, line.Left, line.Right))
												{
														exists = false;
														break;
												}
										}
										if (exists)
												Graph.AddEdge(me, other);
								}
						}
				}

				private bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
				{
					Graph.Complexity++;
						float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y);
						float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X);

						if (d == 0)
						{
								return false;
						}

						float r = q / d;

						q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y);
						float s = q / d;
						if (r <= 0 || r >= 1 || s <= 0 || s >= 1)
						{
								return false;
						}

						return true;
				}
		}
		public class Line
		{
				public Line(Point left, Point right)
				{
						Left = left;
						Right = right;
				}

				public Point Left { get; set; }
				public Point Right { get; set; }
		}
}
