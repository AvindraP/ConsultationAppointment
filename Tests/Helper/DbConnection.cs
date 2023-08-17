using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using ConsultationAppointment.Model;
using System.Data.Common;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
namespace Tests.Helper
{
    public static class TestDBConnection
    {
        public static DbContextOptions<AppDbContext> GetConnection()
        {
            DbContextOptions<AppDbContext> _dbContextOptions;
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connection = new MySqlConnection("DataSource:memory");
            connection.Open();
            _dbContextOptions = builder.UseMySql(connection, ServerVersion.AutoDetect(connection)).Options;
            return _dbContextOptions;
        }
    }
    
}