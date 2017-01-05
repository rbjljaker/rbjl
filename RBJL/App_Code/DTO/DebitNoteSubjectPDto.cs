using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DebitNoteSubjectPDto
/// </summary>
public class DebitNoteSubjectPDto
{
    public Guid debitNoyeId { get; set; }
    public Guid matterId { get; set; }

    public string PStageValue { get; set; }
    public string PRoleProprietorApplican { get; set; }
    public string PRoleProprietorApplicanValue { get; set; }
    public string PAssignee { get; set; }
    public string PTitle { get; set; }
    public string PDesignOrPatentNum { get; set; }
    public string PDesignOrPatentNumValue { get; set; }
    public string PNationalPhase { get; set; }
    public string Country { get; set; }

    public string PPriorityValue { get; set; }

}