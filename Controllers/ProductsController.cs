using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VitecProjekt.Models;
using Newtonsoft.Json;

namespace VitecProjekt.Controllers
{
    public class ProductsController : Controller
    {
        private readonly VitecProjektModelsContext _context;

        public ProductsController(VitecProjektModelsContext context)
        {
            _context = context;
        }

        // GET: Products
        public IActionResult Index()
        {
            
            string json;
            using (WebClient client = new WebClient() )
            {
                json = client.DownloadString("https://vitecprojekt.azurewebsites.net/api/productsApi");
            }

            return View(JsonConvert.DeserializeObject<IEnumerable<Product>>(json).ToList()) ;
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = ProductExists(id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ProductName,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(product);
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    client.UploadString("https://vitecprojekt.azurewebsites.net/api/productsApi", "POST", json);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = ProductExists(id);
            if (product != null)
            {
                return View(product);
            }
            return NotFound();

        }



        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,ProductName,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        client.UploadString("https://vitecprojekt.azurewebsites.net/api/productsApi/" + id, "PUT", JsonConvert.SerializeObject(product));
                    }
                }
                catch (Exception)
                {
                   
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // DELETE: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (WebClient client = new WebClient())
            {
                
                client.UploadString("https://vitecprojekt.azurewebsites.net/api/productsApi/" + id, "DELETE",string.Empty);
            }

            return RedirectToAction(nameof(Index));
        }

        private Product ProductExists(int? id)
        {
            string json;
            using (WebClient client = new WebClient())
            {

                json = client.DownloadString("https://vitecprojekt.azurewebsites.net/api/productsApi");
            }
            List<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json).ToList();
            foreach (var item in products)
            {
                if (item.Id == id)
                {
                    return item;
                }

            }
            return null;
        }


    }
}
