﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TZEntities : DbContext
    {
        public TZEntities()
            : base("name=TZEntities")
        {
        }

        public static TZEntities _context;
        public static TZEntities GetContext()
        {
            if (_context == null)
                _context = new TZEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
