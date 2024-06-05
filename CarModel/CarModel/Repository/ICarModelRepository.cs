using CarModel.Entities;

namespace CarModel.Repository
{
    public interface ICarModelRepository
    {
        Task AddRange(List<CarMake> input);
        Task<List<CarMake>> Get(string makeId, string modelYear);
        Task Save();
    }
}