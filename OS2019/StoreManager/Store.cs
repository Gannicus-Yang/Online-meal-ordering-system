using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS2019.StoreManager
{
    public class Store:Utiles 
    {
        public string account, storeName, address, storeId;
        public Store()
        {
            this.account = LoginForm.u.account;            
            
        }
    }

}
