using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;




using System.Data.SqlClient;
using System.Data;
using RBJLLawFirmDBModel;


/// <summary>
/// Summary description for MaterItem2
/// </summary>
partial class MaterItem
{

    public OutgoingAgent getOutgoingAgent(int id)
    {
        var result = from q in db.OutgoingAgents
                     where q.id == id
                     select q;
        return result.First<OutgoingAgent>();
    }

    public Referer getReferer(int id)
    {
        var result = from q in db.Referers
                     where q.id == id
                     select q;
        return result.First<Referer>();
    }

    public DebitNoteCore getDebitNoteCores(Guid id)
    {
        var result = from q in db.DebitNoteCores
                     where q.id == id
                     select q;
        return result.First<DebitNoteCore>();
    }

    public OtherParty getOtherParties(int id)
    {
        var result = from q in db.OtherParties
                     where q.id == id
                     select q;
        return result.First<OtherParty>();
    }

    public View_FindMatter getView_FindMatter(string id)
    {
        Guid matterId = new Guid(id);
        var result = from q in db.View_FindMatter
                     where q.id == matterId
                     select q;
        return result.First<View_FindMatter>();
    }

    public MatterCore getMatterCore(string id)
    {
        Guid matterId = new Guid(id);
        var result = from q in db.MatterCores
                     where q.id == matterId
                     select q;
        return result.First<MatterCore>();
    }

    public JobType getJobType(int id)
    {
        var result = from q in db.JobTypes
                     where q.id == id
                     select q;
        return result.FirstOrDefault<JobType>();
    }

    public Client getClient(int id)
    {
        var result = from q in db.Clients
                     where q.id == id
                     select q;
        return result.First<Client>();
    }

    public DebitNoteCost getDebitNoteCosts(Guid id)
    {
        var result = from q in db.DebitNoteCosts
                     where q.debitNoteId == id
                     select q;
        if (result.Count<DebitNoteCost>() > 0) return result.First<DebitNoteCost>();
        else return null;
    }

    public DebitNoteDisbursement getDebitNoteDisbursements(Guid id)
    {
        var result = from q in db.DebitNoteDisbursements
                     where q.debitNoteId == id
                     select q;
        if (result.Count<DebitNoteDisbursement>() > 0) return result.First<DebitNoteDisbursement>();
        else return null;
    }

    public PricingType getPricingTypes(int id)
    {
        var result = from q in db.PricingTypes
                     where q.id == id
                     select q;
        if (result.Count<PricingType>() > 0) return result.First<PricingType>();
        else return null;
    }

    public string getPricingDetails(int id)
    {
        var result = from q in db.PricingDetails
                     where q.id == id
                     select q.detailsDescription;
        return result.First<string>();
    }

    public IQueryable<string> getClientNoAll()
    {
        var result = from q in db.Clients
                     select q.clientNum;
        return result;
    }

    public IQueryable<DebitNoteAttachment> getDebitNoteAttachmentsAll(Guid debitid)
    {
        var result = from q in db.DebitNoteAttachments
                     where q.debitNoteId == debitid
                     select q;
        return result;
    }

    public void deleteDebitNoteAttachmentsAll(Guid debitid)
    {
        var result = getDebitNoteAttachmentsAll(debitid);
        int count = result.Count<DebitNoteAttachment>();
        foreach (DebitNoteAttachment q in result)
        {
            db.DebitNoteAttachments.DeleteObject(q);

        }

        db.SaveChanges();
    }

    public IQueryable<string> getAttachmentsAll(Guid debitid)
    {
        var result = from q in db.DebitNoteAttachments
                     where q.debitNoteId == debitid
                     select q.filePath;
        return result;
    }

    public IQueryable<string> getDebitNoAll()
    {
        var result = from q in db.DebitNoteCores
                     select q.debitNoteNum;
        return result;
    }

    public IQueryable<string> getMatterNoAll()
    {
        var result = from q in db.MatterCores
                     select q.matterNum;
        return result;
    }

    public int cntClientNum(string clientNum)
    {
        var result = from q in db.Clients
                     where q.clientNum == clientNum
                     select q;
        return result.Count<Client>();
    }

    public int cntReferNum(string Num)
    {
        var result = from q in db.Referers
                     where q.refererNum == Num
                     select q;
        return result.Count<Referer>();
    }

    public int cntOtherpartiesNum(string Num)
    {
        var result = from q in db.OtherParties
                     where q.otherPartiesNum == Num
                     select q;
        return result.Count<OtherParty>();
    }

    public int cntOutgoingNum(string Num)
    {
        var result = from q in db.OutgoingAgents
                     where q.agentNum == Num
                     select q;
        return result.Count<OutgoingAgent>();
    }

    public int cntJobTypesNum(int Num)
    {
        var result = from q in db.JobTypes
                     where q.num == Num
                     select q;
        return result.Count<JobType>();
    }

    public int cntDebitNoteNum(string DebitNoteNum)
    {
        var result = from q in db.DebitNoteCores
                     where q.debitNoteNum == DebitNoteNum
                     select q;
        return result.Count<DebitNoteCore>();
    }



    private string datetimeToString(DateTime datetime)
    {
        string desdate = string.Format("{0:MM/dd/yyyy}", datetime);
        return desdate;
    }
    public IQueryable<UserLog> getUserLog(string date, Guid userId)
    {
        IQueryable<UserLog> result;

        if (date == "")
        {
            result = from q in db.UserLogs
                     where q.CreateByUserId == userId
                     select q;
        }

        else
        {
            //date += " 00:00:00.000";


            //DateTime datetime = Convert.ToDateTime(date);
            DateTime datetime = DateTimeHelper.convertStringToDateTime(date);
            //datetime = datetime.AddDays(-1);
            DateTime datetimeBef = datetime;
            DateTime datetimeAft = datetime.AddDays(1);
            //datetime = datetime.Date;
            //string desdate = datetime.ToShortDateString();
            //desdate = string.Format("{0:MM/dd/yyyy}", datetime);

            result = from q in db.UserLogs
                     where ((q.date > datetimeBef && q.date <= datetimeAft)) && q.CreateByUserId == userId
                     select q;
        }
        int count = result.Count<UserLog>();
        if (result.Count<UserLog>() > 0)
        {
            var rltTest = result.First<UserLog>();
        }

        result = result.OrderByDescending(p => p.date);

        return result;
    }






}