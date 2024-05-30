using Microsoft.Office.Interop.Excel;
using ShopTZ.Model;
using System;

namespace ShopTZ.ViewModel
{
    public class InfoProductViewModel : BaseViewModel
    {
        private Product _currentproduct = new Product();

        public void Init(Product selectedProduct)
        {
            _currentproduct = selectedProduct;
        }

        public RelayCommand BtnExc_Click => new RelayCommand(obj =>
        {
            DataToExcel(_currentproduct);
        });

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

        public void DataToExcel(Product data)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Application.Workbooks.Add(Type.Missing);

            app.Range["A1"].Value = "ID";
            app.Range["B1"].Value = "Наименование";
            app.Range["C1"].Value = "Ед. измерения";
            app.Range["D1"].Value = "Кол-во";
            app.Range["E1"].Value = "Цена";
            app.Range["F1"].Value = "Сумма для производства";
            app.Range["A1:F1"].Cells.Font.Bold = true;
            app.Range["A1:F1"].Cells.Interior.Color = XlRgbColor.rgbSkyBlue;
            app.Range["A1:F1"].Cells.Style.WrapText = true;
            app.Range["A1:F1"].Cells.VerticalAlignment = XlHAlign.xlHAlignCenter;

            app.Range["A2"].Value = data.ProductID.ToString();
            app.Range["B2"].Value = data.ProductName.ToString();
            app.Range["C2"].Value = data.ProductUnit.ToString();
            app.Range["D2"].Value = data.ProductQuantity.ToString();
            app.Range["E2"].Value = data.ProductCost.ToString();
            app.Range["F2"].Value = data.ProductSummForProduction.ToString();

            app.Visible = true;
        }
    }
}
