using CarModel.Service.Model;

namespace CarModel.Service;

public interface ICarModelService
{
    Task<string> LoadData(LoadExcelFileInput input);
    Task<List<Result>> GetData(SearchCriteria input);
}