using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnlineShopAdmin.DataAccess.DbContexts;
using OnlineShopAdmin.Domain.Contracts;
using OnlineShopAdmin.Domain.Models;
using OnlineShopAdmin.Models;

namespace OnlineShopAdmin.Controllers
{
    public class ProductsController : Controller
    {
      
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;

        public ProductsController(IRepositoryWrapper repositoryWrapper,ILoggerManager logger)
        {
            _repository = repositoryWrapper ??
                throw new ArgumentNullException(nameof(repositoryWrapper));
            _logger = logger ??
             throw new ArgumentNullException(nameof(logger));
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = _repository.Product.GetAll().Include(p => p.ProductCategory)
                .Where(p => p.SalesOrderDetails.Count > 0)
                .OrderByDescending(p => p.ModifiedDate)
                .Take(20);

            var result = products.ToList();

            var lastOrders =
                from o in _repository.SalesOrderHeader.GetAll().Include(x => x.SalesOrderDetails)
                orderby o.OrderDate descending
                select o;

            ProductsViewModel model = new ProductsViewModel();

            model.Products = result;
            model.LastOrders = lastOrders.Take(20).ToList();

            _logger.LogInfo($"Showing {result.Count} products in Products/Index");

            return View(model);
        }

       
    }
}
