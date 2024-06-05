using ShopTZ.ViewModel;
using System.Windows;

namespace ShopTZ
{
    /// <summary>
    /// Логика взаимодействия для Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        public Journal()
        {
            InitializeComponent();
            DataContext = new JournalViewModel();
        }
    }
}
