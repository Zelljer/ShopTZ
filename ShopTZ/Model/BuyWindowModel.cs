using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopTZ.Model
{
    public class BuyWindowModel
    {
        public void SetListIdAndBuyCost(List<Product> products)
        {
            foreach (Product product in products)
            {
                product.BuyListId = products.IndexOf(product) + 1;
                product.BuyCost = product.BuyCount * product.ProductCost;
            }
        }

        public void Buy(User Buyer,decimal FinaleCost, string FinaleNames)
        {
            if (Buyer.UserMoney >= FinaleCost)
            {
                try
                {
                    TZEntities.GetContext().Receipt.Add(new Receipt
                    {
                        ReceiptBuyer = Buyer.UserID,
                        ReceiptDate = DateTime.Now.ToString(),
                        ReceiptSumm = FinaleCost,
                        ReceiptProducts = FinaleNames
                    });
                    Buyer.UserMoney -= FinaleCost;
                    TZEntities.GetContext().SaveChanges();
                    MessageBox.Show("Покупка прошла успешно");
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка, повторите попытку позже");
                }
            }
            else { MessageBox.Show("Недостаточно средств для совершения покупки"); }
        }
    }
}
