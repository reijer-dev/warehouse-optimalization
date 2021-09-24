using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseOptimization.Infrastructure;

namespace WarehouseOptimization.Models
{
		public class Location
		{
				public int ScaffoldId { get; set; }
				public int ScaffoldSideId { get; set; }
				public string Label { get; set; }
				public int TopRow { get; set; }
				public int BottomRow { get; set; }
				public int LeftColumn { get; set; }
				public int RightColumn { get; set; }
		}
}
