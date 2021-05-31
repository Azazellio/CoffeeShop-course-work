using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data_Handlers
{
    interface ISerializer
    {
        void Serialize(object objectToSerialize, string path);
    }
}
