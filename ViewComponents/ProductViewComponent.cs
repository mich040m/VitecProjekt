using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitecProjekt.Areas.Identity.Data;

namespace VitecProjekt.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly VitecProjektContext _context;

        public ProductViewComponent(VitecProjektContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return  View();
            //var items = await GetItemsAsync(maxPriority, isDone);
            //return View(items);
        }
        //private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
        //{
        //    return db.ToDo.Where(x => x.IsDone == isDone &&
        //                         x.Priority <= maxPriority).ToListAsync();
        //}
    }
}
