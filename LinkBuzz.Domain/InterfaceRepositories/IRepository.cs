using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.InterfaceRepositories
{
    public interface IRepository<TEntity>
    {
        #region Get User InformaTion by keyword
        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByUsername(string username);

        Task<User> GetUserByPhoneNumber(string phoneNumber);
        #endregion
        #region Get Role, Add Roles
        Task AddUserToRoleAsync(User user, IEnumerable<string> listRoles);
        Task<IEnumerable<string>> GetRolesOfUserAsync(User user);
        #endregion
        #region GetAllAsync
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> property = null);
        Task<IQueryable<TEntity>> GetAllAsync(List<string> includes, Expression<Func<TEntity, bool>> property = null);
        Task<IQueryable<TEntity>> GetAllAsync(string include, Expression<Func<TEntity, bool>> property = null);
        #endregion
        #region GetByIdAsync
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdAsync(long id);
        Task<TEntity> GetByIdAsync(List<string> includes, Expression<Func<TEntity, bool>> prodecate = null);
        #endregion
        #region GetAsync
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> prodecate = null);
        #endregion
        #region DeleteAsync
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(long id);
        Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> prodecate = null);
        #endregion
        #region CreateAsync
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities);
        #endregion
        #region UpdateAsync
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
        Task<TEntity> UpdateAsync(long id, TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, params object[] keyValues);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);
        #endregion
    }
}
