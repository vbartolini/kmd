using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KmdProject.Api.Repositories
{
    /// <summary>
    /// Should be located in another project dedicated for infrastracture or database.
    /// </summary>
    public class BaseRepository
    {
        protected readonly IConfiguration _config;

        public BaseRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
