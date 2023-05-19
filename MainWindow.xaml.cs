using ITAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
using ITAPP.AppDataFile;
using ITAPP.Pages;

namespace ITAPP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectOdb.conObj = new ITCompanyEntities();
            FrameObj.frameMain = FrmMain;

            FrmMain.Navigate(new PageMain());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
