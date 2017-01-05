using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DebitNoteSubjectTDto
/// </summary>
public class DebitNoteSubjectTDto
{

    public Guid debitNoyeId { get; set; }
    public Guid matterId { get; set; }

    public string TTypeOfWork { get; set; }
    public string TIsOpponent { get; set; }
    public string TOpponentValue { get; set; }
    public string TRoleType { get; set; }
    public string TRoleTypeValue { get; set; }
    public string TrademarkLogo { get; set; }
    public string TrademarkNum { get; set; }
    public string TClass { get; set; }
    public string Country { get; set; }
    public string TrademarkLogoDescription { get; set; }
}