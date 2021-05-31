using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CoffeeShop.Data_Handlers
{
    class BinarySerializer : IBinarySerializer
    {
        private BinaryFormatter bf;
        public BinarySerializer()
        {
            bf = new BinaryFormatter();
        }
        public object Deserialize(dynamic unDeserialized)
        {
            object res = null;
            using (FileStream stream = new FileStream(unDeserialized, FileMode.Open, FileAccess.Read))  //undeserialized = path
            {
                res = bf.Deserialize(stream);
            }
            return res;
        }
        public void Serialize(object objectToSerialize, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                bf.Serialize(stream, objectToSerialize);
            }
        }
    }
}
