using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseOptimization.Models
{
		public class Point
		{
				public Point() { }
				public Point(int x, int y)
				{
						X = x;
						Y = y;
				}
				public int X { get; set; }
				public int Y { get; set; }
				public int Number { get; set; }
				public bool NeedsVisit { get; set; }
				public Point Predecessor { get; set; }

				public Point Clone()
				{
						return new Point()
						{
								X = X,
								Y = Y,
								Number = Number,
								NeedsVisit = NeedsVisit,
								Predecessor = Predecessor
						};
				}

				public bool Is(Point v)
				{
						return v.X == X && v.Y == Y;
				}
		}
}
