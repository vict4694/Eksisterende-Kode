using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    public class Store
    {
        string storeName;
        public Store(string storeName)
        {
            StoreName = storeName;
        }

        public Store() { }
        public string StoreName
        {
            get { return storeName; }
            set { storeName = value; }
        }
    }
}
