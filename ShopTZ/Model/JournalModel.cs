using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTZ.Model
{
    public class JournalModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Invalidate()
        {
            if (PropertyChanged != null)
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReceiptList"));
        }
    }
}
