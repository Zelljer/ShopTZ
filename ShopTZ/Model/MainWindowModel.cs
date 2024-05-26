using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ShopTZ.Model
{
    public class MainWindowModel :  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Invalidate()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductList"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("selectedProductsCount"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BuyButtonVisible"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UpperButtonVisible"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("currentUser"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchFilter"));
            }
        }

        public void DeleteProduct(Product product)
        {
            if (MessageBox.Show($"Вы точно хотите удалить продукт?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    TZEntities.GetContext().Product.Remove(product);
                    TZEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    Invalidate();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибкае");
                }
            }
        }
    }
}
