using System;
using System.Collections.Generic;

namespace KaniniStock.Domain.Models.SourceModels;

public partial class KcompanyDetail
{
    public string Companycode { get; set; } = null!;

    public decimal Closingshareprice { get; set; }

    public decimal Currenttradingprice { get; set; }

    public decimal Todayshigh { get; set; }

    public decimal TodayslOw { get; set; }

    public decimal _52whigh { get; set; }

    public decimal _52wlow { get; set; }

    public decimal Marketcapitalization { get; set; }

    public decimal Enterpricevalue { get; set; }

    public string Numberofshares { get; set; } = null!;

    public decimal Dividentyield { get; set; }

    public decimal Cash { get; set; }

    public string? Strength { get; set; }

    public string? Weakness { get; set; }

    public string? Opportunities { get; set; }

    public string? Threats { get; set; }

    public decimal Debt { get; set; }

    public decimal Facevalue { get; set; }

    public decimal Promoterholding { get; set; }
}
