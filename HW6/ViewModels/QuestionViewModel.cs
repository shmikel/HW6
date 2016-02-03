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
using System.Collections.ObjectModel;

namespace HW6.ViewModels
{

    class QuestionViewModel : ViewModelBase
    {
        public Question Question;

        public QuestionViewModel(Question Question)
        {
            this.Question = Question;
        }

        public string Text
        {
            get { return Question.Text; }
            set
            {
                Question.Text = value;
                OnPropertyChanged("Text");
            }
        }
        public string City
        {
            get { return Question.City; }
            set
            {
                Question.City = value;
                OnPropertyChanged("City");
            }
        }

        #region Commands

        #region Поиск

        private DelegateCommand searchCommand;

        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new DelegateCommand(Search);
                }
                return searchCommand;
            }
        }

        private void Search()
        {
            Text = Text.Trim();
            City = City.Trim();
            if (Text == "") { MessageBox.Show("Вы забыли ввести запрос!");  return; }
            if (City == "") { MessageBox.Show("Вы не указали город!");  return; }
            YandexAPI API = null;
            DTO.MainData queryResult = null;
            Task t1 = Task.Factory.StartNew(() =>
            {
                try
                {
                    API = new YandexAPI();
                }
                catch { MessageBox.Show("No Internet connection or Wrong settings!\n Try again!"); return; }
                try
                {
                    queryResult = API.Query(Text + " г. " + City);

                    var CompanyList = new List<Company>(queryResult.Features.Select(a => new Company(a)));
                    
                    string st = "";
                    foreach (var item in CompanyList)
                    {
                        st += item.Address + "\n";
                    }
                    MessageBox.Show(st);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            });

        }

        private void SwitchBar(string sw)
        {
            //if (sw == "On")
            //{
            //    Search.Dispatcher.BeginInvoke(new Action(() => Search.Visibility = Visibility.Hidden));
            //    Bar.Dispatcher.BeginInvoke(new Action(() => Bar.IsIndeterminate = true));
            //    Bar.Dispatcher.BeginInvoke(new Action(() => Bar.Visibility = Visibility.Visible));
            //}
            //else
            //{
            //    Search.Dispatcher.BeginInvoke(new Action(() => Search.Visibility = Visibility.Visible));
            //    Bar.Dispatcher.BeginInvoke(new Action(() => Bar.IsIndeterminate = false));
            //    Bar.Dispatcher.BeginInvoke(new Action(() => Bar.Visibility = Visibility.Hidden));
            //}
        }

        #endregion

        #endregion

    }
}
