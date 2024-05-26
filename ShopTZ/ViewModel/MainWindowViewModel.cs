using ShopTZ.Model;
using ShopTZ.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShopTZ.ViewModel
{
    public class MainWindowViewModel : MainWindowModel
    {
        public User currentUser = TZEntities.GetContext().User.ToList()[0];
        public decimal userBalance
        {
            get { return currentUser.UserMoney; }
            set
            {
                currentUser.UserMoney = value;
                Invalidate();
            }
        }

        public List<Product> buyingdProducts = new List<Product>();

        public Product _SelectedProduct = new Product();
        public Product SelectedProduct
        {
            get { return _SelectedProduct; }
            set
            {
                _SelectedProduct = value;
                if (_SelectedProduct != null)
                    isselected = true;
                Invalidate();
            }
        }

        public int _selectedProductsCount = 0;
        public int selectedProductsCount 
        { 
            get
            {
                return _selectedProductsCount;
            }
            set
            {
                if (value >= 0)
                    _selectedProductsCount = value;
                Invalidate();
            }
        }
        public bool isselected = false;

        public IEnumerable<Product> _ProductList = TZEntities.GetContext().Product.ToList();
        public IEnumerable<Product> ProductList
        {
            get
            {
                return _ProductList;
            }
            set
            {
                _ProductList = value;
                Invalidate();
            }
        }

        public string _SearchFilter = "";
        public string SearchFilter
        {
            get { return _SearchFilter; }
            set
            {
                _SearchFilter = value;
                Invalidate();
            }
        }

        public string BuyButtonVisible
        {
            get
            {
                if (selectedProductsCount > 0) return "Visible";
                return "Collapsed";
            }
            set
            { Invalidate(); }
        }

        public string UpperButtonVisible
        {
            get
            {
                if (isselected) return "Visible";
                return "Collapsed";
            }
            set
            { Invalidate(); }
        }

        public RelayCommand Delete_Button_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    DeleteProduct(SelectedProduct);
                    Invalidate();
                });
            }
        }

        public RelayCommand infoButton_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    InfoProduct info = new InfoProduct(SelectedProduct);
                    info.ShowDialog();
                });
            }
        }

        public RelayCommand Add_Button_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    AddProduct addproduct = new AddProduct(null);
                    addproduct.ShowDialog();
                    Invalidate();
                });
            }
        }

        public RelayCommand Edit_Button_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    AddProduct addproduct = new AddProduct(SelectedProduct);
                    addproduct.ShowDialog();
                });
            }
        }

        public RelayCommand Buy_Button_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    BuyWindow buy = new BuyWindow(buyingdProducts, currentUser);
                    buy.ShowDialog();
                });
            }
        }

        public RelayCommand Btn_Journal_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    Journal jur = new Journal();
                    jur.ShowDialog();
                });
            }
        }

        public RelayCommand Btn_Minus_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (buyingdProducts.FindAll(x => x.ProductID == SelectedProduct.ProductID).Count != 0)
                    {
                        SelectedProduct.BuyCount -= 1;
                        if (SelectedProduct.BuyCount <= 0)
                        {
                            buyingdProducts.Remove(SelectedProduct);
                            selectedProductsCount -= 1;
                        }
                    }
                    _ProductList = TZEntities.GetContext().Product.ToList();
                    Invalidate();
                });
            }
        }

        public RelayCommand Btn_Plus_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    TZEntities.GetContext().Product.ToList().Find(x => x.ProductID == SelectedProduct.ProductID).BuyCount += 1;
                    if (buyingdProducts.FindAll(x => x.ProductID == SelectedProduct.ProductID).Count == 0)
                    {
                        buyingdProducts.Add(SelectedProduct);
                        selectedProductsCount += 1;
                    }

                    _ProductList = TZEntities.GetContext().Product.ToList();
                    Invalidate();
                });
            }
        }

        public RelayCommand Search_Click
        {
            get
            {
                return null ?? new RelayCommand(obj =>
                {
                    if (SearchFilter != "")
                        ProductList = ProductList.Where(
                            p => p.ProductName.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0);
                    else
                        _ProductList = TZEntities.GetContext().Product.ToList();

                    Invalidate();
                });
            }
        }
    }
}
