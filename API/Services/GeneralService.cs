using API.Contracts;
using API.Models;
using API.Repositories;
using API.Services.Interfaces;

namespace API.Services
{
    public class GeneralService<TEntityRepo, TEntity> : IGeneralService<TEntityRepo, TEntity> 
        where TEntity : class where TEntityRepo : IGeneralRepository<TEntity>
    {
        private readonly TEntityRepo _repository;

        public GeneralService(TEntityRepo repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            try
            {
                var data = await _repository.GetAllAsync();
                return data; //success
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw; //error
            }
        }


        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await _repository.GetByIdAsync(id);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            try
            {
                await _repository.CreateAsync(entity);

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> UpdateAsync(Guid id, TEntity entity)
        {
            try
            {
                var data = await _repository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _repository.UpdateAsync(data);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                var data = await _repository.GetByIdAsync(id);
                if (data is null)
                {
                    return 0;
                }
                await _repository.DeleteAsync(data);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
                throw;
            }
        }
    }
}
