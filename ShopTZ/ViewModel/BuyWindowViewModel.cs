using ShopTZ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopTZ.ViewModel
{
    public class BuyWindowViewModel : BaseViewModel
    {
        
        private User _buyerUser { get; set; }

        public BuyWindowViewModel(List<Product> products, User buyer)
        {
            _listProducts = products;
            _buyerUser = buyer;

            SetListIdAndBuyCost(products);
        }

        private decimal _finaleCost;
        public decimal FinaleCost
        {
            get => _finaleCost;
            set { _finaleCost = value; OnPropertyChanged(); }

        }

        private decimal _finaleCount;
        public decimal FinaleCount
        {
            get => _finaleCount;
            set { _finaleCount = value; OnPropertyChanged(); }

        }

        private string _finaleNames;
        public string FinaleNames
        {
            get => _finaleNames;
            set { _finaleNames = value; OnPropertyChanged(); }

        }

        private List<Product> _listProducts { get; set; }
        public List<Product> ListProducts
        {
            get => _listProducts;
            set { _listProducts = value; OnPropertyChanged(); }
        }
        /*
        public decimal finCost
        {
            get 
            {
                decimal money = 0;
                foreach (Product product in _listProducts)
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
                foreach (Product product in _listProducts)
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
                foreach (Product product in _listProducts)
                {
                    names += product.ProductName;
                    if (product != _listProducts.Last())
                        names += " ; ";
                }
                return names;
            }
        }
        */

        public decimal UserCash => _buyerUser.UserMoney - FinaleCost;        

        public RelayCommand BuyButton_Click => new RelayCommand(obj =>
        {
            Buy(_buyerUser, FinaleCost, FinaleNames);
        });

        private void SetListIdAndBuyCost(List<Product> products)
        {

            foreach (Product product in products)
            {
                product.BuyListId = products.IndexOf(product) + 1;
                product.BuyCost = product.BuyCount * product.ProductCost;
                FinaleCost += product.BuyCost;
                FinaleCount += product.BuyCount;

            }
            FinaleNames = string.Join(",", products.Select(x => x.ProductName));
        }

            private void Buy(User Buyer, decimal FinaleCost, string FinaleNames)
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
