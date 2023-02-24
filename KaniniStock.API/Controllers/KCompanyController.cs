using KaniniStock.Domain.IRepoInterfaces;
using KaniniStock.Domain.Models.SourceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KaniniStock.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class KCompanyController : ControllerBase
{
    private readonly IKCompany iKCompany;
    public  KCompanyController(IKCompany iKCompany)
    {
        this.iKCompany = iKCompany;
    }
    
    [HttpGet]
    [Route("GetCompanyDetails")]
    public async Task<ActionResult<KcompanyDetail>> GetCompanyDetails(string companyname)
    {
        var companydetails = this.iKCompany.GetCompanyDetail(companyname);
        if (companydetails != null)
        {
            return Ok(companydetails);
        }
        else
            return NotFound();
    }

    [HttpGet]
    [Route("GetCompanies")]

    public async Task<ActionResult<List<KcompanyDetail>>> GetCompanies(string companyname)
    {
        var companydetails = this.iKCompany.GetCompaniess(companyname);
        if (companydetails != null)
        {
            return Ok(companydetails);
        }
        else
            return NotFound();
    }
}
