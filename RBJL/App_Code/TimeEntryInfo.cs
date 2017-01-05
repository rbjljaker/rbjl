using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;
using System.Text;

/// <summary>
/// Summary description for TimeEntryInfo
/// </summary>
public partial class TimeEntryInfo : DBEntity
{
    public TimeEntryInfo()
        : base()
    {
    }

    public TimeEntryInfo(string userName)
        : base(userName)
    {

    }


    public MatterDetailDto getMatterDetailsByDetailsId(int id)
    {
        var findDetail = getEntityById(id);
        MatterDetailDto mDD = new MatterDetailDto();
        mDD.id = findDetail.id;
        mDD.itemNum = findDetail.itemNum.Value;
        mDD.date = findDetail.date.Value;
        if (findDetail.timespan.HasValue)
        {
            mDD.timeSpan = findDetail.timespan.Value;
        }
        if (findDetail.fixedCost.HasValue)
        {
            mDD.fixedCost = findDetail.fixedCost.Value;
        }
        mDD.templateType = findDetail.templateType.Value;
        mDD.templateDescription = findDetail.templateDescription;
        mDD.description = findDetail.description;
        mDD.feeEarner = findDetail.feeEarner.Value;
        if (findDetail.billable.HasValue)
        {
            mDD.billable = findDetail.billable.Value;
        }

        if (findDetail.hourlyRateH.HasValue)
        {
            mDD.hourlyRateH = findDetail.hourlyRateH.Value;
        }
        else
        {
            mDD.hourlyRateH = 0;
        }
        mDD.isBill = findDetail.isEnable.Value;

        mDD.fixedCostTimeSpan = findDetail.fixedCostTimeSpan.HasValue ? findDetail.fixedCostTimeSpan.Value : 0;

        return mDD;
    }

    public void editMatterDetail(MatterDetailDto mDD)
    {
       

        var findDetail = getEntityById(Convert.ToInt32(SessionClass.MatterDetailId));
        
        //findDetail.itemNum = mDD.itemNum;
        findDetail.date = mDD.date;
        findDetail.feeEarner = mDD.feeEarner;
        findDetail.timespan = mDD.timeSpan;
        findDetail.fixedCost = mDD.fixedCost;
        findDetail.templateType = mDD.templateType;
        findDetail.hourlyRateH = mDD.hourlyRateH;
        if (mDD.billable != 0)
        {
            findDetail.billable = mDD.billable;
        }
        else
        {
            findDetail.billable = null;
        }

        findDetail.templateDescription = mDD.templateDescription;
        findDetail.fixedCostTimeSpan = mDD.fixedCostTimeSpan;
        findDetail.description = mDD.description;
        findDetail.UpdateDate = DateTime.Now;
        findDetail.UpdateByUserId = base.userGuid;


        db.SaveChanges();

        updateMatterlastUpdateTime(findDetail.matterId);
    }

    public void editMatterDetailPendingList(MatterDetailDto mDD)
    {
        var findDetail = getEntityById(Convert.ToInt16(SessionClass.MatterDetailId));
        findDetail.date = mDD.date;
        findDetail.timespan = mDD.timeSpan;
        findDetail.fixedCost = mDD.fixedCost;
        findDetail.feeEarner = mDD.feeEarner;
        findDetail.templateType = mDD.templateType;
        findDetail.templateDescription = mDD.templateDescription;
        findDetail.description = mDD.description;
        findDetail.fixedCostTimeSpan = mDD.fixedCostTimeSpan;
        findDetail.UpdateDate = DateTime.Now;
        findDetail.UpdateByUserId = base.userGuid;
        findDetail.isEnable = mDD.isBill;
        db.SaveChanges();
        updateMatterlastUpdateTime(findDetail.matterId);
    }

    public void addMatterDetailByDTE(MatterDetailDto mDD)
    {
        var findDetail = getEntityById(Convert.ToInt16(SessionClass.MatterDetailId));

        findDetail.itemNum = mDD.itemNum;
        findDetail.matterId = mDD.matterId;
        findDetail.hourlyRateH = mDD.hourlyRateH;
        findDetail.UpdateDate = DateTime.Now;
        findDetail.UpdateByUserId = base.userGuid;
        findDetail.isEnable = true;

        db.SaveChanges();

        updateMatterlastUpdateTime(findDetail.matterId);
    }

    public void addMatterDetailByDTE(MatterDetailDto mDD, int MatterDetailIdValue)
    {
        var findDetail = getEntityById(MatterDetailIdValue);

        findDetail.itemNum = mDD.itemNum;
        findDetail.matterId = mDD.matterId;
        findDetail.hourlyRateH = mDD.hourlyRateH;
        findDetail.UpdateDate = DateTime.Now;
        findDetail.UpdateByUserId = base.userGuid;
        findDetail.isEnable = true;

        db.SaveChanges();

        updateMatterlastUpdateTime(findDetail.matterId);
    }

    public void editTimeEntryIsUsed(MatterDetailDto mDD)
    {
        var findDetail = getEntityById(mDD.id);
        findDetail.isEnable = false;
        db.SaveChanges();
        updateMatterlastUpdateTime(findDetail.matterId);
    }

    public MatterDetail getEntityById(int id)
    {
        return db.MatterDetails.Where(p => p.id == id).FirstOrDefault();
    }

    public EnumFeeEarnerAndHandlingColleague getTimeEntryUserRole()
    {
        EnumFeeEarnerAndHandlingColleague result = new EnumFeeEarnerAndHandlingColleague();

        Guid matterId = Guid.Parse(HttpContext.Current.Request[QueryStringConst.matter]);

        var checkFeeEarner = db.MatterAndFeeEarners.Where(p => p.matterId == matterId && p.feeEarnerId == userGuid).Count();
        if (checkFeeEarner > 0)
        {
            result = EnumFeeEarnerAndHandlingColleague.FeeEarner;
        }
        else
        {
            var checkHandlingColleague = db.MatterAndHandlingColleagues.Where(p => p.matterId == matterId && p.handlingColleagueId == userGuid).Count();
            if (checkHandlingColleague > 0)
            {
                result = EnumFeeEarnerAndHandlingColleague.HandlingColleague;
            }
            else
            {
                result = EnumFeeEarnerAndHandlingColleague.GeneralUser;
            }
        }
        return result;
    }



    //public double[] getFixedCost()
    //{
    //    double[] result = new double[2];
    //    result[0] = 0;
    //    result[1] = 0;

    //    var findAll = db.MatterCores;
    //    var findData = getTodayMatterDetails();

    //    foreach (var item in findData)
    //    {
    //        bool checking = checkIsBillable(findAll, item);
    //        if (checking)
    //        {
    //            result[0] += item.timespan.HasValue ? item.timespan.Value : 0;
    //        }
    //        else
    //        {
    //            result[1] += item.timespan.HasValue ? item.timespan.Value : 0;
    //        }
    //    }
    //    return result;
    //}

    public double getFixedCost()
    {
        double result = 0;

        var findAll = db.MatterCores;
        var findData = getTodayMatterDetails();

        foreach (var item in findData)
        {
            result += item.timespan.HasValue ? item.timespan.Value : 0;
            if (item.fixedCost.HasValue && item.fixedCostTimeSpan.HasValue)
            {
                result += item.fixedCostTimeSpan.Value;
            }
        }
        return result;
    }

    private bool checkIsBillable(IQueryable<MatterCore> findAll, MatterDetail item)
    {
        var findMatter = findAll.Where(p => p.id == item.matterId).FirstOrDefault().matterNum;
        int outResult = 0;
        bool checking = int.TryParse(findMatter, out outResult);
        return checking;
    }

    public TimeEntryBillableOrNonBillable getBillableBar()
    {
        TimeEntryBillableOrNonBillable result = new TimeEntryBillableOrNonBillable();
        var findData = getTodayMatterDetailsByMonth();
        result.totalRecord = findData.Count();
        int outResult = 0;
        var findAll = db.MatterCores;
        foreach (var item in findData)
        {
            var findMatter = findAll.Where(p => p.id == item.matterId).FirstOrDefault().matterNum;
            if (findMatter != "Temp Time Entry")
            {
                bool checking = int.TryParse(findMatter, out outResult);
                if (checking)
                {
                    result.billable++;
                }
                else
                {
                    result.nonBillable++;
                }
            }
            else
            {
                var checkingIsBillable = item.isEnable.Value;
                if (checkingIsBillable)
                {
                    result.billable++;
                }
                else
                {
                    result.nonBillable++;
                }
            }
        }
        return result;
    }

    public TimeEntryBillableOrNonBillable getBillableBarByMonth()
    {
        TimeEntryBillableOrNonBillable result = new TimeEntryBillableOrNonBillable();
        var findData = getTodayMatterDetailsByMonth();
        result.totalRecord = findData.Count();
        int outResult = 0;
        var findAll = db.MatterCores;
        foreach (var item in findData)
        {
            var findMatter = findAll.Where(p => p.id == item.matterId).FirstOrDefault().matterNum;
            bool checking = int.TryParse(findMatter, out outResult);
            if (checking)
            {
                result.billable++;
            }
            else
            {
                result.nonBillable++;
            }
        }
        return result;
    }

    private IQueryable<MatterDetail> getTodayMatterDetails()
    {
        DateTime dt = DateTime.Now;

        var findData = from q in db.MatterDetails
                       where q.feeEarner == userGuid &&
                       q.CreateDate.Value.Year == dt.Year &&
                       q.CreateDate.Value.Month == dt.Month &&
                       q.CreateDate.Value.Day == dt.Day
                       select q;

        return findData;
    }

    private IQueryable<MatterDetail> getTodayMatterDetailsByMonth()
    {
        DateTime dt = DateTime.Now;

        var findData = from q in db.MatterDetails
                       where q.feeEarner == userGuid &&
                       q.CreateDate.Value.Year == dt.Year &&
                       q.CreateDate.Value.Month == dt.Month
                       select q;

        return findData;
    }

    public string findDraftMatter()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(SQLHelper.whereGuid(DatabaseConst.MatterDetail.matterId, tempTimeEntryId));
        sb.Append(DatabaseConst.and);
        sb.Append("( ");
        sb.Append(SQLHelper.whereGuid(DatabaseConst.createByUserId, userGuid));
        sb.Append(DatabaseConst.or);
        sb.Append(SQLHelper.whereGuid(DatabaseConst.MatterDetail.feeEarner, userGuid));
        sb.Append(" )");
        return sb.ToString();
    }

    public string findAdminDraftMatter()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(SQLHelper.whereGuid(DatabaseConst.MatterDetail.matterId, tempTimeEntryId));
        return sb.ToString();
    }


    public int countDraftItemNum()
    {
        int result = db.MatterDetails.Where(p => p.matterId == tempTimeEntryId && p.CreateByUserId == userGuid).Count();
        return result + 1;
    }


    public double getDebitNoteBilledValue(IEnumerable<DebitNoteCore> findTar)
    {
        double result = 0;

        foreach (var item in findTar)
        {
            //var hourlyRote = item.hourlyRateD.HasValue ? item.hourlyRateD.Value : 1000;
            var findDetails = getDebitNoteDetailsByMonth(item.id);
            foreach (var value in findDetails)
            {
                if (value.timespan.HasValue && value.timespan.Value != 0 && value.timespan.HasValue)
                {
                    result += value.timespan.Value * value.timespan.Value;
                }
                else
                {
                    result += value.fixedCost.HasValue ? value.fixedCost.Value : 0;
                }
            }

            var getCost = getDebitNoteCost(item.id);
            foreach (var costItem in getCost)
            {
                if (costItem.cost.HasValue)
                {
                    result += costItem.cost.Value;
                }
            }
        }

        //foreach (var value in findTar)
        //{
        //    result += value.price.Value;
        //}


        return result;
    }

    public void getDebitNoteTarUser(ref IEnumerable<DebitNoteCore> findTar)
    {
        DateTime dt = DateTime.Now;
        findTar = from q in findTar
                  where q.feeEarnerList != null && q.feeEarnerList.Split(',').Contains(userGuid.ToString()) && q.CreateDate.Value.Year == dt.Year && q.CreateDate.Value.Month == dt.Month
                  select q;

    }


    public void getReportTarUser(ref IEnumerable<DebitNoteCore> findTar, Guid userId)
    {
        findTar = from q in findTar
                  where q.feeEarnerList != null && q.feeEarnerList.Split(',').Contains(userId.ToString())
                  select q;
    }


    private IQueryable<DebitNoteNarrative> getDebitNoteDetailsByMonth(Guid findId)
    {
        //DateTime dt = DateTime.Now;

        var findData = from q in db.DebitNoteNarratives
                       where q.feeEarner == userGuid &&
                           //q.CreateDate.Value.Year == dt.Year &&
                           //q.CreateDate.Value.Month == dt.Month
                       q.debitNoteId == findId
                       select q;

        return findData;
    }


    private IQueryable<DebitNoteCost> getDebitNoteCost(Guid findId)
    {
        var findData = from q in db.DebitNoteCosts
                       where q.UpdateByUserId == userGuid &&
                       q.debitNoteId == findId
                       select q;
        return findData;
    }

    public void getDebitNoteCoresByMonth(ref IQueryable<DebitNoteCore> tar)
    {
        DateTime dt = DateTime.Now;

        tar = from q in tar
              where q.CreateDate.Value.Year == dt.Year &&
              q.CreateDate.Value.Month == dt.Month
              select q;

    }

    public void getDebitNoteCoresByDataRange(ref IQueryable<DebitNoteCore> tar, string dTSting, string dtToString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dTSting);
        DateTime dtTo = DateTimeHelper.convertStringToDateTime(dtToString);
        tar = from q in tar
              where q.CreateDate.Value <= dtTo && q.CreateDate.Value >= dt
              select q;
    }

    public void getMatterDetailByDataRange(ref IQueryable<MatterDetail> tar, string dTSting, string dtToString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dTSting);
        DateTime dtTo = DateTimeHelper.convertStringToDateTime(dtToString);
        tar = from q in tar
              where q.CreateDate.Value <= dtTo && q.CreateDate.Value >= dt
              select q;
    }

    public IQueryable<DebitNoteCore> getDebitNoteCores
    {
        get
        {
            var findData = from q in db.DebitNoteCores
                           select q;
            return findData;
        }
    }

    public IQueryable<MatterDetail> getTimeEntry
    {
        get
        {
            var findData = from q in db.MatterDetails
                           select q;
            return findData;
        }
    }

    public List<DDLValueDto> getFeeEarnerDDLList()
    {
        List<DDLValueDto> result = new List<DDLValueDto>();
        Guid matterId = new Guid(HttpContext.Current.Request[QueryStringConst.matter]);
        var findTar = db.MatterAndFeeEarners.Where(q => q.matterId == matterId);

        foreach (var item in findTar)
        {
            DDLValueDto tempList = new DDLValueDto();
            string hourlyRate = item.hourlyRate.HasValue ? item.hourlyRate.Value.ToString() : "";
            tempList.id = String.Format("{0},{1}", item.feeEarnerId, hourlyRate);
            tempList.value = getUserNameBySystemId(item.feeEarnerId);
            result.Add(tempList);
        }

        result = result.Distinct(new DistinctDDLValue()).ToList();
        return result;
    }

    public MatterAndFeeEarner checkUserAndMatter(string matterId, Guid userId)
    {
        Guid mId = new Guid(matterId);

        var getResult = db.MatterAndFeeEarners.Where(p => p.matterId == mId && p.feeEarnerId == userId).FirstOrDefault();
        return getResult;
    }

    public MatterAndFeeEarner checkUserAndMatter(string matterId, Guid userId, IQueryable<MatterAndFeeEarner> tar)
    {
        Guid mId = new Guid(matterId);

        var getResult = tar.Where(p => p.matterId == mId && p.feeEarnerId == userId).FirstOrDefault();
        return getResult;
    }

    public IQueryable<MatterAndFeeEarner> getMatterAndFeeEarner
    {
        get
        {
            return db.MatterAndFeeEarners;
        }
    }

    public List<TimeEntryInfoDto> getOldTimeEntry()
    {
        List<TimeEntryInfoDto> result = new List<TimeEntryInfoDto>();

        //string matterIdValue = "747AB653-F6FD-45AC-A3FD-D9574A1AA1E8";
        string matterIdValue = HttpContext.Current.Request[QueryStringConst.matter];
        Guid matterId = new Guid(matterIdValue);
        List<string> findTarDebitNote = new List<string>();

        var tarDebitNote = db.DebitNoteCores.Where(q => q.matterNumId == matterId || q.matterNumIdList.Contains(matterIdValue)).OrderBy(q => q.CreateDate).AsEnumerable();


        var timeEntryCore = db.DebitNoteNarratives;
        var matterDCore = db.MatterDetails;

        foreach (var item in tarDebitNote)
        {
            var tarTimeEntry = from timeEntry in timeEntryCore
                               join matterD in matterDCore
                               on timeEntry.matterDetailsId equals matterD.id
                               where matterD.matterId == matterId &&
                               timeEntry.debitNoteId == item.id
                               orderby timeEntry.matterDetailsId
                               select timeEntry;

            foreach (var timeEntryItem in tarTimeEntry)
            {
                TimeEntryInfoDto tempItem = new TimeEntryInfoDto();
                tempItem.itemNum = Convert.ToString(timeEntryItem.itemNum);
                tempItem.date = DateTimeHelper.convertDateTimeToString(timeEntryItem.date.Value);
                tempItem.description = timeEntryItem.description;
                tempItem.feeEarner = getUserNameBySystemId(timeEntryItem.feeEarner.Value);

                string timespan = timeEntryItem.timespan.HasValue ? Convert.ToString(timeEntryItem.timespan.Value) : "";
                string fixedCost = timeEntryItem.fixedCost.HasValue ? Convert.ToString(timeEntryItem.fixedCost.Value) : "";
                string writtenOff = timeEntryItem.timespan.HasValue && timeEntryItem.billable.HasValue ? Convert.ToString(timeEntryItem.billable.Value - timeEntryItem.timespan.Value) : "";
                string billable = timeEntryItem.billable.HasValue ? Convert.ToString(timeEntryItem.billable.Value) : "";

                tempItem.timespan = timespan;
                tempItem.fixedCost = fixedCost;
                tempItem.writtenOff = writtenOff;
                tempItem.billable = billable;
                tempItem.isContent = true;
                result.Add(tempItem);
            }

            TimeEntryInfoDto temp = new TimeEntryInfoDto();
            temp.info = String.Format("Debit Note Type:{0}, Debit Note Num:{1}, Debit Note:{2}, Amount: HK${3:#,0.#0}", setDebitNoteStatus(item.debitNoteType), item.debitNoteNum, item.category, item.price.Value);
            temp.isContent = false;
            result.Add(temp);
        }


        return result;
    }


    private string setDebitNoteStatus(string item)
    {
        string result = "";
        int type = Convert.ToInt16(item);
        switch (type)
        {
            case 1: result = "Interim Debit Note"; break;
            case 2: result = "Renewal"; break;
            case 3: result = "Maintenance Debit Note"; break;
            case 4: result = "Final"; break;
            default: break;
        }

        return result;
    }


    public double getReportTarAmount(IEnumerable<MatterDetail> findTar, Guid userId)
    {
        double result = 0;

        //getReportTarUser(ref findTar, userId);

        //foreach (var tarDebitNote in findTar)
        //{
        //    var getOldTimeEntry = db.DebitNoteNarratives.Where(q => q.debitNoteId == tarDebitNote.id && q.feeEarner == userId);

        //    foreach (var item in getOldTimeEntry)
        //    {
        //        var hourlyRote = item.hourlyRateH.HasValue ? item.hourlyRateH.Value : 0;
        //        if (item.timespan.HasValue && item.timespan.Value != 0)
        //        {
        //            result += item.timespan.Value * hourlyRote;
        //        }
        //        else
        //        {
        //            result += item.fixedCost.HasValue ? item.fixedCost.Value : 0;
        //        }
        //    }
        //}


        var getTimeEntry = findTar.Where(q => q.feeEarner == userId);
        foreach (var item in getTimeEntry)
        {
            var hourlyRote = item.hourlyRateH.HasValue ? item.hourlyRateH.Value : 0;
            if (item.timespan.HasValue && item.timespan.Value != 0)
            {
                result += getPrice(item);
            }
            else
            {
                result += getPrice(item);
            }
        }


        return result;
    }



    public TimeEntryBillableOrNonBillable getReportTarBillbleOrNonValue(IEnumerable<MatterDetail> findTar, Guid userId, IQueryable<DebitNoteCore> tarDebitNote)
    {
        TimeEntryBillableOrNonBillable result = new TimeEntryBillableOrNonBillable();
        int outResult = 0;
        var findAll = db.MatterCores;
        var getTimeEntry = findTar.Where(q => q.feeEarner == userId);
        foreach (var item in getTimeEntry)
        {
            var findMatter = findAll.Where(p => p.id == item.matterId).FirstOrDefault().matterNum;
            if (findMatter != "Temp Time Entry")
            {
                bool checking = int.TryParse(findMatter, out outResult);
                if (checking)
                {
                    result.billable += getPrice(item);
                }
                else
                {
                    result.nonBillable += getPrice(item);
                }

                var checkingIsBilled = item.isEnable.Value;
                if (checkingIsBilled)
                {
                    result.billed += getPrice(item);
                }
                else
                {
                    result.unbilled += getPrice(item);
                }

                if (item.timespan.HasValue && item.billable.HasValue)
                {
                    result.writtenOff = item.timespan.Value - item.billable.Value;
                }
            }
            else
            {
                var checkingIsBillable = item.isEnable.Value;
                if (checkingIsBillable)
                {
                    result.billable += getPrice(item);
                }
                else
                {
                    result.nonBillable += getPrice(item);
                }
            }
        }

        foreach (var tarDe in tarDebitNote)
        {
            var tarCost = db.DebitNoteCosts.Where(q => q.debitNoteId == tarDe.id && q.UpdateByUserId == userId);
            foreach (var costItem in tarCost)
            {
                if (costItem.UpdateByUserId.HasValue && costItem.cost.HasValue)
                {
                    result.billed += costItem.cost.Value;
                }
            }
        }

        return result;
    }

    public double getPrice(MatterDetail item)
    {
        double result = 0;
        //if (item.timespan.HasValue && item.hourlyRateH.HasValue)
        //{
        //    result = item.timespan.Value * item.hourlyRateH.Value;
        //}
        //else if (item.fixedCost.HasValue)
        //{
        //    result = item.fixedCost.Value;
        //}

        var hourlyRote = item.hourlyRateH.HasValue ? item.hourlyRateH.Value : 0;
        if (item.timespan.HasValue && item.timespan.Value != 0)
        {
            result += item.timespan.Value * hourlyRote;
        }
        else
        {
            result += item.fixedCost.HasValue ? item.fixedCost.Value : 0;
        }

        return result;
    }

    private void updateMatterlastUpdateTime(Guid matterId)
    {
        var matter = db.MatterCores.Where(p => p.id == matterId).FirstOrDefault();
        if (matter != null)
        {
            matter.UpdateByUserId = base.userGuid;
            matter.UpdateDate = DateTime.Now;
            db.SaveChanges();
        }
    }
}