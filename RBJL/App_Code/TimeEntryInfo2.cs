using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;

using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for TimeEntryInfo2
/// </summary>
partial class TimeEntryInfo
{
    public void delMatterDetails(int id)
    {



       MatterDetail md=  getEntityById(id);
      db.MatterDetails.DeleteObject(md);
        db.SaveChanges();

    }

    private MatterCore getMatterCore(Guid id)
    {
        return db.MatterCores.Where(p => p.id == id).FirstOrDefault();
    }

    private DebitNoteCore getDebitnotecore(string debitnum)
    {
        return db.DebitNoteCores.Where(p => p.debitNoteNum == debitnum).FirstOrDefault();
    }


    public void editMattercore(Guid id, string status)
    {
        MatterCore matterCore = getMatterCore(id);
        matterCore.status = status;
        db.SaveChanges();
    }
    public void editMattercore(DebitNoteDto dN)
    {
        DebitNoteCore add = getDebitnotecore(dN.debitNoteNum);
                add.startDate = dN.startDate;
        add.endDate = dN.EndDate;
        //add.clientId = dN.clientId;
        add.otherPartiesId = dN.otherPartiesId;
        //add.refererId = dN.refererId;
        add.address = dN.address;
        add.@ref = dN.refDebitNote;
        add.yourRef = dN.yourRefDebitNote;
        //add.status = dN.status;
        //add.version = dN.version;
        //add.matterNumId = dN.matterNumId;
        add.debitNoteType = dN.DebitNoteType;
        //add.price = dN.price;
        //add.isDiscount = dN.isDiscount;
      db.SaveChanges();
    }
}