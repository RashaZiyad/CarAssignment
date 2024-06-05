

using CarModel.Service;
using CarModel.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace CarModel.Controllers;

[ApiController]
[Route("carModel")]
public class CarModelController(ICarModelService carModelService) : ControllerBase
{
    private readonly ICarModelService carModelService = carModelService;

    [HttpPost]
    [Route("loadFile")]
    public async Task<IActionResult> LoadData(LoadExcelFileInput input)
    {
        return Ok(await carModelService.LoadData(input));
    }

    [HttpPost]
    [Route("getData")]
    public async Task<IActionResult> GetData(SearchCriteria input) // test
    {
        return Ok(await carModelService.GetData(input));
    }
}

