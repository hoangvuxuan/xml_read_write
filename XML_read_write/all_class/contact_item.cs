using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_read_write.all_class
{
    internal class contact_item
    {
        private string id;
        private string f_name;
        private string l_name;
        private string gender;
        private string phone;

 

        public string Id { get => id; set => id = value; }
        public string F_name { get => f_name; set => f_name = value; }
        public string L_name { get => l_name; set => l_name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
