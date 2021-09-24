using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseOptimization.Infrastructure;

namespace WarehouseOptimization.Models
{
		public class ScaffoldCorner
		{
				public ScaffoldCorner(Point p)
				{
						p.NeedsVisit = false;
						Point = p;
				}
				public ScaffoldCorner() { }
				public int Id { get; set; } = Counter.NewScaffoldCornerId;
				public Point Point { get; set; }
		}
}
