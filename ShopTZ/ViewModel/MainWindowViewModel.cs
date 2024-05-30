using ShopTZ.Model;
using ShopTZ.Utils;
using ShopTZ.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ShopTZ.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            _currentUser = TZEntities.GetContext().User.ToList()[0];
            _SelectedProduct = new Product();
            _searchFilter = "";
            UpdatePosition();
        }

        private User _currentUser { get; set; }
        private List<Product> _buyingdProducts = new List<Product>();

        public decimal UserBalance
        {
            get => _currentUser.UserMoney;
            set
            {
                _currentUser.UserMoney = value;
                OnPropertyChanged();
            }
        }

        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            get => _SelectedProduct; 
            set
            {
                _SelectedProduct = value;
                isUpperButton = value != null;
                OnPropertyChanged();
            }
        }
       
        private int _selectedProductsCount;
        public int SelectedProductsCount 
        { 
            get => _selectedProductsCount; 
            set
            {
                _selectedProductsCount = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Product> _productList;
        public ObservableCollection<Product> ProductList
        {
            get => _productList;
            set
            {
                _productList = value;
                OnPropertyChanged();
            }
        }

        private string _searchFilter;
        public string SearchFilter
        {
            get => _searchFilter; 
            set
            {
                _searchFilter = value;
                OnPropertyChanged();
            }
        }

        private bool _isBuyButton;
        public bool isBuyButton 
        { 
            get =>  _isBuyButton;
            set
            { 
                _isBuyButton = value;
                //_isBuyButton = selectedProductsCount > 0;
                OnPropertyChanged();
            }
        }

        private bool _isUpperButton;
        public bool isUpperButton
        {
            get => _isUpperButton;
            set
            {
                _isUpperButton = value;
                //_isUpperButton = selectedProductsCount > 0;
                OnPropertyChanged();
            }
        }

        public RelayCommand Delete_Button_Click => new RelayCommand(obj =>
        {
            DeleteProduct(SelectedProduct);
            UpdatePosition();
        });
            
        public RelayCommand infoButton_Click => new RelayCommand(obj =>
        {
            InfoProduct info = new InfoProduct(SelectedProduct);
            info.ShowDialog();
        });

        public RelayCommand Add_Button_Click =>  new RelayCommand(obj =>
        {
            AddProduct addproduct = new AddProduct(null);
            addproduct.ShowDialog();
            UpdatePosition();
        });

        public RelayCommand Edit_Button_Click =>  new RelayCommand(obj =>
        {
            AddProduct addproduct = new AddProduct(SelectedProduct);
            addproduct.ShowDialog();
            UpdatePosition();
        });

        public RelayCommand Buy_Button_Click => new RelayCommand(obj =>
        {
            BuyWindow buy = new BuyWindow(_buyingdProducts, _currentUser);
            buy.ShowDialog();
            UpdatePosition();
        });

        public RelayCommand Btn_Journal_Click => new RelayCommand(obj =>
        {
            Journal jur = new Journal();
            jur.ShowDialog();
        });

        public RelayCommand Btn_Minus_Click => new RelayCommand(obj =>
        {
            MinusBuyingProduct();
        });

        private void MinusBuyingProduct()
        {
            if (_buyingdProducts.FindAll(x => x.ProductID == SelectedProduct.ProductID).Count != 0)
            {
                SelectedProduct.BuyCount -= 1;
                if (SelectedProduct.BuyCount <= 0)
                {
                    _buyingdProducts.Remove(SelectedProduct);
                    SelectedProductsCount -= 1;
                }
                if (SelectedProductsCount == 0)
                    isBuyButton = false;
            }
            UpdatePosition();
        }

        public RelayCommand Btn_Plus_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    TZEntities.GetContext().Product.ToList().Find(x => x.ProductID == SelectedProduct.ProductID).BuyCount += 1;
                    if (_buyingdProducts.FindAll(x => x.ProductID == SelectedProduct.ProductID).Count == 0)
                    {
                        _buyingdProducts.Add(SelectedProduct);
                        SelectedProductsCount += 1;
                        isBuyButton = true;
                    }

                    UpdatePosition();
                });
            }
        }

        public RelayCommand Search_Click
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (SearchFilter != "")
                        ProductList = ProductList.Where(p => p.ProductName.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0).ToObservable(); 
                    else
                        UpdatePosition();

                    OnPropertyChanged();
                });
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
                    OnPropertyChanged();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибкае");
                }
            }
        }

        private void UpdatePosition()
        {
            ProductList = TZEntities.GetContext().Product.ToObservable();
        }
    }
}
