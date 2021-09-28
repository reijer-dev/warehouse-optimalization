using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseOptimization.Infrastructure;

namespace WarehouseOptimization.Models
{
		public static class TestData
		{
				public static T GetRandom<T>(this List<T> list) => list[WarehouseMap.Random.Next(0, list.Count)];

				private static int ColumnWidth { get; set; }
				public static WarehouseMap GetTestMap()
				{
						var map = new WarehouseMap()
						{
								Id = 1,
								Width = 5000,
								Height = 5000
						};
						map.Scaffolds = new();
						;
						for(var i=0; i<20; i++)
						{
								var minX = i * 70 + WarehouseMap.Random.Next(0, 30);
								var maxX = minX + 30;

								var minY = 50 + WarehouseMap.Random.Next(0, 60);
								var maxY = 600 + WarehouseMap.Random.Next(0, 60);
							map.Scaffolds.Add(CreateScaffold(map, new Point(minX, minY), new Point(maxX, minY), new Point(maxX, maxY), new Point(minX, maxY)));
						}
						map.Scaffolds.Add(CreateScaffold(map, new Point(300, 800), new Point(300,700), new Point(800,700), new Point(800,800)));
						return map;
				}

				private static Scaffold CreateScaffold(WarehouseMap map, Point point1, Point point2, Point point3, Point point4)
				{
						var scaffold = new Scaffold();
						scaffold.Corners.Add(new ScaffoldCorner(point1));
						scaffold.Corners.Add(new ScaffoldCorner(point2));
						scaffold.Corners.Add(new ScaffoldCorner(point3));
						scaffold.Corners.Add(new ScaffoldCorner(point4));
						var side1 = new ScaffoldSide()
						{
								Rows = 5,
								Columns = 75,
								Height = 500,
								LeftCornerId = scaffold.Corners[2].Id,
								RightCornerId = scaffold.Corners[1].Id
						};
						var side2 = new ScaffoldSide()
						{
								Rows = 5,
								Columns = 75,
								Height = 500,
								LeftCornerId = scaffold.Corners[0].Id,
								RightCornerId = scaffold.Corners[3].Id
						};

						scaffold.Sides.Add(side1);
						scaffold.Sides.Add(side2);
						return scaffold;
				}
		}
}
