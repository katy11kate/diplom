using WebApplication3.Models;
using System.Diagnostics;

namespace WebApplication3.Utils
{
    public class Database
    {
        //Scaffold-DbContext "Server=localhost;Database=database;Password=1234;User=root" "Pomelo.EntityFrameworkCore.MySql" -outputdir Models -context DatabaseContext
        public static ProjectContext Context { get; set; } = new ProjectContext();
    }
}
