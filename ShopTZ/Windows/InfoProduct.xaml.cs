using ShopTZ.Model;
using ShopTZ.ViewModel;

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
