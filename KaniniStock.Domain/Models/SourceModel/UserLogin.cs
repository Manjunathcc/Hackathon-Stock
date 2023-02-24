using System;
using System.Collections.Generic;

namespace KaniniStock.Domain.Models.SourceModels;

public partial class UserLogin
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
