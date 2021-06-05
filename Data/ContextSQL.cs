///يمكن لعبارة الإتصال أن تأتي من ملف خيارات جيسون appsettings.json
///appsettings.json
///أو من عبارة نصية
///ويمكن أن يتم تمرير العبارة كمعامل أثناء تكوين الكائن 
///سواء اتت من ملف خايرات جيسون أو من عبارة نصية في دالة 
///ConfigureServices
///في ملف Startup
///كما يمكن أن يتم تحديد عبارة الاتصال في الدالة OnConfiguring
///في هذا الملف. ويكون لها الأولوية في حال أن أتت العبارة 
///كمعامل أثناء الإنشاء
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class ContextSQL : DbContext
    {
        public ContextSQL (DbContextOptions<ContextSQL> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //الأولوية لهذا العبارة في حال أن عبارة الإتصال
            //أتت كمعامل أثناء الإنشاء في Startup
            //وهذه الأولوية حتى في الترحيل
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Movie2;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
