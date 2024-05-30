using ShopTZ.Model;
using ShopTZ.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShopTZ.ViewModel
{
    public class JournalViewModel : BaseViewModel
    {
        private ObservableCollection<Receipt> _bufferCollection;

        public JournalViewModel() 
        {
            _receiptList = TZEntities.GetContext().Receipt.ToObservable();
            _bufferCollection = new ObservableCollection<Receipt>(_receiptList);
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                Filtration();
                OnPropertyChanged();
            }
        }

        public string[] FiltrList { get; set; } =
        {
            "Без фильтрации",
            "За сегодня",
            "За вчера",
            "За 3 дня",
            "За месяц",
            "За 3 месяца",
            "Ранее",
        };

        private ObservableCollection<Receipt> _receiptList;
        public ObservableCollection<Receipt> ReceiptList
        {
            get => _receiptList;
            set
            {
                _receiptList = value;
                OnPropertyChanged();
            }
        }

        private void Filtration()
        {
            var result = new ObservableCollection<Receipt>(_bufferCollection);
            switch (SelectedIndex)
            {
                case 1:
                    result = result.Where(p => p.ReceiptRDate.Date == DateTime.Today.Date).ToObservable();
                    break;
                case 2:
                    result = result.Where(p => p.ReceiptRDate.Date == DateTime.Now.AddDays(-1).Date).ToObservable(); ;
                    break;
                case 3:
                    result = result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddDays(-3).Date).ToObservable();
                    break;
                case 4:
                    result = result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddMonths(-1).Date).ToObservable();
                    break;
                case 5:
                    result = result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddMonths(-3).Date).ToObservable();
                    break;
                case 6:
                    result = result.Where(p => p.ReceiptRDate.Date <= DateTime.Now.AddYears(-1).Date).ToObservable();
                    break;
            }
            ReceiptList = result;
        }
    }
}
