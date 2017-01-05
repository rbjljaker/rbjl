using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;

/// <summary>
/// Summary description for ReportInfo
/// </summary>
public class ReportInfo : DBEntity
{
    public bool mustShow=false;
    public ReportInfo()
        : base()
    {

    }

    public ReportInfo(string userName)
        : base(userName)
    {

    }

    #region Matter


    public List<DDLValueDto> getNewRecordUser(DateTime dt)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findTar = findMatterReport();

        findMatterReportByDate(ref findTar, dt);

        var findResult = (from q in db.MatterAndFeeEarners
                          where findTar.Select(p => p.id).Contains(q.matterId)
                          select q.feeEarnerId).Distinct().ToArray();

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item);
            resultDto.value = getUserNameBySystemId(item);
            result.Add(resultDto);
        }
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }


    public List<DDLValueDto> getNewRecordUser(DateTime dt, DateTime dtTo)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findTar = findMatterReport();

        findMatterReportByDate(ref findTar, dt, dtTo);

        var findResult = (from q in db.MatterAndFeeEarners
                          where findTar.Select(p => p.id).Contains(q.matterId)
                          select q.feeEarnerId).Distinct().ToArray();

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item);
            resultDto.value = getUserNameBySystemId(item);
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> getNewRecordMatterNum(DateTime dt, string userGuidTar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getMatterByDateAndFeeEarner(dt, userGuidTar);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.id);
            resultDto.value = item.matterNum;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> getNewRecordMatterNum(DateTime dt, string userGuidTar, DateTime dtTo)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getMatterByDateAndFeeEarner(dt, userGuidTar, dtTo);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.id);
            resultDto.value = item.matterNum;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> bindListNewRecordFeeEarner(IQueryable<View_FindMatter> tar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = (from q in db.MatterAndFeeEarners
                          where tar.Select(p => p.id).Contains(q.matterId)
                          select q.feeEarnerId).Distinct().ToArray();

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item);
            resultDto.value = getUserNameBySystemId(item);
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> bindListNewRecordFeeEarner(IEnumerable<View_FindMatter> tar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var matterArr = tar.Select(p => p.id).ToArray();

        var findResult = (from q in db.MatterAndFeeEarners.AsEnumerable()
                          where matterArr.Contains(q.matterId)
                          select q.feeEarnerId).Distinct().ToArray();

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item);
            resultDto.value = getUserNameBySystemId(item);
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> bindListNewRecordMatterNum(IQueryable<View_FindMatter> tar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        foreach (var item in tar)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.id);
            resultDto.value = item.matterNum;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));

        return result;
    }

    public List<DDLValueDto> bindListNewRecordMatterSubject(IQueryable<View_FindMatter> tar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        foreach (var item in tar)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = item.matterSubject;
            resultDto.value = item.matterSubject;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> bindListNewRecordMatterClient(IQueryable<View_FindMatter> tar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        foreach (var item in tar)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.clientId);
            resultDto.value = item.clientName;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> bindListNewRecordMatterReferer(IQueryable<View_FindMatter> tar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        foreach (var item in tar)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.refererId);
            resultDto.value = item.refererName;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> bindListNewRecordMatterJobType(IQueryable<View_FindMatter> tar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        foreach (var item in tar)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = item.jobTypeName;
            resultDto.value = item.jobTypeName;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }


    private IQueryable<View_FindMatter> getMatterByDateAndFeeEarner(DateTime dt, string userGuidTar)
    {
        var findTar = findMatterReport();

        findMatterReportByDate(ref findTar, dt);

        Guid feeEarnerId = new Guid(userGuidTar);

        var findMatterId = (from q in db.MatterAndFeeEarners
                            where findTar.Select(p => p.id).Contains(q.matterId) && q.feeEarnerId == feeEarnerId
                            select q.matterId).Distinct().ToArray();

        var findResult = from q in findTar
                         where findMatterId.Contains(q.id)
                         select q;

        return findResult;
    }

    private IQueryable<View_FindMatter> getMatterByDateAndFeeEarner(DateTime dt, string userGuidTar, DateTime dtTo)
    {
        var findTar = findMatterReport();

        findMatterReportByDate(ref findTar, dt, dtTo);

        Guid feeEarnerId = new Guid(userGuidTar);

        var findMatterId = (from q in db.MatterAndFeeEarners
                            where findTar.Select(p => p.id).Contains(q.matterId) && q.feeEarnerId == feeEarnerId
                            select q.matterId).Distinct().ToArray();

        var findResult = from q in findTar
                         where findMatterId.Contains(q.id)
                         select q;

        return findResult;
    }


    //private IQueryable<View_FindMatter> getMatterIdByDate(DateTime dt)
    //{
    //    var findTar = from q in db.View_FindMatter
    //                  where q.fileOpenDate.Value.Year == dt.Year && q.fileOpenDate.Value.Month == dt.Month && q.fileOpenDate.Value.Day == dt.Day
    //                  select q;
    //    return findTar;
    //}

    public string findMatterSubject(string id)
    {
        return findMatterInfoById(id).matterSubject;
    }


    public string findMatterClient(string id)
    {
        return findMatterInfoById(id).clientName;
    }

    private View_FindMatter findMatterInfoById(string id)
    {
        Guid matterId = new Guid(id);
        var result = db.View_FindMatter.Where(p => p.id == matterId).FirstOrDefault();
        return result;
    }


    public IQueryable<View_FindMatter> findMatterReport()
    {
        var result = db.View_FindMatter.Where(p => p.id != new Guid("EE28CD2C-D1C3-45A7-B315-42BAEBF6F830") && p.status != "3" && p.status != "4" && p.matterNum != "");
        return result;
    }

    public IQueryable<View_FindMatter> findMatterReportWithNoMatterNum()
    {//&& p.matterNum != ""
        var result = db.View_FindMatter.Where(p => p.id != new Guid("EE28CD2C-D1C3-45A7-B315-42BAEBF6F830") && p.status != "3" && p.status != "4");
        return result;
    }



    public void findMatterReportByDate(ref IQueryable<View_FindMatter> tar, string dTString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dTString);
        tar = from q in tar
              where q.fileOpenDate.Value.Year == dt.Year && q.fileOpenDate.Value.Month == dt.Month && q.fileOpenDate.Value.Day == dt.Day
              select q;
    }


    public void findMatterReportByDate(ref IQueryable<View_FindMatter> tar, DateTime dt)
    {
        tar = from q in tar
              where q.fileOpenDate.Value.Year == dt.Year && q.fileOpenDate.Value.Month == dt.Month && q.fileOpenDate.Value.Day == dt.Day
              select q;
    }

    public void findMatterReportByDate(ref IQueryable<View_FindMatter> tar, DateTime dt, DateTime dtTo)
    {
        DateTime dtE = dtTo.AddDays(1).AddMinutes(-1);
        tar = from q in tar
              where (q.fileOpenDate.Value <= dtE && q.fileOpenDate.Value >= dt) || (q.UpdateDate <= dtE && q.UpdateDate >= dt)
              select q;
    }


    public void findMatterReportByDate(ref IQueryable<View_FindMatter> tar, string dtS, string dtToS)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dtS);
        DateTime dtTo = DateTimeHelper.convertStringToDateTime(dtToS);
        DateTime dtE = dtTo.AddDays(1).AddMinutes(-1);
        tar = from q in tar
              where (q.fileOpenDate.Value <= dtE && q.fileOpenDate.Value >= dt) || (q.UpdateDate <= dtE && q.UpdateDate >= dt)
              select q;
    }

    public void findMatterReportByFeeEarner(ref IQueryable<View_FindMatter> tar, string feeEarnerId)
    {
        Guid feeId = new Guid(feeEarnerId);
        var temp = tar;
        var findMatterId = (from q in db.MatterAndFeeEarners
                            where temp.Select(p => p.id).Contains(q.matterId) && q.feeEarnerId == feeId
                            select q.matterId).Distinct().ToArray();

        tar = from q in temp
              where findMatterId.Contains(q.id)
              select q;

    }

    public void findMatterReportById(ref IQueryable<View_FindMatter> tar, string tarId)
    {
        Guid id = new Guid(tarId);
        tar = from q in tar
              where q.id == id
              select q;
    }

    public void findMatterReportBySubject(ref IQueryable<View_FindMatter> tar, string subject)
    {
        tar = from q in tar
              where q.matterSubject == subject
              select q;
    }


    public void findMatterReportByClinetId(ref IQueryable<View_FindMatter> tar, string clientId)
    {
        int id = Convert.ToInt16(clientId);
        tar = from q in tar
              where q.clientId == id
              select q;
    }

    public void findMatterReportByRefererId(ref IQueryable<View_FindMatter> tar, string refererId)
    {
        int id = Convert.ToInt16(refererId);
        tar = from q in tar
              where q.refererId == id
              select q;
    }

    public void findMatterReportByJobType(ref IQueryable<View_FindMatter> tar, string jobType)
    {
        tar = from q in tar
              where q.jobTypeName == jobType
              select q;
    }

    public void findMatterReportByMatterId(ref IQueryable<View_FindMatter> tar, string matterId)
    {
        Guid mId = new Guid(matterId);
        tar = from q in tar
              where q.id == mId
              select q;
    }

    #endregion

    #region DebitNote

    public IQueryable<View_ReportDebitNote> findDebitNoteReport()
    {
        var result = db.View_ReportDebitNote.Where(p => p.debitNoteNum != null);
        return result;
    }

    public IQueryable<View_ReportDebitNote> findDebitNoteReportAll()
    {
        var result = db.View_ReportDebitNote;
        return result;
    }

    public void findDebitNoteReportByDate(ref IQueryable<View_ReportDebitNote> tar, DateTime dt)
    {
        tar = from q in tar
              where q.reportDate.Value.Year == dt.Year && q.reportDate.Value.Month == dt.Month && q.reportDate.Value.Day == dt.Day
              select q;
    }

    public void findDebitNoteReportByDate(ref IQueryable<View_ReportDebitNote> tar, string dTSting)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dTSting);
        tar = from q in tar
              where q.reportDate.Value.Year == dt.Year && q.reportDate.Value.Month == dt.Month && q.reportDate.Value.Day == dt.Day
              select q;
    }

    public void findDebitNoteReportByDate(ref IQueryable<View_ReportDebitNote> tar, DateTime dt, DateTime dtTo)
    {
        DateTime dtE = dtTo.AddDays(1).AddMinutes(-1);
        tar = from q in tar
              where (q.reportDate.Value <= dtE && q.reportDate.Value >= dt) || (q.UpdateDate <= dtE && q.UpdateDate >= dt)
              select q;
    }

    public void findDebitNoteReportByDate(ref IQueryable<View_ReportDebitNote> tar, string dTSting, string dtToString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dTSting);
        DateTime dtTo = DateTimeHelper.convertStringToDateTime(dtToString);
        DateTime dtE = dtTo.AddDays(1).AddMinutes(-1);
        tar = from q in tar
              where (q.reportDate.Value <= dtE && q.reportDate.Value >= dt) || (q.UpdateDate <= dtE && q.UpdateDate >= dt)
              select q;
    }


    public void findDebitNoteReportByFeeEarner(ref IQueryable<View_ReportDebitNote> tar, string feeEarnerId)
    {
        Guid feeId = new Guid(feeEarnerId);
        var temp = tar;
        var findMatterId = (from q in db.MatterAndFeeEarners
                            where temp.Select(p => p.matterNumId).Contains(q.matterId) && q.feeEarnerId == feeId
                            select q.matterId).Distinct().ToArray();

        tar = from q in temp
              where findMatterId.Contains(q.matterNumId)
              select q;
    }

    public void findDebitNoteReportByMatterNumId(ref IQueryable<View_ReportDebitNote> tar, string tarId)
    {
        Guid id = new Guid(tarId);
        tar = from q in tar
              where q.matterNumId == id
              select q;
    }
    public void findDebitNoteReportBySubject(ref IQueryable<View_ReportDebitNote> tar, string subject)
    {
        //tar = from q in tar
        //      where q.status == status
        //      select q;

        var findMatterIdBySubject = (from q in db.MatterCores
                                     where q.matterSubject == subject
                                     select q.id).ToArray();
        var temp = tar;
        tar = from q in temp
              where findMatterIdBySubject.Contains(q.matterNumId)
              select q;
    }

    public void findDebitNoteReportByStatus(ref IQueryable<View_ReportDebitNote> tar, string status)
    {
        tar = from q in tar
              where q.status == status
              select q;
    }

    public void findDebitNoteReportById(ref IQueryable<View_ReportDebitNote> tar, string tarId)
    {
        Guid id = new Guid(tarId);
        tar = from q in tar
              where q.id == id
              select q;
    }


    //public List<DDLValueDto> getDebitNoteUser(DateTime dt)
    //{
    //    List<DDLValueDto> result = new List<DDLValueDto>();
    //    var findTar = findDebitNoteReport();

    //    findDebitNoteReportByDate(ref findTar, dt);

    //    var findResult = (from q in db.MatterAndFeeEarners
    //                      where findTar.Select(p => p.matterNumId).Contains(q.matterId)
    //                      select q.feeEarnerId).Distinct().ToArray();

    //    foreach (var item in findResult)
    //    {
    //        DDLValueDto resultDto = new DDLValueDto();
    //        resultDto.id = Convert.ToString(item);
    //        resultDto.value = getUserNameBySystemId(item);
    //        result.Add(resultDto);
    //    }


    //    result.Sort((a, b) => String.Compare(a.value, b.value));
    //    return result;
    //}

    //public List<DDLValueDto> getDebitNoteUser(DateTime dt, DateTime dtTo)
    //{
    //    List<DDLValueDto> result = new List<DDLValueDto>();
    //    var findTar = findDebitNoteReport();

    //    findDebitNoteReportByDate(ref findTar, dt, dtTo);

    //    var findResult = (from q in db.MatterAndFeeEarners
    //                      where findTar.Select(p => p.matterNumId).Contains(q.matterId)
    //                      select q.feeEarnerId).Distinct().ToArray();

    //    foreach (var item in findResult)
    //    {
    //        DDLValueDto resultDto = new DDLValueDto();
    //        resultDto.id = Convert.ToString(item);
    //        resultDto.value = getUserNameBySystemId(item);
    //        result.Add(resultDto);
    //    }


    //    result.Sort((a, b) => String.Compare(a.value, b.value));
    //    return result;
    //}

    public List<DDLValueDto> getDebitNoteFeeEarner(IQueryable<View_ReportDebitNote> findTar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = (from q in db.MatterAndFeeEarners
                          where findTar.Select(p => p.matterNumId).Contains(q.matterId)
                          select q.feeEarnerId).Distinct().ToArray();

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item);
            resultDto.value = getUserNameBySystemId(item);
            result.Add(resultDto);
        }

        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }



    //public List<DDLValueDto> getDebitNoteMatterNum(DateTime dt, string userGuidTar)
    //{
    //    List<DDLValueDto> result = new List<DDLValueDto>();
    //    var findTar = findDebitNoteReport();

    //    findDebitNoteReportByDate(ref findTar, dt);
    //    Guid feeEarnerId = new Guid(userGuidTar);

    //    var findMatterId = (from q in db.MatterAndFeeEarners
    //                        where findTar.Select(p => p.matterNumId).Contains(q.matterId) && q.feeEarnerId == feeEarnerId
    //                        select q.matterId).Distinct().ToArray();

    //    var findResult = (from q in findTar
    //                      where findMatterId.Contains(q.matterNumId)
    //                      select q.matterNumId).Distinct().ToArray();


    //    foreach (var item in findResult)
    //    {
    //        DDLValueDto resultDto = new DDLValueDto();
    //        resultDto.id = Convert.ToString(item);
    //        resultDto.value = getMatterNum(item);
    //        result.Add(resultDto);
    //    }

    //    result.Sort((a, b) => String.Compare(a.value, b.value));
    //    return result;
    //}

    //public List<DDLValueDto> getDebitNoteMatterNum(DateTime dt, string userGuidTar, DateTime dtTo)
    //{
    //    List<DDLValueDto> result = new List<DDLValueDto>();
    //    var findTar = findDebitNoteReport();

    //    findDebitNoteReportByDate(ref findTar, dt, dtTo);
    //    Guid feeEarnerId = new Guid(userGuidTar);

    //    var findMatterId = (from q in db.MatterAndFeeEarners
    //                        where findTar.Select(p => p.matterNumId).Contains(q.matterId) && q.feeEarnerId == feeEarnerId
    //                        select q.matterId).Distinct().ToArray();

    //    var findResult = (from q in findTar
    //                      where findMatterId.Contains(q.matterNumId)
    //                      select q.matterNumId).Distinct().ToArray();


    //    foreach (var item in findResult)
    //    {
    //        DDLValueDto resultDto = new DDLValueDto();
    //        resultDto.id = Convert.ToString(item);
    //        resultDto.value = getMatterNum(item);
    //        result.Add(resultDto);
    //    }

    //    result.Sort((a, b) => String.Compare(a.value, b.value));
    //    return result;
    //}

    public List<DDLValueDto> getDebitNoteMatterNum(IQueryable<View_ReportDebitNote> findTar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();
        foreach (var item in findTar)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.matterNumId);
            resultDto.value = getMatterNum(item.matterNumId);
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> getDebitNoteMatterSubject(IQueryable<View_ReportDebitNote> findTar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();
        foreach (var item in findTar)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = getMatterSubject(item.matterNumId);
            resultDto.value = getMatterSubject(item.matterNumId);
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }
    public List<DDLValueDto> getDebitNoteMatterStatus(IQueryable<View_ReportDebitNote> findTar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();
        foreach (var item in findTar)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = item.status;
            resultDto.value = setDebitNoteStatus(item.status);
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
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


    private string getMatterNum(Guid id)
    {
        var result = db.MatterCores.Where(p => p.id == id).FirstOrDefault();
        return result.matterNum;
    }
    private string getMatterSubject(Guid id)
    {
        var result = db.MatterCores.Where(p => p.id == id).FirstOrDefault();
        return result.matterSubject;
    }


    public string getDebitNoteReportContent(View_ReportDebitNote tarView)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        var findCost = db.DebitNoteCosts.Where(p => p.debitNoteId == tarView.id);
        var findMisc = db.DebitNoteMiscs.Where(p => p.debitNoteId == tarView.id);
        var findDisursement = db.DebitNoteDisbursements.Where(p => p.debitNoteId == tarView.id);

        sb.Append("<div style=" + '"' + "height:600px;" + '"' + ">");

        foreach (var item in findCost)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);
            if (item.cost.HasValue)
            {
                sb.Append(" $");
                sb.Append(item.cost.Value);
            }
            setNextLine(ref sb);
        }

        setNextLine(ref sb);
        setNextLine(ref sb);

        foreach (var item in findDisursement)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);
            if (item.cost.HasValue)
            {
                sb.Append(" $");
                sb.Append(item.cost.Value);
            }
            setNextLine(ref sb);
        }

        setNextLine(ref sb);

        foreach (var item in findMisc)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);
            if (item.cost.HasValue)
            {
                sb.Append(" $");
                sb.Append(item.cost.Value);
            }
            setNextLine(ref sb);
        }

        setNextLine(ref sb);

        sb.Append(String.Format("Total: ${0:0.00}", tarView.price));
        sb.Append("</div>");
        return sb.ToString();
    }


    public List<ReportNewDeebitNoteHr> reportMainEntry(string debitNoteId, string getDate, string getDateTo, string getFee, string getId, string getSubject, string getStatus, string dType)
    {

        IQueryable<RBJLLawFirmDBModel.View_ReportDebitNote> findDebitNote;
        if (debitNoteId != null)
        {
            findDebitNote = findDebitNoteReportAll();
        }
        else
        {
            findDebitNote = findDebitNoteReport();
        }

        if (getDate != null)
        {
            findDebitNoteReportByDate(ref findDebitNote, getDate, getDateTo);
        }
        if (getFee != null)
        {
            findDebitNoteReportByFeeEarner(ref findDebitNote, getFee);
        }
        if (getId != null)
        {
            findDebitNoteReportByMatterNumId(ref findDebitNote, getId);
        }

        if (getSubject != null)
        {
            findDebitNoteReportBySubject(ref findDebitNote, getSubject);
        }

        if (getStatus != null)
        {
            findDebitNoteReportByStatus(ref findDebitNote, getStatus);
        }

        if (debitNoteId != null)
        {
            findDebitNoteReportById(ref findDebitNote, debitNoteId);
        }

        List<string> completeBgList = getCompleteBgImg(dType);


        int count = 1;

        List<ReportNewDeebitNoteHr> result = new List<ReportNewDeebitNoteHr>();

        foreach (var item in findDebitNote)
        {
            var DebitNoteHr = getDebitNoteHr(item.reportDate, item.debitNoteNum, item.category);
            foreach (var debitNoteHr in DebitNoteHr)
            {

                foreach (var bg in completeBgList)
                {
                    ReportNewDeebitNoteHr temp = new ReportNewDeebitNoteHr();

                    temp.id = Convert.ToString(count);
                    temp.dNNum = debitNoteHr;
                    if (item.reportDate.HasValue)
                    {
                        temp.date = DateTimeHelper.convertDateTimeToString(item.reportDate.Value);
                    }
                    temp.refValue = item.@ref;
                    temp.yourRefValue = item.yourRef;

                    temp.billToName = item.billTo;
                    temp.address = item.address;

                    try
                    {
                        if (!String.IsNullOrEmpty(item.contactPersonList))
                        {
                            var getAttToArr = item.contactPersonList.Split('◎');
                            List<string> getAttToList = new List<string>();
                            List<string> getAttEmailList = new List<string>();

                            foreach (var tar in getAttToArr)
                            {
                                getAttToList.Add(tar.Split('●')[0]);
                                getAttEmailList.Add(tar.Split('●')[1]);
                            }
                            if (getAttToList.Count() != 0 && !String.IsNullOrEmpty(item.subRef))
                            {
                                temp.attnTo = String.Format("Attn.:{0} ({1})", String.Join(",", getAttToList.ToArray()), item.subRef);
                            }
                            else if (getAttToList.Count() != 0 && String.IsNullOrEmpty(item.subRef))
                            {
                                temp.attnTo = String.Format("Attn.:{0}", String.Join(",", getAttToList.ToArray()));
                            }
                            else if (getAttToList.Count() == 0 && !String.IsNullOrEmpty(item.subRef))
                            {
                                temp.attnTo = String.Format("Attn.:({0})", item.subRef);
                            }
                            if (getAttEmailList.Count() != 0 && item.isEnable.HasValue && item.isEnable.Value)
                            {
                                temp.attnTo = String.Format("{0}<br />{1}", temp.attnTo, String.Join(",",getAttEmailList.ToArray()));
                            }
                        }
                    }
                    catch
                    {

                    }
                    temp.debitNoteid = item.id.ToString();
                    if (!String.IsNullOrEmpty(item.ioNum))
                    {
                        temp.ioNum = item.ioNum;
                    }


                    if (bg.Contains("account"))
                    {
                        temp.isShowFooter = "a";
                    }
                    else if (bg.Contains("receipt"))
                    {
                        temp.isShowFooter = "r";
                    }
                    else
                    {
                        temp.isShowFooter = "n";
                    }

                    temp.bgValue = bg;
                    count++;
                    result.Add(temp);
                }

            }
        }
        return result;
    }

    private List<string> getCompleteBgImg(string type)
    {
        List<string> result = new List<string>();
        var tempImage = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, "/images/reportImg/DebiNoteMain/{0}.jpg");

        if (type == "C")
        {
            result.Add(string.Format(tempImage, "account"));
            result.Add(string.Format(tempImage, "file"));
            result.Add(string.Format(tempImage, "empty"));
            result.Add(string.Format(tempImage, "receipt"));
        }
        else
        {
            result.Add(string.Format(tempImage, "empty"));
        }

        return result;
    }


    private List<string> getDebitNoteHr(DateTime? reportDate, string debitNoteNum, string category)
    {
        List<string> result = new List<string>();

        string tarYear = "";

        if (reportDate.HasValue)
        {
            tarYear = String.Format("{0:yy}", reportDate.Value);
        }

        //string getType = Request[QueryStringConst.type];

        string getType = category;
        if (getType != null)
        {
            var tempArr = getType.Split(',');
            foreach (var item in tempArr)
            {
                var tarString = item.Substring(0, 1);
                if (item.Equals("Trademark"))
                {
                    result.Add(String.Format("{0}{1}/{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("General"))
                {
                    result.Add(String.Format("{0}{1}/{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("Patent"))
                {
                    result.Add(String.Format("{0}{1}/{2}", tarString, tarYear, debitNoteNum));
                }

                else if (item.Equals("Notary Public"))
                {
                    result.Add(String.Format("{0}{1}/{2}", tarString, tarYear, debitNoteNum));
                }
            }
        }
        else
        {
            result.Add(String.Format("{0}", debitNoteNum));
        }
        return result;

    }


    public List<DebitNoteSubReportDto> setDebitNoteSubject(string debitNoteIdValue)
    {
        List<DebitNoteSubReportDto> result = new List<DebitNoteSubReportDto>();
        Guid debitnoteId = new Guid(debitNoteIdValue);
        var findDebitNote = db.DebitNoteCores.Where(p => p.id == debitnoteId).FirstOrDefault();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (findDebitNote.SubjectType == "1")
        {
            var findSubjectT = db.DebitNoteSubjectTs.Where(q => q.debitNoteId == findDebitNote.id);
            foreach (var tar in findSubjectT)
            {
                if (tar.TTypeOfWork != "-1")
                {
                    sb.AppendLine(String.Format("Type of work: {0}", tar.TTypeOfWork));
                    setNextLine(ref sb);
                }
                if (tar.TIsOpponent != "-1")
                {
                    sb.AppendLine(String.Format("{0}: {1}", tar.TIsOpponent, tar.TOpponentValue));
                    setNextLine(ref sb);
                }
                if (!String.IsNullOrEmpty(tar.TRoleTypeValue))
                {
                    sb.AppendLine(String.Format("{0}: {1}", tar.TRoleType, tar.TRoleTypeValue));
                    setNextLine(ref sb);
                }
                //logo
                if (!String.IsNullOrEmpty(tar.TrademarkNum))
                {
                    sb.AppendLine(String.Format("{0}: {1}", "Trademark No.", tar.TrademarkNum));
                    setNextLine(ref sb);
                }
                if (!String.IsNullOrEmpty(tar.TClass))
                {
                    sb.AppendLine(String.Format("{0}: {1}", "Class(es)", tar.TClass));
                    setNextLine(ref sb);
                }
                sb.AppendLine(String.Format("{0}: {1}", "Country", tar.Country));

                if (!String.IsNullOrEmpty(tar.TrademarkLogoDescription))
                {
                    setNextLine(ref sb);
                    sb.AppendLine(String.Format("{0}: {1}", "Trade Mark Description", tar.TrademarkLogoDescription));
                }

                if (!String.IsNullOrEmpty(tar.TrademarkLogo))
                {
                    string tempPath = tar.TrademarkLogo.Substring(1, tar.TrademarkLogo.Length - 1);
                    var url = String.Format("{0}{1}{2}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), HttpRuntime.AppDomainAppVirtualPath, tempPath);
                    result.Add(new DebitNoteSubReportDto { subjectValue = sb.ToString(), logo = url });
                }
                else
                {
                    result.Add(new DebitNoteSubReportDto { subjectValue = sb.ToString() });
                }
                sb.Clear();
            }
        }
        else if (findDebitNote.SubjectType == "2")
        {
            var findSubjectP = db.DebitNoteSubjectPs.Where(q => q.debitNoteId == findDebitNote.id);
            foreach (var tar in findSubjectP)
            {
                if (sb.Length > 1)
                {
                    setNextLine(ref sb);
                    setNextLine(ref sb);
                }
                if (tar.PStageValue != "-1")
                {
                    sb.AppendLine(String.Format("{0}: {1}", "Stage", tar.PStageValue));
                    setNextLine(ref sb);
                }
                if (!String.IsNullOrEmpty(tar.PRoleProprietorApplicanValue))
                {
                    sb.AppendLine(String.Format("{0}: {1}", tar.PRoleProprietorApplican, tar.PRoleProprietorApplicanValue));

                    setNextLine(ref sb);
                }
                if (!String.IsNullOrEmpty(tar.PAssignee))
                {
                    sb.AppendLine(String.Format("{0}: {1}", "Assignee", tar.PAssignee));
                    setNextLine(ref sb);
                }
                if (!String.IsNullOrEmpty(tar.PTitle))
                {
                    sb.AppendLine(String.Format("{0}: {1}", "Title", tar.PTitle));
                    setNextLine(ref sb);
                }
                if (!String.IsNullOrEmpty(tar.PDesignOrPatentNumValue))
                {
                    sb.AppendLine(String.Format("{0}: {1}", tar.PDesignOrPatentNum, tar.PDesignOrPatentNumValue));
                    setNextLine(ref sb);
                }
                sb.AppendLine(String.Format("{0}: {1}", "Country", tar.Country));

                if (tar.PNationalPhase != "-1")
                {
                    setNextLine(ref sb);
                    sb.AppendLine(String.Format("{2}: {0} {1}", tar.PNationalPhase, tar.PPriorityValue, "Priority"));
                }
            }
            result.Add(new DebitNoteSubReportDto { subjectValue = sb.ToString() });
        }
        else
        {
            sb.Append(findDebitNote.subject);
            result.Add(new DebitNoteSubReportDto { subjectValue = sb.ToString() });
        }

        return result;
    }

    public List<ReportNewDebitNote> setDebitNoteCont(string debitNoteIdValue)
    {
        Guid debitnoteId = new Guid(debitNoteIdValue);
        var findDebitNote = db.DebitNoteCores.Where(p => p.id == debitnoteId).FirstOrDefault();

        var findCost = db.DebitNoteCosts.Where(p => p.debitNoteId == debitnoteId).OrderBy(q => q.orderByValue);
        var findMisc = db.DebitNoteMiscs.Where(p => p.debitNoteId == debitnoteId).OrderBy(q => q.orderByValue);
        var findDisursement = db.DebitNoteDisbursements.Where(p => p.debitNoteId == debitnoteId).OrderBy(q => q.orderByValue);

        var getIsDiscount = findDebitNote.isDiscount.HasValue ? findDebitNote.isDiscount.Value : false;
        var getDiscountValue = findDebitNote.DiscountValue;

        var getNa = db.DebitNoteNarratives.Where(p => p.debitNoteId == debitnoteId);

        double naTotal = 0;

        foreach (var item in getNa)
        {
            if (!item.isCountTotal.HasValue || item.isCountTotal.Value == true)
            {
                if (item.timespan.HasValue && item.hourlyRateH.HasValue)
                {
                    naTotal += item.timespan.Value * item.hourlyRateH.Value;
                }
                else if (item.fixedCost.HasValue)
                {
                    naTotal += item.fixedCost.Value;
                }
            }
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        List<ReportNewDebitNote> result = new List<ReportNewDebitNote>();

        if (findCost.Count() != 0 && findDisursement.Count() != 0)
        {
            result.Add(new ReportNewDebitNote() { description = setBold("TO OUR PROFESSIONAL CHARGES: ") });
        }

        double totalCost = 0;
        double totalMisc = 0;
        double totalDisursement = 0;
        int i = 0;

        foreach (var item in findCost)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                //setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);

            if (item.cost.HasValue)
            {
                totalCost += item.cost.Value;
                //result.Add(new ReportNewDebitNote() { description = sb.ToString(), price = String.Format("HK${0:#,0.#0}", item.cost.Value) });

                result.Add(new ReportNewDebitNote() { description = sb.ToString() });
                result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("HK${0:#,0.#0}", item.cost.Value)) });
                i++;
            }
            else
            {
                result.Add(new ReportNewDebitNote() { description = sb.ToString() });
            }

            sb.Clear();
        }

        if (naTotal != 0)
        {
            //result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("Our Costs: HK${0:#,0.#0}", naTotal)) });
            //result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("HK${0:#,0.#0}", naTotal)) });
            result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("HK${0:#,0.#0}", naTotal)) });
            i++;
            totalCost += naTotal;
        }

        if (findCost.Count() != 0)
        {
            if (getIsDiscount && getDiscountValue != 100)
            {
                //result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("Total Costs: HK${0:#,0.#0}", totalCost)) });
                //result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("HK${0:#,0.#0}", totalCost)) });
                //result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("Less {0}%:HK${1:#,0.#0}", (100 - getDiscountValue), ((100.0 - getDiscountValue) * totalCost / 100.0))), price = String.Format("HK${0:#,0.#0}", getDiscountValue * totalCost / 100) });
                result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("Less: {0}% discount", (100 - getDiscountValue), ((100.0 - getDiscountValue) * totalCost / 100.0))), price = String.Format("HK${0:#,0.#0}", getDiscountValue * totalCost / 100) });

            }


            else if (findDebitNote.butSay.HasValue)
            {
                result.Add(new ReportNewDebitNote() { description = setStyleRight("BUT SAY:"), price = setDoubleUnderLine(String.Format("HK${0:#,0.#0}", findDebitNote.butSay.Value)) });
            }
            else
            {
                if (i <= 1)
                {
                    //result.Add(new ReportNewDebitNote() { description = setStyleRight("Total Costs:"), price = String.Format("HK${0:#,0.#0}", totalCost) });
                    result.Add(new ReportNewDebitNote() { price = String.Format("HK${0:#,0.#0}", totalCost) });
                    //result.Add(new ReportNewDebitNote() { description = setStyleRight("Sub-total:"), price = String.Format("HK${0:#,0.#0}", totalCost) });
                }
                else
                {
                    result.Add(new ReportNewDebitNote() { description = setStyleRight("Sub-total:"), price = String.Format("HK${0:#,0.#0}", totalCost) });
                }
            }
        }

        ////
        if (findMisc.Count() != 0)
        {
            result.Add(new ReportNewDebitNote() { description = setUnderLine(setBold("DISBURSEMENTS")) });
        }
        foreach (var item in findMisc)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                //setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);

            result.Add(new ReportNewDebitNote() { description = sb.ToString() });
            //var t1 = setSpanStyleLeft(sb.ToString());
            //var t2 = setSpanStyleRight(String.Format("HK${0:#,0.#0}", item.cost.Value));
            //var testing = setSapnLAndR(t1, t2);
            //result.Add(new ReportNewDebitNote() { description = testing });

            if (item.cost.HasValue)
            {
                totalMisc += item.cost.Value;
                result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("HK${0:#,0.#0}", item.cost.Value)) });
            }
            sb.Clear();
        }


        if (findMisc.Count() != 0)
        {
            if (getIsDiscount)
            {
                result.Add(new ReportNewDebitNote() { price = String.Format("HK${0:#,0.#0}", totalMisc) });
            }
            else
            {
                result.Add(new ReportNewDebitNote() { price = String.Format("HK${0:#,0.#0}", totalMisc) });
            }
            //description = setStyleRight("Our Miscs:"),
        }
        ////

        if (findDisursement.Count() != 0)
        {
            result.Add(new ReportNewDebitNote() { description = setUnderLine(setBold("DISBURSEMENTS")) });
        }

        foreach (var item in findDisursement)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                //setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);

            result.Add(new ReportNewDebitNote() { description = sb.ToString() });
            //var t1 = setSpanStyleLeft(sb.ToString());
            //var t2 = setSpanStyleRight(String.Format("HK${0:#,0.#0}", item.cost.Value));
            //var testing = setSapnLAndR(t1, t2);
            //result.Add(new ReportNewDebitNote() { description = testing });

            if (item.cost.HasValue)
            {
                totalDisursement += item.cost.Value;
                result.Add(new ReportNewDebitNote() { description = setStyleRight(String.Format("HK${0:#,0.#0}", item.cost.Value)) });
            }
            sb.Clear();
        }


        if (findDisursement.Count() != 0)
        {
            if (getIsDiscount)
            {
                result.Add(new ReportNewDebitNote() { price = String.Format("HK${0:#,0.#0}", totalDisursement) });

            }
            else
            {
                result.Add(new ReportNewDebitNote() { price = String.Format("HK${0:#,0.#0}", totalDisursement) });
            }
            //description = setStyleRight("Our Disursements:"),
        }

        //if (findDisursement != null)
        //{
        //    System.Text.StringBuilder nF = new System.Text.StringBuilder();
        //    nF.Append("If you wish to pay this debit note in");
        //    setNextLine(ref nF);
        //    nF.Append("United States currency please adopt");
        //    setNextLine(ref nF);
        //    nF.Append("the rate of exchange HK$7.60=US$1.00.");
        //    setNextLine(ref nF);
        //    nF.Append("Weawait your remittance of US$");

        //    var nFString = setBold(nF.ToString());
        //    result.Add(new ReportNewDebitNote() { description = nFString }); result.Add(new ReportNewDebitNote() { description = nFString });
        //}

        if (findDebitNote.depositAccount.HasValue)
        {
            result.Add(new ReportNewDebitNote() { description = setStyleRight("LESS: DEPOSIT ON ACCOUNT"), price = String.Format("(HK${0:#,0.#0})", findDebitNote.depositAccount.Value) });
        }

        //if (getIsDiscount)
        //{
        //    result.Add(new ReportNewDebitNote() { description = setStyleRight("Total:"), price = setDoubleUnderLine(String.Format("HK${0:#,0.#0}", findDebitNote.price)), isTotal = "T" });
        //}
        //else
        //{
        //    result.Add(new ReportNewDebitNote() { description = setStyleRight("(BUT SAY)Total:"), price = setDoubleUnderLine(String.Format("HK${0:#,0.#0}", findDebitNote.price)), isTotal = "T" });
        //}

        result.Add(new ReportNewDebitNote() { description = setStyleRight("Total:"), price = setDoubleUnderLine(String.Format("HK${0:#,0.#0}", findDebitNote.price)), isTotal = "T" });

        var tarCurr = findDebitNote.CurrencySymbol;
        if (!String.IsNullOrEmpty(tarCurr) && (tarCurr.ToUpper() != "HKD" && tarCurr.ToUpper() != "HK"))
        {

            var findCurrInfo = db.CurrencyRates.Where(q => q.symbol.Contains(tarCurr));
            if (findCurrInfo.Count() > 0)
            {
                var tarCurrInfo = findCurrInfo.First();
                System.Text.StringBuilder nF = new System.Text.StringBuilder();
                //nF.Append("If you wish to pay this debit note in");
                //setNextLine(ref nF);
                //nF.Append(String.Format("{0} currency please adopt", tarCurrInfo.currencyName));
                //setNextLine(ref nF);
                //nF.Append(String.Format("the rate of exchange HK${1:#,0.#0}={0}$1.00.", tarCurrInfo.symbol, tarCurrInfo.rateToHK));
                //setNextLine(ref nF);
                nF.Append(String.Format("If you wish to pay this debit note in {0} currency,", tarCurrInfo.currencyName));
                setNextLine(ref nF);
                nF.Append(String.Format("please adopt the rate of exchange HK${1:#,0.#0}={0}$1.00.", tarCurrInfo.symbol, tarCurrInfo.rateToHK));
                setNextLine(ref nF);
                nF.Append(String.Format("We await your remittance {0}${1:#,0.#0}", tarCurrInfo.symbol, (1 / tarCurrInfo.rateToHK) * findDebitNote.price));

                var nFString = (nF.ToString());
                result.Add(new ReportNewDebitNote() { description = nFString });
            }
        }

        //for (int i = result.Count; i <= 10; i++)
        //{
        //    result.Add(new ReportNewDebitNote());
        //}
        return result;
    }

    public List<ReportDebitNoteMainContent> setDebitNoteMainCont(string debitNoteIdValue)
    {
        Guid debitnoteId = new Guid(debitNoteIdValue);
        var findDebitNote = db.DebitNoteCores.Where(p => p.id == debitnoteId).FirstOrDefault();

        var findCost = db.DebitNoteCosts.Where(p => p.debitNoteId == debitnoteId).OrderBy(q => q.orderByValue);
        var findMisc = db.DebitNoteMiscs.Where(p => p.debitNoteId == debitnoteId).OrderBy(q => q.orderByValue);
        var findDisursement = db.DebitNoteDisbursements.Where(p => p.debitNoteId == debitnoteId).OrderBy(q => q.orderByValue);

        var getIsDiscount = findDebitNote.isDiscount.HasValue ? findDebitNote.isDiscount.Value : false;
        var getDiscountValue = findDebitNote.DiscountValue;

        var getNa = db.DebitNoteNarratives.Where(p => p.debitNoteId == debitnoteId);

        double naTotal = 0;
        bool setNaT = true;

        foreach (var item in getNa)
        {
            if (!item.isCountTotal.HasValue || item.isCountTotal.Value == true)
            {
                if (item.timespan.HasValue && item.hourlyRateH.HasValue)
                {
                    naTotal += item.timespan.Value * item.hourlyRateH.Value;
                }
                else if (item.fixedCost.HasValue)
                {
                    naTotal += item.fixedCost.Value;
                }
            }
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        List<ReportDebitNoteMainContent> result = new List<ReportDebitNoteMainContent>();


        var getSubjectArr = setDebitNoteSubject(debitNoteIdValue);


        foreach (var getSubject in getSubjectArr)
        {
            ReportDebitNoteMainContent tempMC = new ReportDebitNoteMainContent();
            tempMC.description = setBold(getSubject.subjectValue);
            tempMC.logoPath = getSubject.logo;
            result.Add(tempMC);
        }

        if (getSubjectArr.Count != 0)
        {
            result.Add(new ReportDebitNoteMainContent() { isSubjectEnd = "T" });
        }

        if ((findDebitNote.mustShowHeader ?? true) || (findCost.Count() != 0 && findDisursement.Count() != 0))
        {
            result.Add(new ReportDebitNoteMainContent() { description = setUnderLine(setBold("TO OUR PROFESSIONAL CHARGES for services rendered")) });
        }

        double totalCost = 0;
        double totalMisc = 0;
        double totalDisursement = 0;
        int i = 0;
        int y = 0;
        if (naTotal != 0)
        {
            //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("Our Costs: HK${0:#,0.#0}", naTotal)) });
            //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("HK${0:#,0.#0}", naTotal)) });
            if (setNaT && (findDebitNote.customSortingCheckBox ?? true))
            {
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("HK${0:#,0.#0}", naTotal)) });
                i++;
            }
            totalCost += naTotal;
        }
        //int first=0;
        foreach (var item in findCost)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                //setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);

            if (item.cost.HasValue)
            {
                if (item.cost.Value > 0)
                {
                    totalCost += item.cost.Value;

                    //result.Add(new ReportDebitNoteMainContent() { description = sb.ToString(), price = String.Format("HK${0:#,0.#0}", item.cost.Value) });

                    result.Add(new ReportDebitNoteMainContent() {description =  sb.ToString(), subPrice = String.Format("HK${0:#,0.#0}", item.cost.Value) });
                }
                else if (item.cost.Value == -1)
                {
                    if (naTotal != 0 && setNaT)
                    {
                        setNaT = false;
                        result.Add(new ReportDebitNoteMainContent() { description = sb.ToString(), subPrice = String.Format("HK${0:#,0.#0}", naTotal) });
                    }
                    else
                    {
                        result.Add(new ReportDebitNoteMainContent() { description = sb.ToString() });
                    }
                }
                //result.Add(new ReportDebitNoteMainContent() { description = sb.ToString() });
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("HK${0:#,0.#0}", item.cost.Value)) });
                i++;
            }
            else
            {
                if ((findDebitNote.customSortingCheckBox ?? true)){
                    result.Add(new ReportDebitNoteMainContent() { description = sb.ToString(), subPrice = String.Format("HK${0:#,0.#0}", naTotal) });
                //    first=1;
                }
            }

            sb.Clear();
        }
        if (naTotal != 0)
        {
            //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("Our Costs: HK${0:#,0.#0}", naTotal)) });
            //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("HK${0:#,0.#0}", naTotal)) });
            if (setNaT && !(findDebitNote.customSortingCheckBox ?? true))
            {
                result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("HK${0:#,0.#0}", naTotal)) });
                i++;
            }
            //totalCost += naTotal;
        }

        if (findCost.Count() != 0)
        {
            result.Add(new ReportDebitNoteMainContent() { isBold = setfontSize("setHr") });

            if (getIsDiscount && getDiscountValue != 100)
            {
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("Total Costs: HK${0:#,0.#0}", totalCost)) });
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("HK${0:#,0.#0}", totalCost)) });
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("Less {0}%:HK${1:#,0.#0}", (100 - getDiscountValue), ((100.0 - getDiscountValue) * totalCost / 100.0))), price = String.Format("HK${0:#,0.#0}", getDiscountValue * totalCost / 100) });
                result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("Less: {0}% discount", (100 - getDiscountValue), ((100.0 - getDiscountValue) * totalCost / 100.0))), price = String.Format("HK${0:#,0.#0}", getDiscountValue * totalCost / 100) });

            }


            else if (findDebitNote.butSay.HasValue)
            {
                result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("BUT SAY:"), price = setDoubleUnderLine(String.Format("HK${0:#,0.#0}", findDebitNote.butSay.Value)) });
            }
            else
            {
                if (i <= 1)
                {
                    //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Total Costs:"), price = String.Format("HK${0:#,0.#0}", totalCost) });
                    //result.Add(new ReportDebitNoteMainContent() { price = String.Format("HK${0:#,0.#0}", totalCost) });
                    result.Add(new ReportDebitNoteMainContent() { price = setStyleRight(String.Format("HK${0:#,0.#0}", totalCost)) });
                }
                else
                {
                    result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Sub-total:"), price = setStyleRight(String.Format("HK${0:#,0.#0}", totalCost)) });
                }
            }
        }

        ///
        if (findMisc.Count() != 0)
        {
            result.Add(new ReportDebitNoteMainContent() { description = setUnderLine(setBold("MISCELLANEOUS CHARGES")) });
        }

        foreach (var item in findMisc)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                //setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);


            if (item.cost.HasValue)
            {
                totalMisc += item.cost.Value;
                result.Add(new ReportDebitNoteMainContent() { description = sb.ToString(), subPrice = String.Format("HK${0:#,0.#0}", item.cost.Value) });
                //result.Add(new ReportDebitNoteMainContent() { description = sb.ToString() });
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("HK${0:#,0.#0}", item.cost.Value)) });
                y++;
            }
            else
            {
                result.Add(new ReportDebitNoteMainContent() { description = sb.ToString() });
            }
            sb.Clear();
        }


        if (findMisc.Count() != 0)
        {
            result.Add(new ReportDebitNoteMainContent() { isBold = setfontSize("setHr") });
            /*
            if (getIsDiscount)
            {
                result.Add(new ReportDebitNoteMainContent() { price = String.Format("HK${0:#,0.#0}", totalMisc) });

            }
            else
            {
                result.Add(new ReportDebitNoteMainContent() { price = String.Format("HK${0:#,0.#0}", totalMisc) });
            }*/

            if (y <= 1)
            {
                result.Add(new ReportDebitNoteMainContent() { price = setStyleRight(String.Format("HK${0:#,0.#0}", totalMisc)) });
            }
            else
            {
                result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Sub-total:"), price = setStyleRight(String.Format("HK${0:#,0.#0}", totalMisc)) });
            }

            //description = setStyleRight("Our Miscs:"),
        }
        ///

        if (findDisursement.Count() != 0)
        {
            result.Add(new ReportDebitNoteMainContent() { description = setUnderLine(setBold("DISBURSEMENTS")) });
        }

        foreach (var item in findDisursement)
        {
            if (!String.IsNullOrEmpty(item.templateDetails))
            {
                //setBold(ref sb, item.templateDetails);
            }
            sb.Append(item.description);


            if (item.cost.HasValue)
            {
                totalDisursement += item.cost.Value;
                result.Add(new ReportDebitNoteMainContent() { description = sb.ToString(), subPrice = String.Format("HK${0:#,0.#0}", item.cost.Value) });
                //result.Add(new ReportDebitNoteMainContent() { description = sb.ToString() });
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(String.Format("HK${0:#,0.#0}", item.cost.Value)) });
                y++;
            }
            else
            {
                result.Add(new ReportDebitNoteMainContent() { description = sb.ToString() });
            }
            sb.Clear();
        }


        if (findDisursement.Count() != 0)
        {
            result.Add(new ReportDebitNoteMainContent() { isBold = setfontSize("setHr") });
            /*
            if (getIsDiscount)
            {
                result.Add(new ReportDebitNoteMainContent() { price = String.Format("HK${0:#,0.#0}", totalDisursement) });

            }
            else
            {
                result.Add(new ReportDebitNoteMainContent() { price = String.Format("HK${0:#,0.#0}", totalDisursement) });
            }*/

            if (y <= 1)
            {
                result.Add(new ReportDebitNoteMainContent() { price = setStyleRight(String.Format("HK${0:#,0.#0}", totalDisursement)) });
            }
            else
            {
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Sub-total:"), price = String.Format("HK${0:#,0.#0}", totalDisursement) });
                //result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Sub-total:"), price = setStyleRight(String.Format("HK${0:#,0.#0}", totalDisursement)) });
                if (findDisursement.Count()>1){
                    result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Sub-total:"), price = setStyleRight(String.Format("HK${0:#,0.#0}", totalDisursement)) });
                }else{
                    result.Add(new ReportDebitNoteMainContent() { description = setStyleRight(""), price = setStyleRight(String.Format("HK${0:#,0.#0}", totalDisursement)) });
                }

            }

            //description = setStyleRight("Our Disursements:"),
        }


        if (findDebitNote.depositAccount.HasValue)
        {
            result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("LESS: DEPOSIT ON ACCOUNT"), price = setStyleRight(String.Format("(HK${0:#,0.#0})", findDebitNote.depositAccount.Value)) });
        }

        //if (getIsDiscount)
        //{
        //    result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Total:"), price = setDoubleUnderLine(String.Format("HK${0:#,0.#0}", findDebitNote.price)), isTotal = "T" });
        //}
        //else
        //{
        //    result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("(BUT SAY)Total:"), price = setDoubleUnderLine(String.Format("HK${0:#,0.#0}", findDebitNote.price)), isTotal = "T" });
        //}
        if (findDebitNote.price > 0)
        {
            result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Total:"), price = setStyleRight(setDoubleUnderLine(String.Format("HK${0:#,0.#0}", findDebitNote.price))), isTotal = "T" });
        }
        else
        {
            result.Add(new ReportDebitNoteMainContent() { description = setStyleRight("Total:"), price = setStyleRight(setDoubleUnderLine(String.Format("NIL"))), isTotal = "T" });
        }
        var tarCurr = findDebitNote.CurrencySymbol;
        if (!String.IsNullOrEmpty(tarCurr) && (tarCurr.ToUpper() != "HKD" && tarCurr.ToUpper() != "HK"))
        {

            var findCurrInfo = db.CurrencyRates.Where(q => q.symbol.Contains(tarCurr));
            if (findCurrInfo.Count() > 0)
            {
                var tarCurrInfo = findCurrInfo.First();
                System.Text.StringBuilder nF = new System.Text.StringBuilder();
                nF.Append(String.Format("If you wish to pay this debit note in {0} currency,", tarCurrInfo.currencyName));
                setNextLine(ref nF);
                nF.Append(String.Format("please adopt the rate of exchange HKD{1:#,0.#0}={0}1.00.", tarCurrInfo.symbol, tarCurrInfo.rateToHK));
                setNextLine(ref nF);
                nF.Append(String.Format("We await your remittance {0}{1:#,0.#0}", tarCurrInfo.symbol, (1 / tarCurrInfo.rateToHK) * findDebitNote.price));

                var nFString = setfontSize(nF.ToString());
                result.Add(new ReportDebitNoteMainContent() { description = nFString });
            }
        }

        return result;
    }

    private void setItalic(ref System.Text.StringBuilder sb, string tar)
    {
        sb.Append(String.Format("<i>{0} </i> ", tar));
    }

    private void setBold(ref System.Text.StringBuilder sb, string tar)
    {
        sb.Append(String.Format("<b>{0} </b> ", tar));
    }

    private void setNextLine(ref System.Text.StringBuilder sb)
    {
        sb.Append("<br />");
    }

    private string setBold(string tar)
    {
        return String.Format("<b>{0} </b> ", tar);
    }

    private string setUnderLine(string tar)
    {
        return String.Format("<u>{0} </u> ", tar);
    }

    private string setStyleRight(string tar)
    {
        return String.Format("<div style=" + '"' + "text-align: right" + '"' + ">{0}</div>", tar);
    }

    private string setSpanStyleRight(string tar)
    {
        return String.Format("<span style=" + '"' + "text-align: right;" + '"' + ">{0}</span>", tar);
    }
    private string setSpanStyleLeft(string tar)
    {
        return String.Format("<span style=" + '"' + "text-align: left;" + '"' + ">{0}</span>", tar);
    }

    private string setSapnLAndR(string tarL, string tarR)
    {
        return String.Format("<div>{0}{1}</div>", tarL, tarR);
    }
    private string setfontSize(string tar)
    {
        return String.Format("<div style=" + '"' + "font-size: 9pt;" + '"' + ">{0}</div>", tar);
    }
    private string setfontSize(string tar, string fontSize)
    {
        return String.Format("<div style=" + '"' + "font-size: {1}pt;" + '"' + ">{0}</div>", tar, fontSize);
    }


    private string setDoubleUnderLine(string tar)
    {
        //return String.Format("<span style=" + '"' + "border-bottom: double 3px;" + '"' + "><u>{0} </u></span>", tar);
        return tar;
    }


    public IEnumerable<DebitNoteNarrative> findDebitNoteTimeEntry(string tarId)
    {
        Guid id = new Guid(tarId);
        var result = db.DebitNoteNarratives.Where(q => q.debitNoteId == id).AsEnumerable();
        return result;
    }

    #endregion

    #region FeeEarner

    public List<DDLValueDto> getMatterFeeEarnerClient(DateTime dt, string userGuidTar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getMatterByDateAndFeeEarner(dt, userGuidTar);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.clientId);
            resultDto.value = item.clientName;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> getMatterFeeEarnerClient(DateTime dt, string userGuidTar, DateTime dtTo)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getMatterByDateAndFeeEarner(dt, userGuidTar, dtTo);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.clientId);
            resultDto.value = item.clientName;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }


    public List<DDLValueDto> getMatterFeeEarnerClientAndMatterNum(DateTime dt, string userGuidTar, string clientId)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getMatterByDateAndFeeEarner(dt, userGuidTar);
        findFeeEarnerReportByClient(ref findResult, clientId);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.id);
            resultDto.value = item.matterNum;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> getMatterFeeEarnerClientAndMatterNum(DateTime dt, string userGuidTar, string clientId, DateTime dtTo)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getMatterByDateAndFeeEarner(dt, userGuidTar, dtTo);
        findFeeEarnerReportByClient(ref findResult, clientId);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.id);
            resultDto.value = item.matterNum;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public void findFeeEarnerReportByClient(ref IQueryable<View_FindMatter> tar, string tarId)
    {
        int clientId = Convert.ToInt16(tarId);
        tar = from q in tar
              where q.clientId == clientId
              select q;
    }

    public void findFeeEarnerReportByMatter(ref IQueryable<View_FindMatter> tar, string matterNum)
    {
        tar = from q in tar
              where q.matterNum == matterNum
              select q;
    }

    public IQueryable<MatterDetail> findTimeEntryByMatterId(string matterIdString)
    {
        Guid matterId = new Guid(matterIdString);
        var result = db.MatterDetails.Where(p => p.matterId == matterId);
        return result;
    }

    public void findTimeEntryByIsBillOrUnbill(ref IQueryable<MatterDetail> tar, string isEnableString)
    {
        bool isEnable = Convert.ToBoolean(isEnableString);
        tar = from q in tar
              where q.isEnable == isEnable
              select q;
    }

    //public void findFeeEarnerReportResultByDate()
    //{

    //}

    public void findFeeEarnerReportByBillableOrNonBillable(ref IQueryable<View_FindMatter> tar, string isEnableString)
    {
        bool isEnable = Convert.ToBoolean(isEnableString);
        int asInt = 0;

        var temp = from q in tar.AsEnumerable()
                   where Int32.TryParse(q.matterNum, out asInt) == isEnable
                   select q;

        tar = temp.AsQueryable();
    }




    #endregion



    #region Put away

    public IQueryable<View_FindMatter> findPutAwayReport()
    {
        var result = db.View_FindMatter.Where(p => p.id != new Guid("EE28CD2C-D1C3-45A7-B315-42BAEBF6F830") && p.matterNum != "" && (p.status == "3" || p.status == "4"));
        return result;
    }

    public List<DDLValueDto> getPutAwayUser(DateTime dt)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();
        var findTar = findPutAwayReport();

        findMatterReportByDate(ref findTar, dt);

        var findResult = (from q in db.MatterAndFeeEarners
                          where findTar.Select(p => p.id).Contains(q.matterId)
                          select q.feeEarnerId).Distinct().ToArray();

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item);
            resultDto.value = getUserNameBySystemId(item);
            result.Add(resultDto);
        }
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> getPutAwayUser(DateTime dt, DateTime dtTo)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();
        var findTar = findPutAwayReport();

        findMatterReportByDate(ref findTar, dt, dtTo);

        var findResult = (from q in db.MatterAndFeeEarners
                          where findTar.Select(p => p.id).Contains(q.matterId)
                          select q.feeEarnerId).Distinct().ToArray();

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item);
            resultDto.value = getUserNameBySystemId(item);
            result.Add(resultDto);
        }
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }


    public List<DDLValueDto> getPutAwayFeeEarnerClient(DateTime dt, string userGuidTar)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getPutAwayByDateAndFeeEarner(dt, userGuidTar);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.clientId);
            resultDto.value = item.clientName;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }

    public List<DDLValueDto> getPutAwayFeeEarnerClient(DateTime dt, string userGuidTar, DateTime dtTo)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getPutAwayByDateAndFeeEarner(dt, userGuidTar, dtTo);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.clientId);
            resultDto.value = item.clientName;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }


    private IQueryable<View_FindMatter> getPutAwayByDateAndFeeEarner(DateTime dt, string userGuidTar)
    {
        var findTar = findPutAwayReport();

        findMatterReportByDate(ref findTar, dt);

        Guid feeEarnerId = new Guid(userGuidTar);

        var findMatterId = (from q in db.MatterAndFeeEarners
                            where findTar.Select(p => p.id).Contains(q.matterId) && q.feeEarnerId == feeEarnerId
                            select q.matterId).Distinct().ToArray();

        var findResult = from q in findTar
                         where findMatterId.Contains(q.id)
                         select q;

        return findResult;
    }


    private IQueryable<View_FindMatter> getPutAwayByDateAndFeeEarner(DateTime dt, string userGuidTar, DateTime dtTo)
    {
        var findTar = findPutAwayReport();

        findMatterReportByDate(ref findTar, dt, dtTo);

        Guid feeEarnerId = new Guid(userGuidTar);

        var findMatterId = (from q in db.MatterAndFeeEarners
                            where findTar.Select(p => p.id).Contains(q.matterId) && q.feeEarnerId == feeEarnerId
                            select q.matterId).Distinct().ToArray();

        var findResult = from q in findTar
                         where findMatterId.Contains(q.id)
                         select q;

        return findResult;
    }


    public List<DDLValueDto> getPutAwayFeeEarnerClientAndMatterNum(DateTime dt, string userGuidTar, string clientId)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getPutAwayByDateAndFeeEarner(dt, userGuidTar);
        findFeeEarnerReportByClient(ref findResult, clientId);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.id);
            resultDto.value = item.matterNum;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }
    public List<DDLValueDto> getPutAwayFeeEarnerClientAndMatterNum(DateTime dt, string userGuidTar, string clientId, DateTime dtTo)
    {
        List<DDLValueDto> result = new List<DDLValueDto>();

        var findResult = getPutAwayByDateAndFeeEarner(dt, userGuidTar, dtTo);
        findFeeEarnerReportByClient(ref findResult, clientId);

        foreach (var item in findResult)
        {
            DDLValueDto resultDto = new DDLValueDto();
            resultDto.id = Convert.ToString(item.id);
            resultDto.value = item.matterNum;
            result.Add(resultDto);
        }
        result = result.Distinct(new DistinctDDLValue()).ToList();
        result.Sort((a, b) => String.Compare(a.value, b.value));
        return result;
    }


    public void findPutAwayReportByDate(ref IQueryable<View_FindMatter> tar, string dTString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dTString);
        tar = from q in tar
              where q.putAwayDate.Value.Year == dt.Year && q.putAwayDate.Value.Month == dt.Month && q.putAwayDate.Value.Day == dt.Day
              select q;
    }


    public void findPutAwayReportByDate(ref IQueryable<View_FindMatter> tar, string dTString, string dTToString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dTString);
        DateTime dtTo = DateTimeHelper.convertStringToDateTime(dTToString);
        tar = from q in tar
              where q.putAwayDate.Value <= dtTo && q.putAwayDate >= dt
              select q;
    }


    public List<string> findPutAwayReportPutAwayNum(IQueryable<View_FindMatter> tar)
    {
        List<string> putAwayNumList = new List<string>();

        foreach (var item in tar)
        {
            var putAwayArr = item.putAwayBoxNum.Split(',');
            foreach (var putAwayItem in putAwayArr)
            {
                putAwayNumList.Add(putAwayItem);
            }
        }

        return putAwayNumList.Distinct().ToList();
    }

    public List<PutAwayDto> findPutAwayResult(IQueryable<View_FindMatter> tar, string putAwayNum)
    {
        //var findMatter = findPutAwayReport();

        List<PutAwayDto> result = new List<PutAwayDto>();

        var findResult = from q in tar.AsEnumerable()
                         let putAwayArr = q.putAwayBoxNum.Split(',')
                         where putAwayArr.Contains(putAwayNum)
                         select q;

        foreach (var item in findResult)
        {
            PutAwayDto pAD = new PutAwayDto();
            pAD.id = putAwayNum;
            pAD.client = item.clientName;
            pAD.mattererNum = item.matterNum;
            pAD.subjectMatter = item.matterSubject;
            pAD.files = "";
            pAD.putAwayNum = putAwayNum;

            result.Add(pAD);
        }

        return result;
    }

    #endregion



    #region master

    public IQueryable<Client> getClientInfo
    {
        get
        {
            var result = db.Clients.OrderBy(q => q.clientName);
            return result;
        }
    }

    public IQueryable<Referer> getRefererInfo
    {
        get
        {
            var result = db.Referers.OrderBy(q => q.refererName);
            return result;
        }
    }

    public IQueryable<OutgoingAgent> getOutgoingAgentInfo
    {
        get
        {
            var result = db.OutgoingAgents.OrderBy(q => q.agentName);
            return result;
        }
    }

    public Client findTarClinet(int id)
    {
        var result = db.Clients.Where(q => q.id == id).First();
        return result;
    }

    public Referer findTarReferer(int id)
    {
        var result = db.Referers.Where(q => q.id == id).First();
        return result;
    }

    public OutgoingAgent findTarOutgoingAgent(int id)
    {
        var result = db.OutgoingAgents.Where(q => q.id == id).First();
        return result;
    }


    public void clientInfoCreateDate(ref IQueryable<Client> tar, string dateSrring, string dateToString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dateSrring);
        DateTime dtE = DateTimeHelper.convertStringToDateTime(dateToString).AddDays(1).AddMinutes(-1);
        tar = from q in tar
              where q.CreateDate.Value <= dtE && q.CreateDate.Value >= dt
              select q;
    }

    public void refererInfoCreateDate(ref IQueryable<Referer> tar, string dateSrring, string dateToString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dateSrring);
        DateTime dtE = DateTimeHelper.convertStringToDateTime(dateToString).AddDays(1).AddMinutes(-1);
        tar = from q in tar
              where q.CreateDate.Value <= dtE && q.CreateDate.Value >= dt
              select q;
    }


    public void outgoingAgentInfoCreateDate(ref IQueryable<OutgoingAgent> tar, string dateSrring, string dateToString)
    {
        DateTime dt = DateTimeHelper.convertStringToDateTime(dateSrring);
        DateTime dtE = DateTimeHelper.convertStringToDateTime(dateToString).AddDays(1).AddMinutes(-1);
        tar = from q in tar
              where q.CreateDate.Value <= dtE && q.CreateDate.Value >= dt
              select q;
    }


    #endregion



    public IQueryable<MatterDetail> getTimeEntry
    {
        get
        {
            var findData = from q in db.MatterDetails
                           select q;
            return findData;
        }
    }

    public MatterDetail getMatterDetailById(IQueryable<MatterDetail> tar, int matterDetailId)
    {
        var result = tar.Where(q => q.id == matterDetailId).FirstOrDefault();
        return result;
    }

    public IEnumerable<View_FindMatter> getMatterListData(string matterList)
    {
        var matterArr = matterList.Split(',');
        var findMatter = findMatterReport().AsEnumerable();
        //rI.findMatterReportByDate(ref findMatter, this.TextBoxDate.Text, this.TextBoxDateTo.Text);
        var result = from q in findMatter
                     //where Convert.ToString(q.id).Contains(matterList)
                     where matterArr.Contains(q.id.ToString())
                     select q;
        return result;
    }
}
