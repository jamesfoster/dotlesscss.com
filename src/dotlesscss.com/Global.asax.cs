﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Spark;

namespace dotlesscss.com
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Root",
				"", new {controller = "Home", action = "Index"} );

			routes.MapRoute(
				"Default",
				"{action}.aspx", new {controller = "Home", action = "Index"} );

			routes.MapRoute(
				"Documentation",
				"Docs/{chapterName}/{topicName}",
				new { controller = "Documentation", action = "Index", chapterName = UrlParameter.Optional, topicName = UrlParameter.Optional } );
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);


			ISparkSettings settings = new SparkSettings()
				.SetStatementMarker("#>"); // change the statement marker because css lines may start with #

			var viewFactory = new Spark.Web.Mvc.SparkViewFactory(settings);

			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(viewFactory);
		}
	}
}