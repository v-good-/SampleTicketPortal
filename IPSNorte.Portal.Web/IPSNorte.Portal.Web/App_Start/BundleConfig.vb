﻿Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery-ui.min.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                     "~/Scripts/jquery.validate*",
                     "~/Scripts/jquery.unobtrusive*"))
         

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqgrid").Include(
                "~/Scripts/jquery.jqGrid.min.js",
                "~/Scripts/grid.locale-es*"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css", "~/Content/jquery-ui.css",
                  "~/Content/site.css", "~/Content/ui.jqgrid.css"))

        bundles.Add(New ScriptBundle("~/bundles/flot").Include(
                  "~/Scripts/Flot/jquery.flot*",
                  "~/Scripts/Flot/excanvas.js"))

        ' Set EnableOptimizations to false for debugging. For more information,
        ' visit http://go.microsoft.com/fwlink/?LinkId=301862
        BundleTable.EnableOptimizations = False
    End Sub
End Module

