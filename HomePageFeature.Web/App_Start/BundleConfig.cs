using System.Web.Optimization;
using System.Web.Optimization.React;

namespace HomePageFeature.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new BabelBundle("~/bundles/main").Include(
                "~/Scripts/showdown.js",
                "~/Scripts/Panel.jsx",
                "~/Scripts/Comment.jsx"                
            ));
        }
    }
}
