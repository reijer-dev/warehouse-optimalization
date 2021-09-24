using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseOptimization.Models;

namespace WarehouseOptimization.Controllers
{
		public class HomeController : Controller
		{
				private readonly ILogger<HomeController> _logger;

				public HomeController(ILogger<HomeController> logger)
				{
						_logger = logger;
				}

				public IActionResult Index(int l = 50, int s = 3)
				{
						var filePath = $@"C:\Users\reije\OneDrive\Documenten\Development\warehousemap.json";
						var map = new WarehouseMap();
						var sw = new Stopwatch();
						sw.Start();
						if (System.IO.File.Exists(filePath))
						{
								map = JsonSerializer.Deserialize<WarehouseMap>(System.IO.File.ReadAllText(filePath));
						}
						else
						{
								map = TestData.GetTestMap();
								System.IO.File.WriteAllText(filePath, JsonSerializer.Serialize(map));
						}
						map.BuildGraph(l);
						map.Graph.CalculateNetWeights();
						var (optimal, improvements) = map.Graph.GetOptimalPath(0, 0, s);
						map.Graph.FoundPath = optimal
								.Select(x => map.Graph.Points[x]).ToList();
						sw.Stop();
						ViewBag.Time = sw.ElapsedMilliseconds;
						ViewBag.Improvements = improvements;
						ViewBag.Weight = map.Graph.GetPathWeight(optimal);
						return View(map);
				}

				public IActionResult Privacy()
				{
						return View();
				}

				[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
				public IActionResult Error()
				{
						return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
				}
		}
}
