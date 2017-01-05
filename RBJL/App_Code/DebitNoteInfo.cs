using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;
using System.Data;
using GeneralUtilities;
using System.Collections;
using System.IO;

/// <summary>
/// Summary description for DebitNoteInfo
/// </summary>
public class DebitNoteInfo : DBEntity
{
    public DebitNoteInfo()
        : base()
    {
    }

    public DebitNoteInfo(string userName)
        : base(userName)
    {

    }


    public void addDebitNoteCore(DebitNoteDto dN)
    {
        SessionClass.Identity = Guid.NewGuid().ToString();
        Guid id = new Guid(SessionClass.Identity);
        DebitNoteCore add = new DebitNoteCore();
        add.id = id;
        add.mustShowHeader=dN.mustShowHeader;

        if (!String.IsNullOrEmpty(dN.debitNoteNum))
        {
            add.debitNoteNum = dN.debitNoteNum;
        }
        add.startDate = dN.startDate;
        add.endDate = dN.EndDate;
        if (dN.clientId.HasValue)
        {
            add.clientId = dN.clientId.Value;
        }
        if (dN.otherPartiesId.HasValue)
        {
            add.otherPartiesId = dN.otherPartiesId.Value;
        }
        if (dN.refererId.HasValue)
        {
            add.refererId = dN.refererId.Value;
        }

        add.billTo = dN.billToName;
        add.address = dN.address;
        add.@ref = dN.refDebitNote;
        add.yourRef = dN.yourRefDebitNote;
        add.status = dN.status;
        add.version = dN.version;
        add.matterNumId = dN.matterNumId;
        add.debitNoteType = dN.DebitNoteType;
        add.price = dN.price;
        add.isDiscount = dN.isDiscount;
        add.DiscountValue = dN.discountValue;
        add.feeEarnerList = dN.feeEarnerList;
        add.HandlingColleagueList = dN.handlingColleagueList;
        add.contactPersonList = dN.contactPersonList;

        if (dN.isShowEmail.HasValue)
        {
            add.isEnable = dN.isShowEmail.Value;
        }
        if (dN.customSortingCheckBox.HasValue)
        {
            add.customSortingCheckBox = dN.customSortingCheckBox.Value;
        }

        add.category = dN.category;
        add.ioNum = dN.io;

        add.CreateDate = DateTime.Now;
        add.UpdateDate = DateTime.Now;
        add.CreateByUserId = base.userGuid;
        add.UpdateByUserId = base.userGuid;

        //add.hourlyRateD = dN.hourlyRate;

        add.SubjectType = dN.SubjectType;

        //add.TTypeOfWork = dN.TTypeOfWork;
        //add.TIsOpponent = dN.TIsOpponent;
        //add.TOpponentValue = dN.TOpponentValue;
        //add.TRoleType = dN.TRoleType;
        //add.TRoleTypeValue = dN.TRoleTypeValue;
        //add.TrademarkLogo = dN.TrademarkLogo;
        //add.TrademarkNum = dN.TrademarkNum;
        //add.TClass = dN.TClass;


        //add.PStageValue = dN.PStageValue;
        //add.PRoleProprietorApplican = dN.PRoleProprietorApplican;
        //add.PRoleProprietorApplicanValue = dN.PRoleProprietorApplicanValue;
        //add.PAssignee = dN.PAssignee;
        //add.PTitle = dN.PTitle;
        //add.PDesignOrPatentNum = dN.PDesignOrPatentNum;
        //add.PDesignOrPatentNumValue = dN.PDesignOrPatentNumValue;
        //add.PNationalPhase = dN.PNationalPhase;


        //add.Country = dN.Country;
        add.subject = dN.subject;

        add.CurrencySymbol = dN.CurrencySymbol;

        add.subRef = dN.subRef;

        add.matterNumIdList = dN.matterList;

        if (dN.depositAccount.HasValue)
        {
            add.depositAccount = dN.depositAccount.Value;
        }

        if (dN.butSay.HasValue)
        {
            add.butSay = dN.butSay.Value;
        }



        db.DebitNoteCores.AddObject(add);
        db.SaveChanges();

        if (String.IsNullOrEmpty(add.debitNoteNum))
        {
            base.addLog(String.Format(LogConst.createDebitNotePendding));
        }
        else
        {
            base.addLog(String.Format(LogConst.createDebitNote, add.debitNoteNum));
        }
    }


    public void addDebitNoteCore(DebitNoteDto dN, Guid id)
    {

        DebitNoteCore add = new DebitNoteCore();
        add.id = id;
        add.mustShowHeader = dN.mustShowHeader;

        if (!String.IsNullOrEmpty(dN.debitNoteNum))
        {
            add.debitNoteNum = dN.debitNoteNum;
        }
        add.startDate = dN.startDate;
        add.endDate = dN.EndDate;
        if (dN.clientId.HasValue)
        {
            add.clientId = dN.clientId.Value;
        }
        if (dN.otherPartiesId.HasValue)
        {
            add.otherPartiesId = dN.otherPartiesId.Value;
        }
        if (dN.refererId.HasValue)
        {
            add.refererId = dN.refererId.Value;
        }

        add.billTo = dN.billToName;
        add.address = dN.address;
        add.@ref = dN.refDebitNote;
        add.yourRef = dN.yourRefDebitNote;
        add.status = dN.status;
        add.version = dN.version;
        add.matterNumId = dN.matterNumId;
        add.debitNoteType = dN.DebitNoteType;
        add.price = dN.price;
        add.isDiscount = dN.isDiscount;
        add.DiscountValue = dN.discountValue;
        add.feeEarnerList = dN.feeEarnerList;
        add.HandlingColleagueList = dN.handlingColleagueList;
        add.contactPersonList = dN.contactPersonList;

        add.category = dN.category;
        add.ioNum = dN.io;

        add.CreateDate = DateTime.Now;
        add.UpdateDate = DateTime.Now;
        add.CreateByUserId = base.userGuid;
        add.UpdateByUserId = base.userGuid;


        if (dN.isShowEmail.HasValue)
        {
            add.isEnable = dN.isShowEmail.Value;
        }
        if (dN.customSortingCheckBox.HasValue)
        {
            add.customSortingCheckBox = dN.customSortingCheckBox.Value;
        }

        //add.hourlyRateD = dN.hourlyRate;

        add.SubjectType = dN.SubjectType;

        //add.TTypeOfWork = dN.TTypeOfWork;
        //add.TIsOpponent = dN.TIsOpponent;
        //add.TOpponentValue = dN.TOpponentValue;
        //add.TRoleType = dN.TRoleType;
        //add.TRoleTypeValue = dN.TRoleTypeValue;
        //add.TrademarkLogo = dN.TrademarkLogo;
        //add.TrademarkNum = dN.TrademarkNum;
        //add.TClass = dN.TClass;


        //add.PStageValue = dN.PStageValue;
        //add.PRoleProprietorApplican = dN.PRoleProprietorApplican;
        //add.PRoleProprietorApplicanValue = dN.PRoleProprietorApplicanValue;
        //add.PAssignee = dN.PAssignee;
        //add.PTitle = dN.PTitle;
        //add.PDesignOrPatentNum = dN.PDesignOrPatentNum;
        //add.PDesignOrPatentNumValue = dN.PDesignOrPatentNumValue;
        //add.PNationalPhase = dN.PNationalPhase;


        //add.Country = dN.Country;

        add.subject = dN.subject;

        add.CurrencySymbol = dN.CurrencySymbol;

        add.subRef = dN.subRef;

        add.matterNumIdList = dN.matterList;

        if (dN.depositAccount.HasValue)
        {
            add.depositAccount = dN.depositAccount.Value;
        }

        if (dN.butSay.HasValue)
        {
            add.butSay = dN.butSay.Value;
        }


        db.DebitNoteCores.AddObject(add);
        db.SaveChanges();

        if (String.IsNullOrEmpty(add.debitNoteNum))
        {
            base.addLog(String.Format(LogConst.createDebitNotePendding));
        }
        else
        {
            base.addLog(String.Format(LogConst.createDebitNote, add.debitNoteNum));
        }
    }

    //public void addDebitNoteCost(DebitNoteCostAndDisbursementDto dNCAD)
    //{
    //    //Guid id = new Guid(SessionClass.Identity);
    //    //DebitNoteCost add = new DebitNoteCost();
    //    //add.debitNoteId = id;

    //}
    public void addDebitNoteCostAndDisbursement()
    {
        Guid id = new Guid(SessionClass.Identity);
        DataTable dt = SessionClass.DebitNoteCostDataTable;
        if (dt != null)
        {
            foreach (DataRow dtRow in dt.Rows)
            {
                DebitNoteCost add = new DebitNoteCost();
                add.debitNoteId = id;
                add.templateType = Convert.ToString(dtRow[DataTableConst.TemplateId]);
                add.templateDetails = Convert.ToString(dtRow[DataTableConst.TemplateValue]);
                double costValue;
                bool checkCost = Double.TryParse(dtRow[DataTableConst.Cost].ToString(), out costValue);
                if (checkCost)
                {
                    add.cost = costValue;
                }

                int tempCostOrder;
                bool checingIntCostOrder = Int32.TryParse(dtRow[DataTableConst.Order].ToString(), out tempCostOrder);

                if (checingIntCostOrder)
                {
                    add.orderByValue = tempCostOrder;
                }

                var getFeeEarnerId = Convert.ToString(dtRow[DataTableConst.FeeEarner]);
                if (!String.IsNullOrEmpty(getFeeEarnerId))
                {
                    add.UpdateByUserId = new Guid(getFeeEarnerId);
                }

                add.description = Convert.ToString(dtRow[DataTableConst.Description]);
                db.DebitNoteCosts.AddObject(add);
                db.SaveChanges();
            }
        }

        DataTable dtMisc = SessionClass.DebitNoteMiscDataTable;

        if (dtMisc != null)
        {
            foreach (DataRow dtRow in dtMisc.Rows)
            {
                DebitNoteMisc add = new DebitNoteMisc();
                add.debitNoteId = id;
                add.templateType = Convert.ToString(dtRow[DataTableConst.TemplateId]);
                add.templateDetails = Convert.ToString(dtRow[DataTableConst.TemplateValue]);
                double miscValue;
                bool checkMisc = Double.TryParse(dtRow[DataTableConst.Cost].ToString(), out miscValue);
                if (checkMisc)
                {
                    add.cost = miscValue;
                }

                int tempMiscOrder;
                bool checingIntmiscOrder = Int32.TryParse(dtRow[DataTableConst.Order].ToString(), out tempMiscOrder);

                if (checingIntmiscOrder)
                {
                    add.orderByValue = tempMiscOrder;
                }

                add.description = Convert.ToString(dtRow[DataTableConst.Description]);
                db.DebitNoteMiscs.AddObject(add);
                db.SaveChanges();
            }
        }

        DataTable dtDisbursement = SessionClass.DebitNoteDisbursementDataTable;

        if (dtDisbursement != null)
        {
            foreach (DataRow dtRow in dtDisbursement.Rows)
            {
                DebitNoteDisbursement add = new DebitNoteDisbursement();
                add.debitNoteId = id;
                add.templateType = Convert.ToString(dtRow[DataTableConst.TemplateId]);
                add.templateDetails = Convert.ToString(dtRow[DataTableConst.TemplateValue]);
                double disbursementValue;
                bool checkDisbursement = Double.TryParse(dtRow[DataTableConst.Cost].ToString(), out disbursementValue);
                if (checkDisbursement)
                {
                    add.cost = disbursementValue;
                }

                int tempDisbursementOrder;
                bool checingIntdisbursementOrder = Int32.TryParse(dtRow[DataTableConst.Order].ToString(), out tempDisbursementOrder);

                if (checingIntdisbursementOrder)
                {
                    add.orderByValue = tempDisbursementOrder;
                }

                add.description = Convert.ToString(dtRow[DataTableConst.Description]);
                db.DebitNoteDisbursements.AddObject(add);
                db.SaveChanges();
            }
        }
    }

    public void addDebitNoteNarrative(MatterDetailDto mDD)
    {
        Guid id = new Guid(SessionClass.Identity);

        DebitNoteNarrative dNN = new DebitNoteNarrative();

        dNN.matterDetailsId = mDD.id;
        dNN.itemNum = mDD.itemNum;
        dNN.date = mDD.date;
        dNN.feeEarner = mDD.feeEarner;
        dNN.timespan = mDD.timeSpan;
        dNN.fixedCost = mDD.fixedCost;
        dNN.templateType = mDD.templateType;
        dNN.templateDescription = mDD.templateDescription;
        dNN.description = mDD.description;
        dNN.hourlyRateH = mDD.hourlyRateH;

        dNN.fixedCostTimeSpan = mDD.fixedCostTimeSpan;

        if (mDD.isCountTotal.HasValue)
        {
            dNN.isCountTotal = mDD.isCountTotal.Value;
        }

        dNN.debitNoteId = id;
        dNN.CreateDate = DateTime.Now;
        dNN.CreateByUserId = base.userGuid;

        db.DebitNoteNarratives.AddObject(dNN);
        db.SaveChanges();
    }


    public void addDebitNoteAttachment(string filePath)
    {
        Guid id = new Guid(SessionClass.Identity);

        DebitNoteAttachment dNA = new DebitNoteAttachment();
        dNA.debitNoteId = id;
        dNA.filePath = filePath;
        db.DebitNoteAttachments.AddObject(dNA);
        db.SaveChanges();
    }

    public void addDebitNoteAttachment(string filePath, string debitNoteId)
    {
        Guid id = new Guid(debitNoteId);

        DebitNoteAttachment dNA = new DebitNoteAttachment();
        dNA.debitNoteId = id;
        dNA.filePath = filePath;
        db.DebitNoteAttachments.AddObject(dNA);
        db.SaveChanges();
    }

    public void addDebitNoteSubjectT(List<DebitNoteSubjectTDto> dnstList)
    {
        Guid id = new Guid(SessionClass.Identity);



        foreach (var dnst in dnstList)
        {
            DebitNoteSubjectT add = new DebitNoteSubjectT();
            add.debitNoteId = id;
            add.matterId = dnst.matterId;
            add.TTypeOfWork = dnst.TTypeOfWork;
            add.TIsOpponent = dnst.TIsOpponent;
            add.TOpponentValue = dnst.TOpponentValue;
            add.TRoleType = dnst.TRoleType;
            add.TRoleTypeValue = dnst.TRoleTypeValue;
            add.TrademarkLogo = dnst.TrademarkLogo;
            add.TrademarkNum = dnst.TrademarkNum;
            add.TClass = dnst.TClass;
            add.Country = dnst.Country;
            add.TrademarkLogoDescription = dnst.TrademarkLogoDescription;

            db.DebitNoteSubjectTs.AddObject(add);
            db.SaveChanges();
        }
    }

    public void addDebitNoteSubjectP(List<DebitNoteSubjectPDto> dnspList)
    {
        Guid id = new Guid(SessionClass.Identity);


        foreach (var dnst in dnspList)
        {
            DebitNoteSubjectP add = new DebitNoteSubjectP();
            add.debitNoteId = id;
            add.matterId = dnst.matterId;
            add.PStageValue = dnst.PStageValue;
            add.PRoleProprietorApplican = dnst.PRoleProprietorApplican;
            add.PRoleProprietorApplicanValue = dnst.PRoleProprietorApplicanValue;
            add.PAssignee = dnst.PAssignee;
            add.PTitle = dnst.PTitle;
            add.PDesignOrPatentNum = dnst.PDesignOrPatentNum;
            add.PDesignOrPatentNumValue = dnst.PDesignOrPatentNumValue;
            add.PNationalPhase = dnst.PNationalPhase;
            add.Country = dnst.Country;
            add.PPriorityValue = dnst.PPriorityValue;

            db.DebitNoteSubjectPs.AddObject(add);
            db.SaveChanges();
        }
    }

    public void editDebitNoteAttachment(string filePath)
    {
        Guid id = new Guid(SessionClass.Debitnoteid);

        DebitNoteAttachment dNA = new DebitNoteAttachment();
        dNA.debitNoteId = id;
        dNA.filePath = filePath;
        db.DebitNoteAttachments.AddObject(dNA);
        db.SaveChanges();
    }

    //public DebitNoteCore getDebitNoteCoreBy


    public int countDebitNoteVer()
    {
        Guid matterId = new Guid(HttpContext.Current.Request[QueryStringConst.matter]);

        var checking = db.DebitNoteCores.Where(p => p.matterNumId == matterId);

        return checking.Count() + 1;
    }



    public double getDebitNoteDisplayPrice(double discount)
    {
        double Sum = 0;
        double countTotal = 0;
        DataTable dt = SessionClass.DebitNoteCostDataTable;
        DataTable dtDisbursement = SessionClass.DebitNoteDisbursementDataTable;
        DataTable dtMisc = SessionClass.DebitNoteMiscDataTable;
        Sum = sunCostAndDisbursement(dt, Sum);
        Sum = sunCostAndDisbursement(dtDisbursement, Sum);
        Sum = sunMisc(dtMisc, Sum);
        countTotal = Sum * discount / 100;
        //string result = String.Format("Sum{0}", countTotal);
        //return result;
        return countTotal;
    }

    public double getDebitNoteDisplayPrice(double discount, string exchangeRateString, double timeEntrySubPrice, double depositAccount, bool isDiscount, bool isExchangeRate)
    {
        double SumCost = 0;
        double SumMisc = 0;
        double SumDisbursement = 0;
        double countTotal = 0;
        double costAndTimeEntry = 0;
        double exchangeRate = 1 / Convert.ToDouble(exchangeRateString);
        DataTable dt = SessionClass.DebitNoteCostDataTable;
        DataTable dtDisbursement = SessionClass.DebitNoteDisbursementDataTable;
        DataTable dtMisc = SessionClass.DebitNoteMiscDataTable;
        SumCost = sunCostAndDisbursement(dt, SumCost);
        SumDisbursement = sunCostAndDisbursement(dtDisbursement, SumDisbursement);
        SumMisc = sunMisc(dtMisc, SumMisc);

        costAndTimeEntry = SumCost + timeEntrySubPrice;
        if (isDiscount)
        {
            costAndTimeEntry = costAndTimeEntry * discount / 100;
        }
        countTotal = isExchangeRate ? (costAndTimeEntry + SumDisbursement + SumMisc - depositAccount) * exchangeRate : costAndTimeEntry + SumDisbursement + SumMisc - depositAccount;
        //string result = String.Format("Sum{0}", countTotal);
        //return result;
        return countTotal;
    }

    public double getDebitNoteSumDisbursement()
    {
        double SumDisbursement = 0;
        DataTable dtDisbursement = SessionClass.DebitNoteDisbursementDataTable;
        SumDisbursement = sunCostAndDisbursement(dtDisbursement, SumDisbursement);
        return SumDisbursement;
    }

    private double sunCostAndDisbursement(DataTable dt, double Sum)
    {
        if (dt != null)
        {
            foreach (DataRow dtRow in dt.Rows)
            {
                var tempValue = VariableHelper.DoubleHelper.TryParse(Convert.ToString(dtRow[DataTableConst.Cost]));
                if (tempValue > 0)
                {
                    Sum += tempValue;
                }
            }
        }
        return Sum;
    }


    private double sunMisc(DataTable dt, double Sum)
    {
        if (dt != null)
        {
            foreach (DataRow dtRow in dt.Rows)
            {
                var tempValue2 = VariableHelper.DoubleHelper.TryParse(Convert.ToString(dtRow[DataTableConst.Cost]));
                if (tempValue2 > 0)
                {
                    Sum += tempValue2;
                }
            }
        }
        return Sum;
    }


    public bool delAllDebitNoteRecords(string debitNoteId)
    {
        bool result = false;
        try
        {
            Guid findTar = new Guid(debitNoteId);
            var costInfo = db.DebitNoteCosts.Where(p => p.debitNoteId == findTar).ToList();
            var miscInfo = db.DebitNoteMiscs.Where(p => p.debitNoteId == findTar).ToList();
            var disbursementInfo = db.DebitNoteDisbursements.Where(p => p.debitNoteId == findTar).ToList();
            var narrativeInfo = db.DebitNoteNarratives.Where(p => p.debitNoteId == findTar).ToList();
            var attachmentInfo = db.DebitNoteAttachments.Where(p => p.debitNoteId == findTar).ToList();

            var subjectT = db.DebitNoteSubjectTs.Where(p => p.debitNoteId == findTar).ToList();
            var subjectP = db.DebitNoteSubjectPs.Where(p => p.debitNoteId == findTar).ToList();

            var coreInfo = db.DebitNoteCores.Where(p => p.id == findTar).ToList();
            editMatterDetailsStatus(narrativeInfo);
            delObject(costInfo);
            delObject(miscInfo);
            delObject(disbursementInfo);
            delObject(narrativeInfo);
            delObject(attachmentInfo);

            delObject(subjectT);
            delObject(subjectP);

            delObject(coreInfo);

            delAttFile(attachmentInfo);

            result = true;
        }
        catch (Exception ex)
        {
        }
        return result;
    }

    public bool delDebitNoteAtt(string debitNoteId)
    {
        bool result = false;
        try
        {
            Guid findTar = new Guid(debitNoteId);
            var attachmentInfo = db.DebitNoteAttachments.Where(p => p.debitNoteId == findTar).ToList();
            delAttFile(attachmentInfo);
            delObject(attachmentInfo);
            result = true;
        }
        catch (Exception ex)
        {

        }
        return result;
    }

    private void delObject<T>(List<T> tarList)
    {
        foreach (var item in tarList)
        {
            db.DeleteObject(item);
            db.SaveChanges();
        }
    }

    private void delAttFile(List<DebitNoteAttachment> filePathList)
    {
        foreach (var filePath in filePathList)
        {
            try
            {
                var tar = HttpContext.Current.Server.MapPath(filePath.filePath);
                File.Delete(tar);
            }
            catch
            {
            }
        }
    }

    private void editMatterDetailsStatus(List<DebitNoteNarrative> tarList)
    {
        foreach (var item in tarList)
        {
            var findId = item.matterDetailsId;
            var findDetails = db.MatterDetails.Where(p => p.id == findId).FirstOrDefault();
            findDetails.isEnable = true;
            db.SaveChanges();
        }
    }



    public void getCostAndDisbursementSession(string debitNoteId)
    {
        Random rnd = new Random();

        Guid debitnoteId = new Guid(debitNoteId);
        var findCost = db.DebitNoteCosts.Where(p => p.debitNoteId == debitnoteId);
        var findMisc = db.DebitNoteMiscs.Where(p => p.debitNoteId == debitnoteId);
        var findDisursement = db.DebitNoteDisbursements.Where(p => p.debitNoteId == debitnoteId);

        string header = DebitNoteHr.setHr();
        DataTable dt = DataTableHelper.CreateDataTable(header);
        foreach (var itemCost in findCost)
        {
            setCostGv(dt, itemCost.templateType, itemCost.templateDetails, itemCost.description, itemCost.cost, itemCost.orderByValue, rnd, itemCost.UpdateByUserId);
        }

        SessionClass.DebitNoteCostDataTable = dt;

        DataTable dtM = DataTableHelper.CreateDataTable(header);
        foreach (var itemCost in findMisc)
        {
            setCostGv(dtM, itemCost.templateType, itemCost.templateDetails, itemCost.description, itemCost.cost, itemCost.orderByValue, rnd, itemCost.UpdateByUserId);
        }

        SessionClass.DebitNoteMiscDataTable = dtM;

        DataTable dtD = DataTableHelper.CreateDataTable(header);
        foreach (var itemCost in findDisursement)
        {
            setCostGv(dtD, itemCost.templateType, itemCost.templateDetails, itemCost.description, itemCost.cost, itemCost.orderByValue, rnd, itemCost.UpdateByUserId);
        }

        SessionClass.DebitNoteDisbursementDataTable = dtD;
    }

    public List<DebitNoteSubjectTDto> getDebitNoteSubjectTDto(string debitNoteIdValue)
    {
        Guid debitNoteId = new Guid(debitNoteIdValue);
        var findT = db.DebitNoteSubjectTs.Where(p => p.debitNoteId == debitNoteId);
        List<DebitNoteSubjectTDto> result = new List<DebitNoteSubjectTDto>();
        foreach (var item in findT)
        {
            DebitNoteSubjectTDto temp = new DebitNoteSubjectTDto();
            temp.matterId = item.matterId;
            temp.TTypeOfWork = item.TTypeOfWork;
            temp.TIsOpponent = item.TIsOpponent;
            temp.TOpponentValue = item.TOpponentValue;
            temp.TRoleType = item.TRoleType;
            temp.TRoleTypeValue = item.TRoleTypeValue;
            temp.TrademarkLogo = item.TrademarkLogo;
            temp.TrademarkNum = item.TrademarkNum;
            temp.TClass = item.TClass;
            temp.Country = item.Country;
            temp.TrademarkLogoDescription = item.TrademarkLogoDescription;
            result.Add(temp);
        }
        return result;
    }

    public List<DebitNoteSubjectPDto> getDebitNoteSubjectPDto(string debitNoteIdValue)
    {
        Guid debitNoteId = new Guid(debitNoteIdValue);
        var findT = db.DebitNoteSubjectPs.Where(p => p.debitNoteId == debitNoteId);
        List<DebitNoteSubjectPDto> result = new List<DebitNoteSubjectPDto>();
        foreach (var item in findT)
        {
            DebitNoteSubjectPDto temp = new DebitNoteSubjectPDto();
            temp.matterId = item.matterId;
            temp.PStageValue = item.PStageValue;
            temp.PRoleProprietorApplican = item.PRoleProprietorApplican;
            temp.PRoleProprietorApplicanValue = item.PRoleProprietorApplicanValue;
            temp.PAssignee = item.PAssignee;
            temp.PTitle = item.PTitle;
            temp.PDesignOrPatentNum = item.PDesignOrPatentNum;
            temp.PDesignOrPatentNumValue = item.PDesignOrPatentNumValue;
            temp.PNationalPhase = item.PNationalPhase;
            temp.Country = item.Country;
            temp.PPriorityValue = item.PPriorityValue;
            result.Add(temp);
        }
        return result;
    }

    private void setCostGv(DataTable dt, string templateType, string templateDetails, string description, double? cost, int? order, Random rnd, Guid? feeEarner)
    {
        string[] strList = new string[dt.Columns.Count];
        int card = rnd.Next(2147483647);
        strList[0] = card.ToString();
        //strList[0] = dt.Rows.Count.ToString();

        strList[1] = templateType;
        strList[2] = templateDetails;
        strList[3] = description;
        strList[4] = cost.HasValue ? cost.Value.ToString() : "";

        strList[5] = order.HasValue ? order.Value.ToString() : "";

        strList[6] = feeEarner.HasValue ? Convert.ToString(feeEarner.Value) : "";


        string dTableValue = DataTableHelper.joinArrayToString(strList);

        DataTableHelper.CreateDataRow(ref dt, dTableValue);

    }


    public List<string> getAttFilePath(string debitNoteId)
    {
        Guid debitnoteId = new Guid(debitNoteId);
        List<string> result = new List<string>();
        var findAtt = db.DebitNoteAttachments.Where(p => p.debitNoteId == debitnoteId);
        foreach (var item in findAtt)
        {
            result.Add(item.filePath);
        }
        return result;
    }

    public string getNQ(string debitNoteId)
    {
        Guid debitnoteId = new Guid(debitNoteId);
        string result = "";
        List<string> temp = new List<string>();
        var findNarr = db.DebitNoteNarratives.Where(p => p.debitNoteId == debitnoteId);

        foreach (var item in findNarr)
        {
            temp.Add(String.Format("it.id == {0}", item.matterDetailsId));
        }

        if (temp != null)
        {
            result = String.Join(" or ", temp.ToArray());
        }


        return result;
    }

    public string getML(string matterIdList)
    {
        string result = "";
        List<string> temp = new List<string>();
        var matterIdArr = matterIdList.Split(',');

        foreach (var item in matterIdArr)
        {
            Guid matterGuid = new Guid(item);
            temp.Add(SQLHelper.whereGuid(DatabaseConst.MatterDetail.matterId, matterGuid));
        }

        if (temp != null)
        {
            result = String.Join(" or ", temp.ToArray());
        }


        return result;
    }


    public List<Tuple<int, bool>> getNQId(string debitNoteId)
    {
        Guid debitnoteId = new Guid(debitNoteId);
        // List<int> result = new List<int>();
        List<Tuple<int, bool>> result = new List<Tuple<int, bool>>();
        var findNarr = db.DebitNoteNarratives.Where(p => p.debitNoteId == debitnoteId);
        foreach (var item in findNarr)
        {
            //result.Add(item.matterDetailsId);
            bool checking = item.isCountTotal.HasValue ? item.isCountTotal.Value : true;
            result.Add(new Tuple<int, bool>(item.matterDetailsId, checking));
        }

        return result;
    }

    public string getMatterNumByDebitNoteId(string debitNoteId)
    {
        string result = "";
        Guid id = new Guid(debitNoteId);
        var tar = db.DebitNoteCores.Where(q => q.id == id).FirstOrDefault();
        if (tar != null)
        {
            result = tar.MatterCore.matterNum;
        }
        return result;
    }

    public string getDebitNoteCategoryByDebitNoteId(string debitNoteId)
    {
        string result = "";
        Guid id = new Guid(debitNoteId);
        var tar = db.DebitNoteCores.Where(q => q.id == id).FirstOrDefault();
        if (tar != null)
        {
            result = tar.category;
        }
        return result;
    }
}
