using Module6HW5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW5.Data
{
    public sealed class Provider
    {
        public Provider()
        {
            if (_firstUse)
            {
                var config = new ProviderConfigure();
                Mylist.AddRange(config.ConfigData());
                _firstUse = false;
            }
        }

        private static bool _firstUse = true;

        private static Provider _instance;

        public static List<CreateUserParameters> Mylist = new List<CreateUserParameters>();

        public static Provider GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Provider();
            }

            return _instance;
        }

        public  List<CreateUserParameters> GetList()
        {
            return Mylist;
        }

        public List<CreateUserParameters> Create(CreateUserParameters user)
        {
            Mylist.Add(user);
            return Mylist;
        }   
    }
}
