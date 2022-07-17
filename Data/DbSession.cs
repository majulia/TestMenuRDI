using System.Data;
using System.Data.SqlClient;

namespace TestMenu.Data
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(
                configuration.GetConnectionString("DefaultConnection"));
        }

    
        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
