using KmdProject.Api.Interfaces;
using KmdProject.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper.Contrib.Extensions;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KmdProject.Api.Repositories
{
    /// <summary>
    /// Should be located in another project dedicated for infrastracture or database.
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository 
    {
        public UserRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<IList<User>> GetList()
        {
            using (IDbConnection connection = Connection)
            {
                var result = await connection.GetAllAsync<User>();
                return result.ToList();
            }
        }

        public async Task DeleteAsync(long id)
        {
            using (IDbConnection connection = Connection)
            {
                await connection.DeleteAsync(new User { Id = id });
            }
        }

        public async Task<User> GetAsync(long id)
        {
            using (IDbConnection connection = Connection)
            {
                return await connection.GetAsync<User>(id);
            }
        }

        public async Task UpdateAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                await connection.UpdateAsync(user);
            }
        }

        public async Task InsertAsync(User user)
        {
            using (IDbConnection connection = Connection)
            {
                await connection.InsertAsync(user);
            }
        }
    }
}
