using PlayZone.DAL.Entities.Configuration_Related;

namespace PlayZone.DAL.Interfaces.Configuration_Related;

public interface IConfigurationRepository
{
        public IEnumerable<Configuration> GetAll();
        public Configuration? GetById(int id);
        public int Create(Configuration configuration);
        public bool Update(Configuration configuration);
        public bool Delete(int id);
}
