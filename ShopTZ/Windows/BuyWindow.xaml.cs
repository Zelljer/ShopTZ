using ShopTZ.Model;
using ShopTZ.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace ShopTZ.Windows
{
    /// <summary>
    /// Логика взаимодействия для BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        public BuyWindow(List<Product> products, User buyer)
        {
            InitializeComponent();
            DataContext = new BuyWindowViewModel(products, buyer);
        }
    }
}
