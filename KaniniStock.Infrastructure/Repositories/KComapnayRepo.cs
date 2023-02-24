using KaniniStock.Domain.IRepoInterfaces;
using KaniniStock.Domain.Models.SourceModels;

namespace KaniniStock.Infrastructure.Repositories;

public class KComapnayRepo : IKCompany
{
    private readonly KaninistockPickerContext dbcontext;
    public KComapnayRepo(KaninistockPickerContext dbcontext)
    {
        this.dbcontext = dbcontext;

    }

    public List<KcompanyPicker> GetCompaniess(string companyname)
    {
        var companydetails = this.dbcontext.KcompanyPickers.Where(p => p.CompanyName.StartsWith(companyname)).ToList();
        return companydetails;
    }

    public KcompanyDetail GetCompanyDetail(string companyname)
    {
        KcompanyDetail companydetails = this.dbcontext.KcompanyDetails.Find(companyname);
        return companydetails;

    }
}
