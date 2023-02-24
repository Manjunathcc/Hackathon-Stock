using KaniniStock.Domain.Models.SourceModels;

namespace KaniniStock.Domain.IRepoInterfaces;

public interface IKCompany
{
    KcompanyDetail GetCompanyDetail(string companyname);

    List<KcompanyPicker> GetCompaniess(string companyname);


}
