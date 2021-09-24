using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseOptimization.Infrastructure;

namespace WarehouseOptimization.Models
{
		public class Scaffold
		{
				public int Id { get; set; } = Counter.NewScaffoldId;
				public List<ScaffoldSide> Sides { get; set; } = new();
				public List<ScaffoldCorner> Corners { get; set; } = new();

				public Point GetLocationPoint(Location location)
				{
						var side = Sides.FirstOrDefault(x => x.Id == location.ScaffoldSideId);
						var leftCorner = Corners.FirstOrDefault(x => x.Id == side.LeftCornerId);
						var rightCorner = Corners.FirstOrDefault(x => x.Id == side.RightCornerId);
						//TODO middle of left column
						var dx = (int)((rightCorner.Point.X - leftCorner.Point.X) * (location.LeftColumn / (double)side.Columns));
						var dy = (int)((rightCorner.Point.Y - leftCorner.Point.Y) * (location.LeftColumn / (double)side.Columns));
						return new Point(leftCorner.Point.X + dx, leftCorner.Point.Y + dy);
				}
		}

}