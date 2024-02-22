using API.Contracts;
using API.Models;
using API.Services.Interfaces;

namespace API.Services
{
    public class GeneralService : IGeneralService
    {
        //private readonly IGeneralRepository _employeeRepository;

        //public GeneralService(IGeneralService employeeRepository)
        //{
        //    _employeeRepository = employeeRepository;
        //}
        //public async Task<IEnumerable<Employee>?> GetAllAsync()
        //{
        //    try
        //    {
        //        var data = await _employeeRepository.GettAllAsync();
        //        return data; //success
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
        //        throw; //error
        //    }
        //}


        //public async Task<Employee?> GetByIdAsync(Guid id)
        //{
        //    try
        //    {
        //        var data = await _employeeRepository.GetByIdAsync(id);
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
        //        throw;
        //    }
        //}

        //public async Task<int> CreateAsync(Employee employee)
        //{
        //    try
        //    {
        //        await _employeeRepository.CreateAsync(employee);

        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
        //        throw;
        //    }
        //}

        //public async Task<int> UpdateAsync(Guid id, Employee employee)
        //{
        //    try
        //    {
        //        var data = await _employeeRepository.GetByIdAsync(id);
        //        if (data is null)
        //        {
        //            return 0;
        //        }
        //        await _employeeRepository.UpdateAsync(data);
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
        //        throw;
        //    }
        //}

        //public async Task<int> DeleteAsync(Guid id)
        //{
        //    try
        //    {
        //        var data = await _employeeRepository.GetByIdAsync(id);
        //        if (data is null)
        //        {
        //            return 0;
        //        }
        //        await _employeeRepository.DeleteAsync(data);
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException?.Message ?? ex.Message, Console.ForegroundColor = ConsoleColor.Red);
        //        throw;
        //    }
        //}
    }
}
