using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseOptimization.Infrastructure;

namespace WarehouseOptimization.Models
{
		public class ScaffoldSide
		{
				public int Id { get; set; } = Counter.NewScaffoldSideId;
				public int LeftCornerId { get; set; }
				public int RightCornerId { get; set; }
				public int Rows { get; set; }
				public int Columns { get; set; }
				public int Height { get; set; }
				public List<Location> Locations { get; set; } = new();
		}
}
