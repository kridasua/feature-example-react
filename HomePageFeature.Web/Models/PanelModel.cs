using System.Collections.Generic;

namespace HomePageFeature.Web.Models
{
    public class PanelModel
    {
        public PanelModel() {
            Elements = new List<ElementModel>();        
        }
        public string Name { get; set; }
        public byte? DisplayOrder { get; set; }
        public LayoutModel Layout { get; set; }
        public List<ElementModel> Elements { get; set; }        
    }
}