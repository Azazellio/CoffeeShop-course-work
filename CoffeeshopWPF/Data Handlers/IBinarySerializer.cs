
namespace CoffeeShop.Data_Handlers
{
    interface IBinarySerializer : ISerializer
    {
        object Deserialize(dynamic unDeserialized);
    }
}
