using ShopTZ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTZ.ViewModel
{
    public class InfoProductViewModel : InfoProductModel
    {
        public Product currentproduct = new Product();

        public InfoProductViewModel(Product selectedProduct)
        {
            currentproduct = selectedProduct;
        }

        public RelayCommand BtnExc_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    DataToExcel(currentproduct);
                });
            }
        }

        public int ID
        {
            get { return currentproduct.ProductID; }
            set { currentproduct.ProductID = value; }
        }
        public string Name
        {
            get { return currentproduct.ProductName; }
            set { currentproduct.ProductName = value; }
        }
        public string Unit
        {
            get { return currentproduct.ProductUnit; }
            set { currentproduct.ProductUnit = value; }
        }
        public int Quantity
        {
            get { return currentproduct.ProductQuantity; }
            set { currentproduct.ProductQuantity = value; }
        }
        public decimal Cost
        {
            get { return currentproduct.ProductCost; }
            set { currentproduct.ProductCost = value; }
        }
        public decimal SummForProduction
        {
            get { return currentproduct.ProductSummForProduction; }
            set { currentproduct.ProductSummForProduction = value; }
        }
    }
}
