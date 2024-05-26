using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShopTZ.Model
{
    public class InfoProductModel
    {
        public void DataToExcel(Product data)
        {
            Excel.Application app = new Excel.Application();
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
