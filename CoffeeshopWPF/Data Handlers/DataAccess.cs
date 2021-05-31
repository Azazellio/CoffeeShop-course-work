using System.Configuration;

namespace CoffeeShop.Data_Handlers
{
    class DataAccess : IDataAccess
    {
        IBinarySerializer binarySerializer;
        public DataAccess()
        {
            binarySerializer = new BinarySerializer();
        }

        public object Load()
        {
            var net = binarySerializer.Deserialize(ConfigurationManager.AppSettings["binfile"]);
            return net;
        }
        public void Save(object obj)
        {
            binarySerializer.Serialize(obj, ConfigurationManager.AppSettings["binfile"]);
        }
    }
}
