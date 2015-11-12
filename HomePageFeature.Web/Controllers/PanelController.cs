using HomePageFeature.Data.Repository;
using HomePageFeature.Web.Models;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomePageFeature.Web.Controllers
{
    [RoutePrefix("api/panel")]
    public class PanelController : ApiController
    {
        FeatureRepository featureRepo = new FeatureRepository();

        [HttpGet]
        [Route("{Id:int}")]
        public dynamic GetPanel(int id)
        {
            //var panel = GetFromDataBase(id);
            var panel = GetFromFile();
            return panel;
        }

        private object GetFromFile()
        {
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, "Resources\\Panel.json");

            string readContents = string.Empty;
            using (StreamReader streamReader = new StreamReader(path))
            {
                readContents = streamReader.ReadToEnd();
            }

            return System.Web.Helpers.Json.Decode(readContents);

        }

        private object GetFromDataBase(int id)
        {
            var paneldb = featureRepo.entities.Panels.FirstOrDefault(p => p.PanelId == id);

            var panel = new PanelModel()
            {
                Name = paneldb.Name,
                DisplayOrder = paneldb.DisplayOrder
            };

            panel.Layout = new LayoutModel()
            {
                Content = paneldb.Layout.Content,
                Name = paneldb.Layout.Name
            };
            panel.Elements = paneldb.PanelElements.Select(pe => new ElementModel()
            {
                //Content = System.Web.Helpers.Json.Decode(pe.Content),
                Content = System.Web.Helpers.Json.Decode(pe.Content),
                Type = pe.Element.Name
            }).ToList();
            return panel;
        }
    }
}
