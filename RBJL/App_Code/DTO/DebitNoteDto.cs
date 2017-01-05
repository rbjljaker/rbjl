using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DebitNoteDto
/// </summary>
public class DebitNoteDto
{
    public string debitNoteNum { get; set; }
    public DateTime startDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? clientId { get; set; }
    public int? otherPartiesId { get; set; }
    public int? refererId { get; set; }
    public string address { get; set; }
    public string refDebitNote { get; set; }
    public string yourRefDebitNote { get; set; }
    public string status { get; set; }
    public int version { get; set; }
    public Guid matterNumId { get; set; }
    public string DebitNoteType { get; set; }
    public double price { get; set; }
    public bool isDiscount { get; set; }
    public string contactPersonList { get; set; }
    public string feeEarnerList { get; set; }
    public string handlingColleagueList { get; set; }
    public double discountValue { get; set; }
    public bool? isShowEmail { get; set; }
    public bool? customSortingCheckBox { get; set; }

    public string subject { get; set; }
    public string category { get; set; }

    public string billToName { get; set; }

    public string io { get; set; }
    public bool mustShowHeader { get; set; }

    //public string TTypeOfWork { get; set; }
    //public string TIsOpponent { get; set; }
    //public string TOpponentValue { get; set; }
    //public string TRoleType { get; set; }
    //public string TRoleTypeValue { get; set; }
    //public string TrademarkLogo { get; set; }
    //public string TrademarkNum { get; set; }
    //public string TClass { get; set; }
    //public string Country { get; set; }


    //public string PStageValue { get; set; }
    //public string PRoleProprietorApplican { get; set; }
    //public string PRoleProprietorApplicanValue { get; set; }
    //public string PAssignee { get; set; }
    //public string PTitle { get; set; }
    //public string PDesignOrPatentNum { get; set; }
    //public string PDesignOrPatentNumValue { get; set; }
    //public string PNationalPhase { get; set; }

    public string SubjectType { get; set; }

    public string CurrencySymbol { get; set; }

    public string subRef { get; set; }
    public double? depositAccount { get; set; }

    public string matterList { get; set; }


    public double? butSay { get; set; }
}
