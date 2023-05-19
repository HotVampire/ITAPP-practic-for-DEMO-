using ITAPP.Pages;
using ITAPP;
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
using System.Windows.Threading;
using ITAPP.AppDataFile;

namespace ITAPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        public PageProduct()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e)
        {
            var HistoryProduct = ConnectOdb.conObj.Services.ToList();
            ListProduct.ItemsSource = HistoryProduct;
            ListProduct.ItemsSource = ConnectOdb.conObj.Services.Where(x => x.Name_services.StartsWith(TxtSearch.Text) || x.Name_services.StartsWith(TxtSearch.Text)).ToList();
        }

        public void BtnEdit_Click(Object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageEditProduct((sender as Button).DataContext as Services));
        }
    }
}
