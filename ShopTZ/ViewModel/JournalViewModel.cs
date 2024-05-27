using ShopTZ.Model;
using ShopTZ.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTZ.ViewModel
{
    public class JournalViewModel : BaseViewModel
    {

        public JournalViewModel() 
        {
            _receiptList = TZEntities.GetContext().Receipt.ToObservable();
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
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
            get
            {
                var Result = _receiptList;

                return Filtration(ref Result);
            }
            set
            {
                _receiptList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Receipt> Filtration(ref ObservableCollection<Receipt> Result)
        {
            switch (SelectedIndex)
            {
                case 1:
                    Result = Result.Where(p => p.ReceiptRDate.Date == DateTime.Today.Date).ToObservable();
                    break;
                case 2:
                    Result = Result.Where(p => p.ReceiptRDate.Date == DateTime.Now.AddDays(-1).Date).ToObservable(); ;
                    break;
                case 3:
                    Result = Result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddDays(-3).Date).ToObservable();
                    break;
                case 4:
                    Result = Result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddMonths(-1).Date).ToObservable();
                    break;
                case 5:
                    Result = Result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddMonths(-3).Date).ToObservable();
                    break;
                case 6:
                    Result = Result.Where(p => p.ReceiptRDate.Date <= DateTime.Now.AddYears(-1).Date).ToObservable();
                    break;
            }

            return Result;
        }
    }
}
