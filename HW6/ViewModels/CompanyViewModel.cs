using HW6.Models;
using H6.Commands;
using H6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HW6.ViewModels
{

    class CompanyViewModel: ViewModelBase
    {
        public Company Company;

        public CompanyViewModel(Company Company)
        {
            this.Company = Company;
        }

        public string Name
        {
            get { return Company.Name; }
            set
            {
                Company.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Address
        {
            get { return Company.Address; }
            set
            {
                Company.Address = value;
                OnPropertyChanged("Address");
            }
        }
        public string Url
        {
            get { return Company.Url; }
            set
            {
                Company.Url = value;
                OnPropertyChanged("Url");
            }
        }
        public DTO.Phone[] Phones
        {
            get { return Company.Phones; }
            set
            {
                Company.Phones = value;
                OnPropertyChanged("Name");
            }
        }
        public DTO.Link[] Links
        {
            get { return Company.Links; }
            set
            {
                Company.Links = value;
                OnPropertyChanged("Links");
            }
        }
        public string Links_inline
        {
            get { return Company.Links_inline; }
            set
            {
                Company.Links_inline = value;
                OnPropertyChanged("Links_inline");
            }
        }
        public string Phones_inline
        {
            get { return Company.Phones_inline; }
            set
            {
                Company.Phones_inline = value;
                OnPropertyChanged("Phones_inline");
            }
        }

    }
}
