using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMECommerce.App.Models.ProductModels;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories;
using SMECommerce.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Controllers
{
    public class ProductController : Controller
    {
        //ProductRepository _itemRepository;
        //CategoryRepository _categoryRepository;
        IProductService _itemService;
        ICategoryService _categoryService;
        IMapper _mapper;

        public ProductController(IProductService itemService, ICategoryService categoryService, IMapper mapper)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public string Index()
        {
            return "Controller";
        }
        public IActionResult Create()
        {
            ProductCreate itemList = new ProductCreate();

            itemList.categoryList = _categoryService.GetAll().ToList();
            return View(itemList);
        }

        [HttpPost]
        public IActionResult Create(ProductCreate model)
        {

            if (model.Name != null)
            {
                //var item = new Item()
                //{
                //    Name = model.Name,
                //    Price = model.Price,
                //    Code = model.Code,
                //    ManufacturerDate= model.ManufactureDate,
                //    Description = model.Description,
                //    CategoryId = model.CategoryId
                //}

                var item = _mapper.Map<Item>(model);

                var isAdded = _itemService.Add(item);
          
            if (isAdded)
            {
                return RedirectToAction("List");
            }
            
        }

            return View();
    }

      

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            var item = _itemService.GetById((int)id);

            if (item == null)
            {
                return RedirectToAction("List");
            }

            var itemEditVM = new ProductEditVM()
            {
                Id = item.Id,
                Name = item.Name,
                Code = item.Code,
                ManufactureDate= item.ManufacturerDate,
                Price = item.Price,
                Description = item.Description,
                categoryList = _categoryService.GetAll().ToList()
            };

            return View(itemEditVM);

        }

        [HttpPost]
        public IActionResult Edit(ProductEditVM model)
        {
            if (ModelState.IsValid)
            {
                //var item = new Item()
                //{
                //    Id = model.Id,
                //    Name = model.Name,
                //    Code = model.Code,
                //    Price = model.Price,
                //    ManufacturerDate = model.ManufactureDate,
                //    Description = model.Description,
                //    CategoryId = model.CategoryId,


                //};
                var item = _mapper.Map<Item>(model);

                bool isUpdated = _itemService.Update(item);
                if (isUpdated)
                {
                    return RedirectToAction("List");
                }
            }
            

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            var item = _itemService.GetById((int)id);
            if (item == null)
            {
                return RedirectToAction("CategoryList");
            }

            bool isRemoved = _itemService.Remove(item);

            if (isRemoved)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }


        public IActionResult List()
        {
            var itemList = _itemService.GetAll();

            var itemListVm = new ProductListVM()
            {
                Title = "Product Overview",
                Description = "You can manage products from this page, you can create update, delete products...",
                ProductList = itemList.ToList()
            };

            return View(itemListVm);


        }
        public IActionResult Details(int? id)
        {
            var item = _itemService  .GetById((int)id);

            var itemDetails = new ProductDetailsVM()
            {
                Code = item.Code,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                ManufactureDate=item.ManufacturerDate,
                CategoryId = item.Category.Name


               
            };
            return View(itemDetails);
        }

        //public string ProductListCreate(ProductCreate[] items)
        //{
        //    string data = "Product List Create" + Environment.NewLine;
        //    if (items != null && items.Any())
        //    {
        //        foreach (var item in items)
        //        {
        //            data += $"Product Create: {item.Name} Code: {item.Code}" + Environment.NewLine;
        //        }
        //    }

        //    return data;
        //}
    }
}
