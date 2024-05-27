using Microsoft.Office.Interop.Excel;
using ShopTZ.Model;
using ShopTZ.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShopTZ.Windows
{
    /// <summary>
    /// Логика взаимодействия для InfoProduct.xaml
    /// </summary>
    public partial class InfoProduct : System.Windows.Window
    {
        public InfoProduct(Product selectedProduct)
        {
            InitializeComponent();
            var data = new InfoProductViewModel();
            data.Init(selectedProduct);
            DataContext = data;
        }
    }
}
