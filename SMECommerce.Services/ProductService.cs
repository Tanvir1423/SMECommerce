using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories;
using SMECommerce.Repositories.Abstractions;
using SMECommerce.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMECommerce.Services
{
    public class ProductService : Service<Item>, IProductService
    {
        IProductRepository _itemRepository;

        public ProductService(IProductRepository itemRepository): base(itemRepository)
        {
            _itemRepository = itemRepository;
        }


    }
}
