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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExcelProject.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PayAddPage.xaml
    /// </summary>
    public partial class PayAddPage : Page
    {
        Core bd = new Core();
        List<Category> cat;
        public PayAddPage()
        {
            InitializeComponent();
            cat = bd.context.Category.ToList();
            
            CategoryComboBox.ItemsSource = cat.Select(x => x.name_category).ToArray();

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                Payment payments = new Payment()
                {
                    name = PayNameTextBlock.Text,
                    count = Convert.ToInt32(CountTextBlock.Text),
                    
                }
};
            }
    }
}
