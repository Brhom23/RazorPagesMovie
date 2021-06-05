using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages
{
    public class Index1Model : PageModel
    {
       

        public string Message { get; private set; } = "PageModel in C#";
        public void OnGet()
        {
            Message += $" Server time is { DateTime.Now }";
        }
        public int xxx() { return 50; }
    }
}
