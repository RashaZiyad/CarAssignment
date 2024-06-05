using CarModel.Entities;
using CarModel.Service.Database;
using Microsoft.EntityFrameworkCore;

namespace CarModel.Repository;

public class CarModelRepository : ICarModelRepository
{
    private readonly DatabaseService _databaseService;
    private DbSet<CarMake> carModels;
    public CarModelRepository(DatabaseService databaseService) 
    {
        _databaseService = databaseService;
        carModels = databaseService.Set<CarMake>();
    }

    public async Task Save()
    {
        await _databaseService.SaveChangesAsync();
    }

    public async Task AddRange(List<CarMake> input)
    {
       await carModels.AddRangeAsync(input);
    }

    public async Task<List<CarMake>> Get(string makeId, string modelYear)
    {
        return await carModels.Where(x => x.MakeId  == makeId && x.ModelId == modelYear).ToListAsync();
    }
}
