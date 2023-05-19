using ITAPP;
using ITAPP.AppDataFile;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ITAPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditProduct.xaml
    /// </summary>
    public partial class PageEditProduct : Page
    {
        public PageEditProduct(Services services)
        {
            InitializeComponent();
            WorkObj.id = services.ID_services;

            TxtTitle.Text = services.Name_services;
            TxtCost.Text = Convert.ToString(services.Price_services);

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IEnumerable<Services> services = ConnectOdb.conObj.Services.Where(x => x.ID_services == WorkObj.id).AsEnumerable().
                    Select(x =>
                    {
                        x.Name_services = TxtTitle.Text;
                        x.Price_services = Convert.ToDecimal(TxtCost.Text);
                        return x;
                    });
                foreach (Services prdct in services)
                {
                    ConnectOdb.conObj.Entry(prdct).State = System.Data.Entity.EntityState.Modified;
                }

                ConnectOdb.conObj.SaveChanges();
                MessageBox.Show("Данные успешно изменены!", "Уведобление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message.ToString());
            }
        }
    }
}
