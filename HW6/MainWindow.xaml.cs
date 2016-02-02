using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Threading;

namespace HW6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task t = Task.Factory.StartNew(() => MessageBox.Show(" QuickCall - это:\n\n -Универсальный поиск организаций и учреждений.\n -Мгновенное добавление номеров в телефонную книгу android.\n\nЧто-то ещё? Пишите!"));
            Task t2 = Task.Factory.StartNew(() =>
            {
                var i = 20;
                while (i>5)
                {
                    AddOneResult(new DTO.Feature()); Task.Delay(5000); i--;
                } 
            });
        }

        private void Button_Switch_Mode(object sender, RoutedEventArgs e)
        {
            #region Смена карточек

            var color = ColorTranslator.FromHtml("#0796A2");
            var myBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));

            if (((Button)sender).Name == "Button_Contact")
            {
                Button_Contact.Background = System.Windows.Media.Brushes.White;
                Button_Company.Background = myBrush;
                Company_Card.Visibility = Visibility.Hidden;
                Contact_Card.Visibility = Visibility.Visible;
            }
            else
            {
                Button_Contact.Background = myBrush;
                Button_Company.Background = System.Windows.Media.Brushes.White;
                Company_Card.Visibility = Visibility.Visible;
                Contact_Card.Visibility = Visibility.Hidden;
            }
            #endregion
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SwitchBarOn(true);

            var qText = Query_Text.Text.Trim();
            var qCity = "г. " + Query_City.Text.Trim();
            if (qText == "") { MessageBox.Show("Вы забыли ввести запрос!"); SwitchBarOn(false); return; }
            if (qCity == "г. ") { MessageBox.Show("Вы не указали город!"); SwitchBarOn(false); return; }
            YandexAPI API = null;
            DTO.MainData queryResult = null;
            Task t1 = Task.Factory.StartNew(() =>
            {
                try
                {
                    API = new YandexAPI();
                }
                catch { MessageBox.Show("No Internet connection or Wrong settings!"); SwitchBarOn(false); return; }
                try
                {
                    queryResult = API.Query(qText + " " + qCity);
                    foreach (var item in queryResult.Features)
                    {
                        MessageBox.Show(item.Properties.Description);
                    }
                    SwitchBarOn(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    SwitchBarOn(false);
                    return;
                }
            });

        }
        private void SwitchBarOn(bool sw)
        {
            if (sw)
            {
                Search.Dispatcher.BeginInvoke(new Action(() => Search.Visibility = Visibility.Hidden));
                Bar.Dispatcher.BeginInvoke(new Action(() => Bar.IsIndeterminate = true));
                Bar.Dispatcher.BeginInvoke(new Action(() => Bar.Visibility = Visibility.Visible));
            }
            else
            {
                Search.Dispatcher.BeginInvoke(new Action(() => Search.Visibility = Visibility.Visible));
                Bar.Dispatcher.BeginInvoke(new Action(() => Bar.IsIndeterminate = false));
                Bar.Dispatcher.BeginInvoke(new Action(() => Bar.Visibility = Visibility.Hidden));
            }
        }
        private void AddOneResult(DTO.Feature Company)
        {
            //I gave up and had no forces to understand MVVM.

            Stack.Dispatcher.BeginInvoke(DispatcherPriority.Send , new Action(() =>
            { 
                Stack.Children.Add(
                    new Border() { BorderThickness = new Thickness(1), CornerRadius = new CornerRadius(15), Height = 104, Width = 650, Background = System.Windows.Media.Brushes.LightBlue, VerticalAlignment = VerticalAlignment.Top, BorderBrush = System.Windows.Media.Brushes.Black, Child = new Grid() }
                    );
                UIElementCollection children = Stack.Children;

                //Добавление необходимых элементов вывода
                ((Grid)((Border)children[children.Count-1]).Child).Children.Add(new TextBox() { HorizontalAlignment = HorizontalAlignment.Left, Height = 27, Margin = new Thickness(145, 66, 0, 0), TextWrapping = TextWrapping.Wrap, Text = "", VerticalAlignment = VerticalAlignment.Top, Width = 297, FontSize = 18 });
                
            }));
        }
    }
}
