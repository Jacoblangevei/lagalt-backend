using Lagalt_Backend.Data.Exceptions;
using Lagalt_Backend.Data.Models.OwnerModels;

namespace Lagalt_Backend.Services
{
    public interface ICrudService<TEntity, TID>
    {
        Task<ICollection<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TID id);
        /// <summary>
        /// Adds an <typeparamref name="TEntity"/> to the database.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity obj);

        /// <summary>
        /// Deletes an <typeparamref name="TEntity"/> by their ID.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <returns></returns>
        Task DeleteByIdAsync(TID id);

    }
}
