using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopTZ.Model
{
    public class AddProductModel
    {
        public void SaveProduct(Product product)
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
