using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Model;

namespace CustomerDemo
{
    
    public class CustomerStore
    {
        
        private FileStream fs = null;
        private BinaryFormatter bf = null;
        public CustomerStore()
        {
            fs = new FileStream("C:\\Users\\Akash.Verma\\Desktop\\New folder\\CustData.txt", FileMode
        }

        public CustomerCollection RetrieveCustomer()
        {
            if (File.Exists("C:\\FolderDemo\\CustData.txt"))
            {
                fs = new FileStream("C:\\FolderDemo\\CustData.txt", FileMode.Open, FileAccess.Read);
                CustomerCollection cl= (CustomerCollection)bf.Deserialize(fs);
                fs.Flush();
                fs.Close();
                return cl;
            }
            else
            {
                return new CustomerCollection();
            }
        }
    }
}
