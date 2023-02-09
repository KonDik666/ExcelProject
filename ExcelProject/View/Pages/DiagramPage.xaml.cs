using ExcelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExcelProject.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для DiagramPage.xaml
    /// </summary>
    public partial class DiagramPage : Page
    {
        Core bd = new Core();
        public DiagramPage()
        {
            InitializeComponent();
            Core bd = new Core();
            ChartPayments.ChartAreas.Add(new ChartArea("Main"));
            var currentSeries = new Series("Payments") { IsValueShownAsLabel = true };
            ChartPayments.Series.Add(currentSeries);
            ComboUsers.ItemsSource = bd.context.Users.ToList();
            ComboChartTypes.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
        }

        private void BtnExportToExcel_Click(object sender, RoutedEventArgs e)
        {
           
            if (ComboUsers.SelectedItem !=null && ComboChartTypes.SelectedItem is SeriesChartType currentType)
            {
                Users currentUser = ComboUsers.SelectedItem as Users;
               
                Series currentSeries = ChartPayments.Series.FirstOrDefault();
                currentSeries.ChartType = currentType;
                currentSeries.Points.Clear();

                var categoriesList = bd.context.Category.ToList();
                foreach(var category in categoriesList)
                {
                    currentSeries.Points.AddXY(category.name_category, bd.context.Payment.ToList().Where(p => p.Users.id_user == currentUser.id_user && p.Category == category).Sum(p=>p.price*p.cost));
                }
            }
        }
    }
}
