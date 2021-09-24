using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseOptimization.Infrastructure
{
		public static class Counter
		{
				private static int _scaffoldId;
				public static int NewScaffoldId => _scaffoldId++;

				private static int _scaffoldSideId;
				public static int NewScaffoldSideId => _scaffoldSideId++;

				private static int _scaffoldCornerId;
				public static int NewScaffoldCornerId => _scaffoldCornerId++;

				private static int _locationId;
				public static int NewLocationId => _locationId++;
		}
}
