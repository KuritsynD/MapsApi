using Maps.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Maps.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : ControllerBase
{
    private IRepairService RepairService { get; set; }
    private IBaseRepositry<Establishment> Establishments { get; set; }

    public MainController(IRepairService repairService, IBaseRepositry<Establishment> est)
    {
        RepairService = repairService;
        Establishments = est;
    }

    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(Establishments.GetAll());
    }
    
    [HttpPost]
    public JsonResult Post()
    {
        RepairService.Work();
        return new JsonResult("Work was successfully done");
    }

    [HttpPut]
    public JsonResult Put(Establishment est)
    {
        bool success = true;
        var establishment = Establishments.Get(est.Id);
        try
        {
            if (establishment!=null)
            {
                establishment = Establishments.Update(est);
            }
            else
            {
                success = false;
            }
        }
        catch (Exception e)
        {
            success = false;
        }

        return success
            ? new JsonResult($"Update successfull {establishment.Id}")
            : new JsonResult("Update was not successfull");
    }

    [HttpDelete]
    public JsonResult Delete(Guid Id)
    {
        bool success = true;
        var establishment = Establishments.Get(Id);
        try
        {
            if (establishment!=null)
            {
                Establishments.Delete(establishment.Id);
            }
            else
            {
                success = false;
            }
        }
        catch (Exception e)
        {
            success = false;
        }
        
        return success
            ? new JsonResult("Delete successfull")
            : new JsonResult("Delete was not successfull");
    }
    
}