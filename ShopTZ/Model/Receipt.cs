//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopTZ.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Receipt
    {
        public int ReceiptID { get; set; }
        public int ReceiptBuyer { get; set; }
        public string ReceiptDate { get; set; }
        public Nullable<decimal> ReceiptSumm { get; set; }
        public string ReceiptProducts { get; set; }
    
        public virtual User User { get; set; }

        public DateTime ReceiptRDate
        {
            get
            {
                return DateTime.Parse(ReceiptDate);
            }
        }
    }
}
