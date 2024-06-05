using CarModel.Entities;
using CarModel.Repository;
using CarModel.Service.Model;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace CarModel.Service;

public class CarModelService : ICarModelService
{
    public ICarModelRepository carModelRepository;

    public CarModelService(ICarModelRepository carModelRepository)
    {
        this.carModelRepository = carModelRepository;
    }

    public async Task<List<Result>> GetData(SearchCriteria input)
    {
        var response = await carModelRepository.Get(input.MakeID, input.ModelYear);

        if (response is null)
        {
            return null;
        }

        return response.ConvertAll(data => new Result
        {
            MakeId = data.MakeId,
            MakeName = data.MakeName,
            ModelId = data.ModelId,
            ModelName = data.ModelName
        });
    }

    public async Task<string> LoadData(LoadExcelFileInput input)
    {
        if (input.File == null || input.File.Length <= 0)
        {
            return "no file added, Please upload the file";
        }
        if (input.File.FileName.EndsWith("xls", StringComparison.OrdinalIgnoreCase))
        {
            return "the file added is not in the correct format";
        }

        try
        {
            using var stream = input.File.OpenReadStream();
            using var package = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var workbook = package.Workbook;
            foreach (var worksheetData in workbook.Worksheets)
            {
                var worksheet = workbook?.Worksheets[worksheetData.Index];
                var dataLines = worksheet?.Dimension.End.Row;
                var carData = new List<CarMake>();

                for (int row = 2; row <= dataLines; row++)
                {
                    if (!string.IsNullOrWhiteSpace(worksheet?.Cells[row, 1]?.Value?.ToString()))
                    {
                        var data = new CarMake()
                        {
                            MakeId = worksheet.Cells[row, 1].Value.ToString(),
                            MakeName = worksheet.Cells[row, 2].Value.ToString(),
                            ModelId = worksheet.Cells[row, 3].Value.ToString(),
                            ModelName = worksheet.Cells[row, 4].Value.ToString()
                        };
                        carData.Add(data);
                    }

                }
                if (carData.Count > 0)
                {
                    await carModelRepository.AddRange(carData);
                }
            }
            await carModelRepository.Save();
            return "Ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
