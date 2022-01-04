using AutoMapper;
using SMECommerce.App.Models.CategoryModels;
using SMECommerce.App.Models.ProductModels;
using SMECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Profiles
{
    public class AppAutomapperProfile : Profile
    {
        public AppAutomapperProfile()
        {
            CreateMap<CategoryCreate, Category>();
            CreateMap<CategoryEditVm, Category>();
            CreateMap<Category, CategoryCreate>();
            CreateMap<Category, CategoryEditVm>();
            CreateMap<Item, ProductCreate>();
            CreateMap<Item, ProductEditVM>();
            CreateMap<ProductCreate, Item>();
            CreateMap<ProductEditVM, Item>();

        }
    }
}
