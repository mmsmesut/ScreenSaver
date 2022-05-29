using ScreenSaver.Entity;
using SqlConnectionConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver.Data
{
    public class SccreenSaverDbContext : DbContext
    {
        public SccreenSaverDbContext(string connectionString) : base(connectionString)
        {

        }

        public SccreenSaverDbContext() : base(SqlConnectionConfiguration.ConnectionStringScreenSaver)
        {

        }

        public DbSet<ScreenShot> ScreenShots { get; set; }
    }

}
