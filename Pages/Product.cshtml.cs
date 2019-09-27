using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace VitecProjekt.Pages
{
    [Authorize("Admin")]
    public class ProductModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}