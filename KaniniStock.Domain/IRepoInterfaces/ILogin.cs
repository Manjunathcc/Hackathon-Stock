using KaniniStock.Domain.Models.SourceModels;

namespace KaniniStock.Domain.IRepoInterfaces;

public interface ILogin
{
    string Login(UserLogin user);

}
