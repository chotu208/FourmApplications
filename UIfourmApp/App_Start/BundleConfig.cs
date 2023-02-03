using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace UIfourmApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/jquery-3.6.3.js",
                "~/Scripts/umd/popper.js","~/Scripts/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Styles/bootstrap").Include("~/Content/bootstarp.css"));
            bundles.Add(new StyleBundle("~/Styles/MyStyles").Include("~/Content/MyStyles.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}