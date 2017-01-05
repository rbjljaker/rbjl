using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;

/// <summary>
/// Summary description for MatterInfo
/// </summary>
public class MatterInfo : DBEntity
{
    public MatterInfo()
        : base()
    {
    }

    public MatterInfo(string userName)
        : base(userName)
    {

    }



    public void addMatterAndFeeEarner(List<HourlyRateDto> tarList)
    {
        Guid matterId = new Guid(SessionClass.Identity);
        foreach (var item in tarList)
        {
            MatterAndFeeEarner mAFE = new MatterAndFeeEarner();
            mAFE.matterId = matterId;
            mAFE.feeEarnerId = new Guid(item.userId);

            double tempValue = 0;
            bool checkingD = Double.TryParse(item.hourRate, out tempValue);
            mAFE.hourlyRate = checkingD ? tempValue : 0;

            mAFE.CreateDate = DateTime.Now;
            mAFE.CreateByUserId = base.userGuid;
            db.MatterAndFeeEarners.AddObject(mAFE);
            db.SaveChanges();
        }
    }

    public void addMatterAndHandlingColleague(List<string> tarList)
    {
        Guid matterId = new Guid(SessionClass.Identity);
        foreach (string item in tarList)
        {
            MatterAndHandlingColleague mAHC = new MatterAndHandlingColleague();
            mAHC.matterId = matterId;
            mAHC.handlingColleagueId = new Guid(item);
            mAHC.CreateDate = DateTime.Now;
            mAHC.CreateByUserId = base.userGuid;
            db.MatterAndHandlingColleagues.AddObject(mAHC);
            db.SaveChanges();
        }
    }

    public void updateMatterUser<T>(List<T> tarList, EnumFeeEarnerAndHandlingColleague type)
    {
        Guid matterId = new Guid(HttpContext.Current.Request[QueryStringConst.matter]);
        SessionClass.Identity = matterId.ToString();
        //IQueryable<Guid> existingMatterUser = getMatterUserGuid(matterId, type);

        switch (type)
        {
            case (EnumFeeEarnerAndHandlingColleague.HandlingColleague):
                {
                    List<string> tempList = tarList as List<string>;
                    delMatterHandlingColleagues(matterId);

                    addMatterAndHandlingColleague(tempList);
                    break;
                }
            case (EnumFeeEarnerAndHandlingColleague.FeeEarner):
                {
                    List<HourlyRateDto> tempList = tarList as List<HourlyRateDto>;

                    delMatterFee(matterId);

                    addMatterAndFeeEarner(tempList);
                    break;
                }
        }
    }

    public void delMatterFee(Guid matterId)
    {
        var delTar = db.MatterAndFeeEarners.Where(q => q.matterId == matterId).ToList();

        foreach (var item in delTar)
        {
            db.DeleteObject(item);
            db.SaveChanges();
        }
    }

    public void delMatterHandlingColleagues(Guid matterId)
    {
        var delTar = db.MatterAndHandlingColleagues.Where(q => q.matterId == matterId).ToList();
        foreach (var item in delTar)
        {
            db.DeleteObject(item);
            db.SaveChanges();
        }
    }

    public void delMatterCore(Guid matterId)
    {
        var delTar = db.MatterCores.Where(q => q.id == matterId).ToList();
        foreach (var item in delTar)
        {
            db.DeleteObject(item);
            db.SaveChanges();
        }
    }



    public string getFeeEarnerAndHandlingColleagueByMatterId(Guid matterId, EnumFeeEarnerAndHandlingColleague type)
    {
        string result = null;
        List<string> temp = new List<string>();
        IQueryable<Guid> findResult = getMatterUserGuid(matterId, type);

        if (findResult.Count() > 0)
        {
            foreach (var item in findResult)
            {
                temp.Add(base.getUserNameBySystemId(item));
            }
            temp.Sort();
            result = String.Join(", ", temp.ToArray());

        }
        return result;
    }

    public IQueryable<Guid> getMatterUserGuid(Guid matterId, EnumFeeEarnerAndHandlingColleague type)
    {
        IQueryable<Guid> result;
        switch (type)
        {
            case (EnumFeeEarnerAndHandlingColleague.HandlingColleague):
                {
                    result = db.MatterAndHandlingColleagues.Where(q => q.matterId == matterId).Select(q => q.handlingColleagueId);
                    break;
                }
            case (EnumFeeEarnerAndHandlingColleague.FeeEarner):
            default:
                {
                    result = db.MatterAndFeeEarners.Where(q => q.matterId == matterId).Select(q => q.feeEarnerId);
                    break;
                }
        }
        return result;
    }


    public List<HourlyRateDto> getFeeEarnerHourRateByMatterId(Guid matterId)
    {
        List<HourlyRateDto> result = new List<HourlyRateDto>();

        var tempResult = db.MatterAndFeeEarners.Where(q => q.matterId == matterId);

        foreach (var item in tempResult)
        {
            string userName = base.getUserNameBySystemId(item.feeEarnerId);
            string hourRate = item.hourlyRate.HasValue ? item.hourlyRate.Value.ToString() : "";
            result.Add(new HourlyRateDto() { userName = userName, hourRate = hourRate });
        }



        return result;
    }



    //public IQueryable<MatterCore> findMatterBySeesionId()
    //{
    //    Guid matterId = new Guid(SessionClass.MatterId);
    //    var tarMatter = from q in db.MatterCores
    //                    where q.id == matterId
    //                    select q;
    //    return tarMatter;
    //}



    public IQueryable<MatterCore> findMatterByQueryString()
    {
        Guid matterId = new Guid(HttpContext.Current.Request[QueryStringConst.matter]);
        var tarMatter = from q in db.MatterCores
                        where q.id == matterId
                        select q;
        return tarMatter;
    }

    public IQueryable<MatterCore> findMatterById(string matterIdValue)
    {
        Guid matterId = new Guid(matterIdValue);
        var tarMatter = from q in db.MatterCores
                        where q.id == matterId
                        select q;
        return tarMatter;
    }

    public string findMatterNum()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().matterNum;
    }
    public string findMatterNum(string matterId)
    {
        var tarMatter = findMatterById(matterId);
        return tarMatter.First().matterNum;
    }

    public string findMatterSubject()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().matterSubject;
    }
    public string findMatterSubject(string matterId)
    {
        var tarMatter = findMatterById(matterId);
        return tarMatter.First().matterSubject;
    }

    public string findMatterIO()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().ioNumOfRefererM;
    }

    public string findMatterLogo()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().logo;
    }

    public string findMatterLogo(string matterIdValue)
    {
        var tarMatter = findMatterById(matterIdValue);
        return tarMatter.First().logo;
    }

    public string findMatterUpdateUser()
    {
        var tarMatter = findMatterByQueryString();
        return getUserNameBySystemId(tarMatter.First().UpdateByUserId.Value);
    }

    public string findMatterUpdateDate()
    {
        var tarMatter = findMatterByQueryString();
        return DateTimeHelper.convertDateTimeToString(tarMatter.First().UpdateDate.Value);
    }

    public string findMatterStatus()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().status;
    }

    //public double findMatterHourlyRate()
    //{
    //    var tarMatter = findMatterByQueryString();
    //    return tarMatter.First().hourlyRate;
    //}

    public int? findMatterClientId(string matterIdValue)
    {
        var tarMatter = findMatterById(matterIdValue);
        return tarMatter.First().clientId;
    }

    public int? findMatterClientId()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().clientId;
    }
    public int? findMatterReferId()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().refererId;
    }

    public string findMatterRemark()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().remarks;
    }

    public double? findMatterDiscount()
    {
        var tarMatter = findMatterByQueryString();
        return tarMatter.First().discount;
    }

    //public int findTimeEntryCount()
    //{
    //    Guid matterId = new Guid(SessionClass.MatterId);
    //    var result = db.MatterDetails.Where(p => p.matterId == matterId).Count();
    //    return result;
    //}

    public int findTimeEntryCount()
    {
        int result;
        Guid matterId = new Guid(HttpContext.Current.Request[QueryStringConst.matter]);
        //var result = db.MatterDetails.Where(p => p.matterId == matterId).Count();
        var tar = db.MatterDetails.Where(p => p.matterId == matterId).OrderByDescending(q => q.itemNum).FirstOrDefault();
        if (tar == null)
        {
            result = 0;
        }
        else
        {
            result = Convert.ToInt32(tar.itemNum);
        }
        return result;
    }

    public int findTimeEntryCount(Guid matterId)
    {
        int result;
        var tempResult = db.MatterDetails.Where(p => p.matterId == matterId).OrderByDescending(p => p.itemNum);
        if (tempResult.Count() == 0)
        {
            result = 0;
        }
        else
        {
            result = tempResult.First().itemNum.Value;
        }
        return result;
    }

    public Guid? getMatterIdByMatterNum(string matterNum)
    {
        Guid? result = null;
        var tarMatter = from q in db.MatterCores
                        where q.matterNum == matterNum
                        select q;
        if (tarMatter.Count() > 0)
        {
            result = tarMatter.First().id;
        }
        return result;
    }

    public bool getMatterIdByMatterNum(string matterNumList, ref string matterId, ref string matterIdList)
    {
        //Guid? result = null;
        bool result = true;
        List<string> matterList = new List<string>();

        var tarMatter = (from q in db.MatterCores
                         select q).ToArray();

        var matterNum = matterNumList.Split(',');

        foreach (var item in matterNum)
        {
            var checking = from q in tarMatter
                           where q.matterNum == item
                           select q;

            if (checking.Count() == 0)
            {
                result = false;
                break;
            }
            else
            {
                matterList.Add(checking.FirstOrDefault().id.ToString());
            }
        }

        if (result)
        {
            matterId = matterList[0];
            matterIdList = String.Join(",", matterList);
        }
        return result;
    }



    public View_FindMatter getMatterInfoByMatterId(string matterIdString)
    {
        Guid matterId = new Guid(matterIdString);
        var tarMatter = from q in db.View_FindMatter
                        where q.id == matterId
                        select q;
        return tarMatter.FirstOrDefault();
    }

    public View_ReportDebitNote getDebitNoteByDebitNoteId(string debitNoteString)
    {
        Guid debitNoteId = new Guid(debitNoteString);
        var tarDebitNote = from q in db.View_ReportDebitNote
                           where q.id == debitNoteId
                           select q;
        return tarDebitNote.FirstOrDefault();
    }

    public void addMatterDetail(MatterDetailDto mDD)
    {
        MatterDetail mD = new MatterDetail();

        mD.itemNum = findTimeEntryCount() + 1;
        mD.date = mDD.date;
        //mD.feeEarner = base.userGuid;
        mD.feeEarner = mDD.feeEarner;
        mD.hourlyRateH = mDD.hourlyRateH;
        mD.timespan = mDD.timeSpan;
        mD.fixedCost = mDD.fixedCost;
        mD.templateType = mDD.templateType;
        mD.templateDescription = mDD.templateDescription;
        mD.description = mDD.description;
        mD.matterId = mDD.matterId;

        mD.fixedCostTimeSpan = mDD.fixedCostTimeSpan;

        mD.CreateDate = DateTime.Now;
        mD.CreateByUserId = base.userGuid;
        mD.UpdateDate = DateTime.Now;
        mD.UpdateByUserId = base.userGuid;
        mD.isEnable = true;
        db.MatterDetails.AddObject(mD);
        db.SaveChanges();

        updateMatterlastUpdateTime(mD.matterId);
    }


    public void addMatterDetailPendingList(MatterDetailDto mDD)
    {
        MatterDetail mD = new MatterDetail();

        mD.itemNum = findTimeEntryCount() + 1;
        mD.date = mDD.date;
        //mD.feeEarner = base.userGuid;
        mD.feeEarner = mDD.feeEarner;
        mD.hourlyRateH = mDD.hourlyRateH;
        mD.timespan = mDD.timeSpan;
        mD.fixedCost = mDD.fixedCost;
        mD.templateType = mDD.templateType;
        mD.templateDescription = mDD.templateDescription;
        mD.description = mDD.description;
        mD.matterId = mDD.matterId;

        mD.fixedCostTimeSpan = mDD.fixedCostTimeSpan;

        mD.CreateDate = DateTime.Now;
        mD.CreateByUserId = base.userGuid;
        mD.UpdateDate = DateTime.Now;
        mD.UpdateByUserId = base.userGuid;
        mD.isEnable = mDD.isBill;
        db.MatterDetails.AddObject(mD);
        db.SaveChanges();

        updateMatterlastUpdateTime(mD.matterId);
    }


    public void addMatterDetailByCopyOrMove(MatterDetailDto mDD)
    {
        MatterDetail mD = new MatterDetail();

        mD.itemNum = mDD.itemNum;
        mD.date = mDD.date;
        mD.feeEarner = mDD.feeEarner;
        mD.timespan = mDD.timeSpan;
        mD.fixedCost = mDD.fixedCost;
        mD.templateType = mDD.templateType;
        mD.templateDescription = mDD.templateDescription;
        mD.description = mDD.description;
        mD.matterId = mDD.matterId;
        mD.hourlyRateH = mDD.hourlyRateH;

        mD.fixedCostTimeSpan = mDD.fixedCostTimeSpan;
        mD.CreateDate = DateTime.Now;
        mD.CreateByUserId = base.userGuid;
        mD.UpdateDate = DateTime.Now;
        mD.UpdateByUserId = base.userGuid;
        mD.isEnable = true;
        db.MatterDetails.AddObject(mD);
        db.SaveChanges();

        updateMatterlastUpdateTime(mD.matterId);
    }


    public string findCurrMatter()
    {
        var matter = db.View_MatterUser.Where(p => p.tarUserId == userGuid).Select(p => p.matterId).ToList();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(SQLHelper.whereIsNotNull(DatabaseConst.ViewFindMatter.matterNum));
        sb.Append(DatabaseConst.and);
        sb.Append(SQLHelper.whereNotEqualString(DatabaseConst.ViewFindMatter.status, "3"));
        sb.Append(DatabaseConst.and);
        sb.Append(SQLHelper.whereNotEqualString(DatabaseConst.ViewFindMatter.status, "4"));
        sb.Append(DatabaseConst.and);
        sb.Append(SQLHelper.whereNotEqualGuid(DatabaseConst.ViewFindMatter.id, "EE28CD2C-D1C3-45A7-B315-42BAEBF6F830"));
        sb.Append(DatabaseConst.and);
        sb.Append("(");
        foreach (var item in matter)
        {
            sb.Append(SQLHelper.whereGuid(DatabaseConst.ViewFindMatter.id, item));
            sb.Append(DatabaseConst.or);
        }
        // sb.Append(SQLHelper.whereGuid(DatabaseConst.ViewFindMatter.id, matter[0]));
        //    sb.Append(DatabaseConst.or);
        sb.Append(SQLHelper.whereYesNo(DatabaseConst.ViewFindMatter.releaseToPublic, true));
        sb.Append(")");

        findSessionQ(ref sb);

        return sb.ToString();
    }

    public string findCurrMatterAdmin()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(SQLHelper.whereIsNotNull(DatabaseConst.ViewFindMatter.matterNum));
        sb.Append(DatabaseConst.and);
        sb.Append(SQLHelper.whereNotEqualString(DatabaseConst.ViewFindMatter.status, "3"));
        sb.Append(DatabaseConst.and);
        sb.Append(SQLHelper.whereNotEqualString(DatabaseConst.ViewFindMatter.status, "4"));
        sb.Append(DatabaseConst.and);
        sb.Append(SQLHelper.whereNotEqualGuid(DatabaseConst.ViewFindMatter.id, "EE28CD2C-D1C3-45A7-B315-42BAEBF6F830"));
        findSessionQ(ref sb);

        return sb.ToString();
    }


    public void findSessionQ(ref System.Text.StringBuilder sb)
    {
        System.Text.StringBuilder tempSb = new System.Text.StringBuilder();

        if (!String.IsNullOrEmpty(SessionClass.SearchByMatterNum))
        {
            //sb.Append(DatabaseConst.and);
            tempSb.Append(DatabaseConst.or);
            tempSb.Append(SQLHelper.whereString(DatabaseConst.ViewFindMatter.matterNum, SessionClass.SearchByMatterNum));
        }
        if (!String.IsNullOrEmpty(SessionClass.SearchByKeywords))
        {
            //sb.Append(DatabaseConst.and);
            tempSb.Append(DatabaseConst.or);
            tempSb.Append("(");
            tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.masterKeywordName, SessionClass.SearchByKeywords));
            tempSb.Append(DatabaseConst.or);
            tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.customKeywordFirst, SessionClass.SearchByKeywords));
            tempSb.Append(DatabaseConst.or);
            tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.customKeywordSecond, SessionClass.SearchByKeywords));
            tempSb.Append(DatabaseConst.or);
            tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.customKeywordThird, SessionClass.SearchByKeywords));
            tempSb.Append(")");
        }
        if (!String.IsNullOrEmpty(SessionClass.SearchByClientName))
        {
            //sb.Append(DatabaseConst.and);
            tempSb.Append(DatabaseConst.or);
            tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.clientName, SessionClass.SearchByClientName));
        }
        if (!String.IsNullOrEmpty(SessionClass.SearchByJobType))
        {
            //sb.Append(DatabaseConst.and);
            tempSb.Append(DatabaseConst.or);
            tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.jobTypeName, SessionClass.SearchByJobType));
        }
        //if (!String.IsNullOrEmpty(SessionClass.SearchByCountry))
        //{
        //    //sb.Append(DatabaseConst.and);
        //    tempSb.Append(DatabaseConst.or);
        //    tempSb.Append("(");
        //    tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.billingAddressFirst, SessionClass.SearchByCountry));
        //    tempSb.Append(DatabaseConst.or);
        //    tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.correspondingAddress1First, SessionClass.SearchByCountry));
        //    tempSb.Append(DatabaseConst.or);
        //    tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.correspondingAddress2First, SessionClass.SearchByCountry));
        //    tempSb.Append(")");
        //}
        //if (!String.IsNullOrEmpty(SessionClass.SearchByClass))
        //{
        //    sb.Append(DatabaseConst.and);
        //    sb.Append("q");
        //}
        if (!String.IsNullOrEmpty(SessionClass.SearchByReferer))
        {
            //sb.Append(DatabaseConst.and);
            tempSb.Append(DatabaseConst.or);
            tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.refererName, SessionClass.SearchByReferer));
        }
        //if (!String.IsNullOrEmpty(SessionClass.SearchByApplicationNum))
        //{
        //    sb.Append(DatabaseConst.and);
        //    sb.Append("q");
        //}
        //if (!String.IsNullOrEmpty(SessionClass.SearchByRegistrationNum))
        //{
        //    sb.Append(DatabaseConst.and);
        //    sb.Append("q");
        //}
        if (!String.IsNullOrEmpty(SessionClass.SearchBySubject))
        {
            tempSb.Append(DatabaseConst.or);
            tempSb.Append(SQLHelper.whereStringLike(DatabaseConst.ViewFindMatter.matterSubject, SessionClass.SearchBySubject));
        }

        if (tempSb.Length != 0)
        {
            sb.Append(String.Format("and ({0})", tempSb.ToString().Substring(4, tempSb.Length - 4)));
        }

    }

    public string findCurrPutAway()
    {
        var matter = db.View_MatterUser.Where(p => p.tarUserId == userGuid).Select(p => p.matterId);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(SQLHelper.whereIsNotNull(DatabaseConst.ViewFindMatter.matterNum));
        sb.Append(DatabaseConst.and);
        sb.Append("(");
        sb.Append(SQLHelper.whereString(DatabaseConst.ViewFindMatter.status, "3"));
        sb.Append(DatabaseConst.or);
        sb.Append(SQLHelper.whereString(DatabaseConst.ViewFindMatter.status, "4"));
        sb.Append(")");
        sb.Append(DatabaseConst.and);
        sb.Append("(");
        foreach (var item in matter)
        {
            sb.Append(SQLHelper.whereGuid(DatabaseConst.ViewFindMatter.id, item));
            sb.Append(DatabaseConst.or);
        }
        sb.Append(SQLHelper.whereYesNo(DatabaseConst.ViewFindMatter.releaseToPublic, true));
        sb.Append(")");

        return sb.ToString();
    }

    public static string findCurrMatterSessionText()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (!String.IsNullOrEmpty(SessionClass.SearchByClientName))
        {
            sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByClientName, SessionClass.SearchByClientName));
            sb.AppendLine("<br />");
        }
        if (!String.IsNullOrEmpty(SessionClass.SearchByReferer))
        {
            sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByFeferer, SessionClass.SearchByReferer));
            sb.AppendLine("<br />");
        }
        if (!String.IsNullOrEmpty(SessionClass.SearchByJobType))
        {
            sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByJobType, SessionClass.SearchByJobType));
            sb.AppendLine("<br />");
        }
        if (!String.IsNullOrEmpty(SessionClass.SearchByKeywords))
        {
            sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByKeywords, SessionClass.SearchByKeywords));
            sb.AppendLine("<br />");
        }
        if (!String.IsNullOrEmpty(SessionClass.SearchByMatterNum))
        {
            sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByMatterNum, SessionClass.SearchByMatterNum));
            sb.AppendLine("<br />");
        }
        if (!String.IsNullOrEmpty(SessionClass.SearchBySubject))
        {
            sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchBySubject, SessionClass.SearchBySubject));
            sb.AppendLine("<br />");
        }

        //if (!String.IsNullOrEmpty(SessionClass.SearchByCountry))
        //{
        //    sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByCountry, SessionClass.SearchByCountry));
        //    sb.AppendLine("<br />");
        //}
        //if (!String.IsNullOrEmpty(SessionClass.SearchByClass))
        //{
        //    sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByClass, SessionClass.SearchByClass));
        //    sb.AppendLine("<br />");
        //}

        //if (!String.IsNullOrEmpty(SessionClass.SearchByApplicationNum))
        //{
        //    sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByApplicationNum, SessionClass.SearchByApplicationNum));
        //    sb.AppendLine("<br />");
        //}
        //if (!String.IsNullOrEmpty(SessionClass.SearchByRegistrationNum))
        //{
        //    sb.AppendLine(String.Format("{0}: {1}", Resources.LanguagePack.masterPageSearchByRegistrationNum, SessionClass.SearchByRegistrationNum));
        //    sb.AppendLine("<br />");
        //}



        return sb.ToString();
    }

    public MatterInfoDto getHomeInfo()
    {
        MatterInfoDto mID = new MatterInfoDto();
        mID.newFile = db.MatterCores.Where(p => p.matterNum == null && p.CreateByUserId == userGuid).Count().ToString();
        // mID.openedMatters = db.MatterCores.Where(p => p.matterNum != null && p.status == "1").Count().ToString();
        var mu1 = (from q in db.MatterCores
                   join c in db.MatterAndFeeEarners on q.id equals c.matterId
                   where q.matterNum != null && q.status == "1" && c.feeEarnerId == userGuid
                   select q).Count();
        var mu2 = (from q in db.MatterCores
                   join c in db.MatterAndHandlingColleagues on q.id equals c.matterId
                   where q.matterNum != null && q.status == "1" && c.handlingColleagueId == userGuid
                   select q).Count();
        mID.openedMatters = (mu1 + mu2).ToString();

        mID.draftMatters = db.MatterDetails.Where(p => p.matterId == tempTimeEntryId && p.CreateByUserId == userGuid).Count().ToString();
        //mID.suspendedMatters = db.MatterCores.Where(p => p.matterNum != null && p.status == "2").Count().ToString();

        var mum1 = (from q in db.MatterCores
                    join c in db.MatterAndFeeEarners on q.id equals c.matterId
                    where q.matterNum != null && q.status == "2" && c.feeEarnerId == userGuid
                    select q).Count();
        var mum2 = (from q in db.MatterCores
                    join c in db.MatterAndHandlingColleagues on q.id equals c.matterId
                    where q.matterNum != null && q.status == "2" && c.handlingColleagueId == userGuid
                    select q).Count();
        mID.suspendedMatters = (mum1 + mum2).ToString();

        mID.pendingDebitNote = db.DebitNoteCores.Where(p => p.debitNoteNum == null).Count().ToString();
        return mID;
    }


    public bool checkMatternumPass(string tarMatterNum)
    {
        bool result = true;

        Int64 tempValue = 0;
        bool checkingIsNum = Int64.TryParse(tarMatterNum, out tempValue);

        if (checkingIsNum && !string.IsNullOrEmpty(tarMatterNum.Trim()))
        {
            var findMatter = db.MatterCores.Where(q => q.matterNum == tarMatterNum);
            if (findMatter.Count() > 0)
            {
                result = false;
            }
        }
        return result;
    }

    public bool checkingCntDebitNoteNum(string DebitNoteNum)
    {
        var result = from q in db.DebitNoteCores
                     where q.debitNoteNum == DebitNoteNum
                     select q;
        return result.Count<DebitNoteCore>() == 0 ? true : false;
    }

    public bool checkingCntDebitNoteNum(string DebitNoteNum, string category)
    {
        var result = from q in db.DebitNoteCores
                     where q.debitNoteNum == DebitNoteNum && q.category == category
                     select q;
        return result.Count<DebitNoteCore>() == 0 ? true : false;
    }

    public string getMatterFeeEarnerAndHandlingColleague(EnumFeeEarnerAndHandlingColleague type, Guid matterId)
    {
        string result = "";
        List<string> tempList = new List<string>();

        if (type == EnumFeeEarnerAndHandlingColleague.FeeEarner)
        {
            var getTar = db.MatterAndFeeEarners.Where(p => p.matterId == matterId);
            foreach (var item in getTar)
            {
                tempList.Add(item.feeEarnerId.ToString());
            }
        }
        else if (type == EnumFeeEarnerAndHandlingColleague.HandlingColleague)
        {
            var getTar = db.MatterAndHandlingColleagues.Where(p => p.matterId == matterId);
            foreach (var item in getTar)
            {
                tempList.Add(item.handlingColleagueId.ToString());
            }
        }

        if (tempList.Count > 0)
        {
            result = String.Join(",", tempList.ToArray());
        }

        return result;
    }


    public double getCurrMatterFeeEarnerHourlyRate(Guid feeEarnerUser)
    {
        double result = -1;
        var maaterId = new Guid(HttpContext.Current.Request[QueryStringConst.matter]);
        //var feeEarnerUser = new Guid(feeEarnerUserId);
        var tar = (from q in db.MatterAndFeeEarners
                   where q.matterId == maaterId && q.feeEarnerId == feeEarnerUser
                   select q).FirstOrDefault();

        if (tar != null && tar.hourlyRate.HasValue)
        {
            result = tar.hourlyRate.Value;
        }
        return result;
    }


    public string findDebitNotePendingAdmin()
    {
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        var hr = findDebitNotePendingGeneral();

        return hr;
    }

    public string findDebitNotePending()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        var hr = findDebitNotePendingGeneral();
        sb.Append(hr);
        sb.Append(DatabaseConst.and);

        var matter = db.View_MatterUser.Where(p => p.tarUserId == userGuid).Select(p => p.matterId);
        var countF = matter.Count();
        int countLoop = 0;
        if (countF != 0)
        {
            sb.Append("(");
            foreach (var item in matter)
            {
                sb.Append(SQLHelper.whereStringLike(DatabaseConst.DebitNoteCore.matterNumIdList, item.ToString()));
                countLoop++;
                if (countLoop != countF)
                {
                    sb.Append(DatabaseConst.or);
                }
            }
            sb.Append(")");
        }
        else
        {
            sb.Append("1 == 2");
        }

        return sb.ToString();
    }

    private string findDebitNotePendingGeneral()
    {
        return SQLHelper.whereIsNull(DatabaseConst.DebitNoteCore.debitNoteNum);
    }


    public List<Guid> findMatterTarUserList()
    {
        var matter = db.View_MatterUser.Where(p => p.tarUserId == userGuid).Select(p => p.matterId);
        return matter.ToList();
    }

    public List<string> findMatterTarUserListStringList()
    {
        var matter = db.View_MatterUser.AsEnumerable().Where(p => p.tarUserId == userGuid).Select(p => p.matterId.ToString());
        return matter.ToList();
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