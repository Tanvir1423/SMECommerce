using Microsoft.EntityFrameworkCore;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace SMECommerce.Repositories
{
    public class ProductRepository : Repository<Item>, IProductRepository
    {
        SMECommerceDbContext db;
        public ProductRepository(SMECommerceDbContext db) : base(db)
        {
            this.db = db;
        }
        public override Item GetById(int id)
        {
            return db.Products.Include(c => c.Category)
                .FirstOrDefault(e => e.Id == id);

        }

        public override ICollection<Item> GetAll()
        {
            return db.Products.Include(c => c.Category).ToList();

        }

        public ICollection<Item> GetAllItemByCategory(int categoryId)
        {
            return db.Products.Include(c => c.Category).Where(e => e.CategoryId == categoryId).ToList();
        }
    }
}

