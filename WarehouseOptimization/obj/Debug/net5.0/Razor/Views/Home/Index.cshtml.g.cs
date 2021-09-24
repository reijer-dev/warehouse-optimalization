#pragma checksum "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9a59deba10cff9365db33156d14acf831d26a45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\_ViewImports.cshtml"
using WarehouseOptimization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\_ViewImports.cshtml"
using WarehouseOptimization.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a59deba10cff9365db33156d14acf831d26a45", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36a18d038ca51c3aa984cd8d3f1d6bb682fd6c5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WarehouseMap>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
          
	var random = new Random();
	var improvements = ViewBag.Improvements as Dictionary<long, double>;
		

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<h1>");
#nullable restore
#line 7 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
       Write(ViewBag.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ms ");
#nullable restore
#line 7 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                        Write(ViewBag.Weight);

#line default
#line hidden
#nullable disable
            WriteLiteral(" cm lopen</h1>\r\n\t\t<canvas id=\"myChart\"></canvas><br />\r\n<canvas id=\"warehousemap\"></canvas><br />\r\n\r\n\r\n<script>\r\n(async function() {\r\n\tconst config = {\r\n  type: \'line\',\r\n  data: data,\r\n  options: {}\r\n};\r\n\r\nconst labels = [\r\n  ");
#nullable restore
#line 21 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
Write(Html.Raw(string.Join(",",improvements.Select(x => $"'{x.Key}'"))));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n];\r\nconst data = {\r\n  labels: labels,\r\n  datasets: [{\r\n    label: \'My First dataset\',\r\n    backgroundColor: \'rgb(255, 99, 132)\',\r\n    borderColor: \'rgb(255, 99, 132)\',\r\n    data: [");
#nullable restore
#line 29 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
      Write(Html.Raw(string.Join(",",improvements.Select(x => $"{x.Value}"))));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"],
  }]
};
var myChart = new Chart(
    document.getElementById('myChart'),
    config
  );
  var canvas = document.getElementById('warehousemap');
  var scale = 0.7;
  canvas.width = 1000;
  canvas.height = 900;
  var ctx = canvas.getContext('2d');
  ctx.lineWidth = 3;

	//Draw Scaffolds
			ctx.fillStyle = ""#ddd"";
");
#nullable restore
#line 45 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
     foreach(var scaffold in Model.Scaffolds)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
            WriteLiteral("ctx.beginPath();\r\n");
#nullable restore
#line 48 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
		var firstCorner = scaffold.Corners.First();

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t");
            WriteLiteral("ctx.moveTo(");
#nullable restore
#line 49 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                 Write(firstCorner.Point.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 49 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                               Write(firstCorner.Point.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale);\r\n");
#nullable restore
#line 50 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
		foreach(var corner in scaffold.Corners.Skip(1))
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t");
            WriteLiteral("ctx.lineTo(");
#nullable restore
#line 52 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                     Write(corner.Point.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 52 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                              Write(corner.Point.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale);\r\n");
#nullable restore
#line 53 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t");
            WriteLiteral("ctx.lineTo(");
#nullable restore
#line 54 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                 Write(firstCorner.Point.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 54 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                               Write(firstCorner.Point.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale);\r\n\t\t");
            WriteLiteral("ctx.closePath();\r\n\t\t");
            WriteLiteral("ctx.fill();\r\n");
#nullable restore
#line 57 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\tctx.font = \"12px Arial\";\r\n  //Draw points\r\n");
#nullable restore
#line 60 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
   foreach (var point in Model.Graph.Points.Values)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
            WriteLiteral("ctx.beginPath();\r\n");
#nullable restore
#line 63 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
		if (point.NeedsVisit)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t");
            WriteLiteral("ctx.strokeStyle = \"blue\";\r\n\t\t\t");
            WriteLiteral("ctx.arc(");
#nullable restore
#line 66 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                  Write(point.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 66 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                    Write(point.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, 20*scale, 0, 2 * Math.PI);\r\n");
#nullable restore
#line 67 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
		}
		else{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t");
            WriteLiteral("ctx.strokeStyle = \"black\";\r\n\t\t\t");
            WriteLiteral("ctx.arc(");
#nullable restore
#line 70 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                  Write(point.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 70 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                    Write(point.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, 10*scale, 0, 2 * Math.PI);\r\n");
#nullable restore
#line 71 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t");
            WriteLiteral("ctx.stroke();\r\n\t\t");
            WriteLiteral("ctx.fillText(\"");
#nullable restore
#line 73 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                    Write(point.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\", ");
#nullable restore
#line 73 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                      Write(point.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 73 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                                        Write(point.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale);\r\n");
#nullable restore
#line 74 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("  ctx.lineWidth = 2;\r\n\t\t\r\n");
#nullable restore
#line 77 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
   foreach (var edge in Model.Graph.AdjacencyList)
	{
	foreach(var target in edge.Value){
		var r = random.Next(10,256);
		var g = 0;
			var b = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t");
            WriteLiteral("ctx.strokeStyle = \"#eee\";\r\n  ");
            WriteLiteral("ctx.beginPath();\r\n\t\t");
            WriteLiteral("ctx.moveTo(");
#nullable restore
#line 85 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                 Write(Model.Graph.Points[edge.Key].X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 85 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                                          Write(Model.Graph.Points[edge.Key].Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale);\r\n\t\t\t");
            WriteLiteral("ctx.lineTo(");
#nullable restore
#line 86 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                     Write(Model.Graph.Points[target].X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 86 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                                            Write(Model.Graph.Points[target].Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale);\r\n  ");
            WriteLiteral("ctx.stroke();\r\n");
#nullable restore
#line 88 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
	 }
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\r\n\t\t\tctx.strokeStyle = \"black\";\r\n\tctx.beginPath();\r\n");
#nullable restore
#line 93 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
          
			var firstPoint = Model.Graph.FoundPath.First();
			

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\tctx.moveTo(");
#nullable restore
#line 96 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
               Write(firstPoint.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 96 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                      Write(firstPoint.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale);\r\n");
#nullable restore
#line 97 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
         foreach(var point in Model.Graph.FoundPath.Skip(1))
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t");
            WriteLiteral("ctx.lineTo(");
#nullable restore
#line 99 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                     Write(point.X);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale, ");
#nullable restore
#line 99 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
                                       Write(point.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("*scale);\r\n\t\t");
            WriteLiteral("ctx.stroke();\r\n\t\t");
            WriteLiteral("await sleep(60);\r\n");
#nullable restore
#line 102 "C:\Users\reije\source\repos\WarehouseOptimization\WarehouseOptimization\Views\Home\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\r\n})();\r\n\t\tfunction sleep(ms) {\r\n  return new Promise(resolve => setTimeout(resolve, ms));\r\n}\r\n\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WarehouseMap> Html { get; private set; }
    }
}
#pragma warning restore 1591