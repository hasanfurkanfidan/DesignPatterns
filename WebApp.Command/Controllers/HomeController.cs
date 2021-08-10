using BaseProject.DataAccess;
using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Command.Commands;
using WebApp.Command.Entities;

namespace BaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        public HomeController(ILogger<HomeController> logger,Context context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task< IActionResult >Index()
        {
            return View();
        }
        public async Task<IActionResult> Products()
        {
            return View(await _context.Products.ToListAsync());

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult>CreateFile(int type)
        {
            var products = await _context.Products.ToListAsync();



            FileCreateInvoker fileCreateInvoker = new();

            EFileType eFileType = (EFileType)type;

            switch (eFileType)
            {
                case EFileType.Excel:
                    var excelFile = new ExcelFile<Product>(products);
                    fileCreateInvoker.SetCommand(new CreateExcelTableActionCommand<Product>(excelFile));
                    break;
                case EFileType.Pdf:
                    var pdfFile = new PdfFile<Product>(products, HttpContext);
                    fileCreateInvoker.SetCommand(new CreatePdfFileActionCommand<Product>(pdfFile));
                    break;
                
            }
            return fileCreateInvoker.CreateFile();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
