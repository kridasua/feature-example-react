using HomePageFeature.Data.Entity;

namespace HomePageFeature.Data.Repository
{
    public class FeatureRepository
    {
        public FeatureTestEntities entities;

        public FeatureRepository() {
            entities = new FeatureTestEntities();        
        }
    }
}
