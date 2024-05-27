using ShopTZ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopTZ.ViewModel
{
    public class AddProductViewModel : BaseViewModel
    {
        private Product _currentproduct;

        public AddProductViewModel(Product selectedProduct)
        {
            if (selectedProduct != null)
                _currentproduct = selectedProduct;
            else
                _currentproduct = new Product();
        }

        public int ID
        {
            get => _currentproduct.ProductID; 
            set { _currentproduct.ProductID = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get => _currentproduct.ProductName; 
            set { _currentproduct.ProductName = value; OnPropertyChanged(); }
        }
        public string Unit
        {
            get => _currentproduct.ProductUnit; 
            set { _currentproduct.ProductUnit = value; OnPropertyChanged(); }
        }
        public int Quantity
        {
            get => _currentproduct.ProductQuantity; 
            set { _currentproduct.ProductQuantity = value; OnPropertyChanged(); }
        }
        public decimal Cost
        {
            get => _currentproduct.ProductCost; 
            set { _currentproduct.ProductCost = value; OnPropertyChanged(); }
        }
        public decimal SummForProduction
        {
            get => _currentproduct.ProductSummForProduction; 
            set { _currentproduct.ProductSummForProduction = value; OnPropertyChanged(); }
        }

        public RelayCommand BtnSaveClick => new RelayCommand(obj =>
        {
            SaveProduct(_currentproduct);
        });

        private void SaveProduct(Product product)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(product.ProductName))
                errors.AppendLine("Укажите наименование продукта");
            if (string.IsNullOrWhiteSpace(product.ProductUnit))
                errors.AppendLine("Укажите ед. измерения продукта");
            if (product.ProductCost < 0)
                errors.AppendLine("Цена продукта не может быть отрицательной");
            if (product.ProductQuantity < 0)
                errors.AppendLine("Количество продукта не может быть отрицательным");
            if (product.ProductSummForProduction < 0)
                errors.AppendLine("Сумма для производства продукта не может быть отрицательной");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (product.ProductID == 0)
                TZEntities.GetContext().Product.Add(product);
            try
            {
                TZEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка, повторите попытку позже");
            }
        }
    }
}
