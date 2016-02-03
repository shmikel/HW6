using HW6.Models;
using H6.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<CompanyViewModel> CompanyList { get; set; }
        public QuestionViewModel QuestPanel { get; set; }
        public Action<List<Company>> RebildViewModel;

        #region Constructor
        public MainViewModel(List<Company> companies)
        {
            CompanyList = new ObservableCollection<CompanyViewModel>(companies.Select(b => new CompanyViewModel(b)));
            QuestPanel = new QuestionViewModel(new Question());
            
        }


        #endregion



    }
}
