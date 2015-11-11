using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HomePageFeature.Web.ReactConfig), "Configure")]

namespace HomePageFeature.Web
{
    public static class ReactConfig
    {
        public static void Configure()
        {
            // If you want to use server-side rendering of React components, 
            // add all the necessary JavaScript files here. This includes 
            // your components as well as all of their dependencies.
            // See http://reactjs.net/ for more information. Example:
            ReactSiteConfiguration.Configuration
                .AddScript("~/Scripts/showdown.js")
                .AddScript("~/Scripts/Panel.jsx")
                .AddScript("~/Scripts/Comment.jsx");
            
            
            // If you use an external build too (for example, Babel, Webpack,
            // Browserify or Gulp), you can improve performance by disabling 
            // ReactJS.NET's version of Babel and loading the pre-transpiled 
            // scripts. Example:
            //ReactSiteConfiguration.Configuration
            //	.SetLoadBabel(false)
            //	.AddScriptWithoutTransform("~/Scripts/bundle.server.js")
        }
    }
}