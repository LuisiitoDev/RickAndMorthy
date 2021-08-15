using Microsoft.Extensions.Configuration;
using RickAndMorthy.Data.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickAndMorthy.Data.Repository
{
    public class FavoriteRepository
    {
        readonly SQLiteAsyncConnection DataBase;

        public FavoriteRepository(IConfiguration configuration)
        {
            DataBase = DataConfiguration.GetSQLiteAsyncConnection(configuration);
        }

        /// <summary>
        /// it allows to get all favorites chracters stored
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Favorite>> GetAllFavoritesAsync()
        {
            return await this.DataBase.Table<Favorite>().ToListAsync();
        }

        /// <summary>
        /// it allows to add a favorite character
        /// </summary>
        /// <param name="favorite"></param>
        /// <returns></returns>
        public async Task AddFavoriteAsync(Favorite favorite)
        {
            await this.DataBase.InsertAsync(favorite);
        }

        /// <summary>
        /// it allows to 
        /// </summary>
        /// <param name="favorite"></param>
        /// <returns></returns>
        public async Task RemoveFavoriteAsync(Favorite favorite)
        {
            await this.DataBase.DeleteAsync(favorite);
        }    
    }
}
