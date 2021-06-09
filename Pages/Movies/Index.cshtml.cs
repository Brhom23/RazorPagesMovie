///لإنشاء الصفحات تلقائي بالسقالة اولا يجب عمل المجلد ثم اضافةسقالة جيدة
///إن لم تنجح عمل السقالة جيب مسح من النجت 
///Microsoft.VisualStudio.Web.CodeGeneration.Design
///ثم إضافتها من جديد ثم إعادة المحاولة مرة اخرى
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.MyContext _context;

        public IndexModel(RazorPagesMovie.Data.MyContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        //public async Task OnGetAsync()//يمك أن تكون OnGetAsync or OnGet
        //{
        //    Movie = await _context.Movie.ToListAsync();
        //}
        //ويمكن أن يكون الإرجاع نوع مثل صفحة الإنشاء وصفحة التعديل أو مثل التالي
        //يجب أن يتم إرجاع الصفحة
        //public async Task<IActionResult> OnGetAsync()//يمك أن تكون OnGetAsync or OnGet
        //{
        //    Movie = await _context.Movie.ToListAsync();
        //    return Page();
        //}

        //إضافةالبحث على القائمة
        //إن لم تكن searchString في المسار
        //https://localhost:44352/Movies?searchString=Ghost
        //إن كانت searchString في المسار
        //بالعبارة @page "{searchString?}"
        //https://localhost:44352/Movies/Ghost
        //وبعبارة أخرى
        //يستخدم وقت تشغيل ASP.NET Core
        //ربط النموذج لتعيين قيمة خاصية SearchString
        //من سلسلة الاستعلام (؟ searchString = Ghost)
        //أو بيانات المسار
        //(https: // localhost: 5001 / Movies / Ghost).
        //ربط النموذج ليس حساسًا لحالة الأحرف.
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        //public async Task OnGetAsync()
        //{
        //    var movies = from m in _context.Movie
        //                 select m;
        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        movies = movies.Where(s => s.Title.Contains(SearchString));
        //    }

        //    Movie = await movies.ToListAsync();
        //}
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
