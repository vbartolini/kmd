using KmdProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KmdProject.Api.Interfaces
{
    /// <summary>
    /// Should be located in another project dedicated for interfaces.
    /// </summary>
    public interface IUserRepository
    {
        Task<IList<User>> GetList();
        Task InsertAsync(User user);
        Task<User> GetAsync(long id);
        Task DeleteAsync(long id);
        Task UpdateAsync(User user);
    }
}
