﻿using BigWeb.DataAccess.Data;
using BigWeb.DataAccess.Repository.IRepository;
using BigWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BigWebBook.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "CategoryName");
            return View(products);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Product product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "CategoryName");
                return View(product);
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}