using ShopTZ.Model;
using ShopTZ.ViewModel;
using System.Windows;

namespace ShopTZ
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct(Product selectedProduct)
        {
            InitializeComponent();
            DataContext = new AddProductViewModel(selectedProduct);
        }     
    }
}
