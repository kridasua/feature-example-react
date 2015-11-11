using HomePageFeature.Data.Repository;
using HomePageFeature.Web.Models;
using System.Linq;
using System.Web.Http;

namespace HomePageFeature.Web.Controllers
{
    [RoutePrefix("api/panel")]
    public class PanelController : ApiController
    {
        FeatureRepository featureRepo = new FeatureRepository();

        [HttpGet]
        [Route("{Id:int}")]
        public PanelModel GetPanel(int id)
        {
            var paneldb = featureRepo.entities.Panels.FirstOrDefault(p => p.PanelId == 1);

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
