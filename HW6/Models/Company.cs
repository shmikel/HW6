using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.Models
{
    class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public DTO.Phone[] Phones { get; set; }
        public DTO.Link[] Links { get; set; }
        public string Phones_inline { get; set; }
        public string Links_inline { get; set; }

        public Company() { }
        public Company(DTO.Feature item)
        {
            Name = item.Properties.Name;
            Address = item.Properties.Description;
            Url = item.Properties.CompanyMetaData.Url;
            Phones = item.Properties.CompanyMetaData.Phones;
            Links = item.Properties.CompanyMetaData.Links;
            try
            {
                foreach (var phone in Phones)
                {
                    Phones_inline += phone.Formatted + "\n";
                }
            }
            catch { }
            try
            {
                foreach (var link in Links)
                {
                    Links_inline += link.Aref + "\n";
                }
            }
            catch { }

        }
    }

}
