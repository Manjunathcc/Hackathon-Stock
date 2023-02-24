using System;
using System.Collections.Generic;

namespace KaniniStock.Domain.Models.SourceModels;

public partial class KcompanyPicker
{
    public string? CompanyName { get; set; }

    public string CompanyCode { get; set; } = null!;

    public int? ViewCount { get; set; }
}
