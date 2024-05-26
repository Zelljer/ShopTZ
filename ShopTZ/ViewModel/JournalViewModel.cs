using ShopTZ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTZ.ViewModel
{
    public class JournalViewModel : JournalModel
    {
        private int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = value;
                Invalidate();
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

        private IEnumerable<Receipt> _ReceiptList = TZEntities.GetContext().Receipt.ToList();
        public IEnumerable<Receipt> ReceiptList
        {
            get
            {
                var Result = _ReceiptList;

                switch (SelectedIndex)
                {
                    case 1:
                        Result = Result.Where(p => p.ReceiptRDate.Date == DateTime.Today.Date).ToList();
                        break;
                    case 2:
                        Result = Result.Where(p => p.ReceiptRDate.Date == DateTime.Now.AddDays(-1).Date).ToList();
                        break;
                    case 3:
                        Result = Result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddDays(-3).Date).ToList();
                        break;
                    case 4:
                        Result = Result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddMonths(-1).Date).ToList();
                        break;
                    case 5:
                        Result = Result.Where(p => p.ReceiptRDate.Date >= DateTime.Now.AddMonths(-3).Date).ToList();
                        break;
                    case 6:
                        Result = Result.Where(p => p.ReceiptRDate.Date <= DateTime.Now.AddYears(-1).Date).ToList();
                        break;
                }

                return Result;
            }
            set
            {
                _ReceiptList = value;
                Invalidate();
            }
        }
    }
}
