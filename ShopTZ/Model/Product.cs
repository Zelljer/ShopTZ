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
    
    public partial class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductUnit { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductCost { get; set; }
        public decimal ProductSummForProduction { get; set; }

        public int BuyCount { get; set; }
        public int BuyListId { get; set; }
        public decimal BuyCost { get; set; }
    }
}