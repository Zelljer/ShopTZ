using ShopTZ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopTZ.ViewModel
{
    public class BuyWindowViewModel : BuyWindowModel
    {
        public List<Product> ListProducts { get; set; }
        public User BuyerUser { get; set; }

        public decimal finCost
        {
            get 
            {
                decimal money = 0;
                foreach (Product product in ListProducts)
                {
                    money += product.BuyCost;
                }
                return money;
            } 
        }

        public decimal finCount 
        {
            get
            { 
                int count = 0;
                foreach (Product product in ListProducts)
                {
                    count += product.BuyCount;
                }
                return count;
            }
        }

        public string finNames
        {
            get 
            {
                string names = "";
                foreach (Product product in ListProducts)
                {
                    names += product.ProductName;
                    if (product != ListProducts.Last())
                        names += " ; ";
                }
                return names;
            }
        }

        public decimal userCash 
        {
            get 
            {
                return BuyerUser.UserMoney - finCost;
            }
        }

        public BuyWindowViewModel(List<Product> products, User buyer)
        {
            ListProducts = products;
            BuyerUser = buyer;

            SetListIdAndBuyCost(products);
        }

        public RelayCommand BuyButton_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Buy(BuyerUser,finCost,finNames);
                });
            }
        }
    }
}
