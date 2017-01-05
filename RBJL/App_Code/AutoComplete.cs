using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using RBJLLawFirmDBModel;

/// <summary>
/// Summary description for AutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AutoComplete : System.Web.Services.WebService
{
    RBJLLawFirmDBEntities db = new RBJLLawFirmDBEntities();

    public AutoComplete()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}


    [WebMethod(EnableSession = true)]
    public string[] GetSearchCompletion(string prefixText, int count)
    {
        
        if (count == 0)
        {
            count = 10;
        }
        List<string> tmp = new List<string>();

        int? searchType = SessionClass.autoCompleteColumn;

        if (searchType.HasValue)
        {
            getSearchResult(ref tmp, searchType.Value, prefixText, count);
        }
        return tmp.ToArray();
    }

    private void getSearchResult(ref List<string> tar, int searchType, string prefixText, int count)
    {
        var dbEntity = db.View_FindMatter;
        switch (searchType)
        {
            case (int)EnumSearchBy.ByMatterNum:

                tar = ((from p in dbEntity
                        where p.matterNum.Contains(prefixText) && p.matterNum.IndexOf(prefixText) == 0
                        orderby p.matterNum ascending
                        select p.matterNum).Distinct()).Take(count).ToList();

                break;
            case (int)EnumSearchBy.ByKeywords:

                tar.AddRange(((from p in dbEntity
                               where p.customKeywordFirst.Contains(prefixText) && p.customKeywordFirst.IndexOf(prefixText) == 0
                               select p.customKeywordFirst).Distinct()).ToList());


                tar.AddRange(((from p in dbEntity
                               where p.customKeywordSecond.Contains(prefixText) && p.customKeywordSecond.IndexOf(prefixText) == 0
                               select p.customKeywordSecond).Distinct()).ToList());


                tar.AddRange(((from p in dbEntity
                               where p.customKeywordThird.Contains(prefixText) && p.customKeywordThird.IndexOf(prefixText) == 0
                               select p.customKeywordThird).Distinct()).ToList());


                tar.AddRange(((from p in dbEntity
                               where p.masterKeywordName.Contains(prefixText) && p.masterKeywordName.IndexOf(prefixText) == 0
                               select p.masterKeywordName).Distinct()).ToList());

                tar = tar.Distinct().ToList();
                tar.Sort();
                tar.Take(count);

                break;
            case (int)EnumSearchBy.ByClientName:

                tar = ((from p in db.View_FindMatter
                        where p.clientName.Contains(prefixText) && p.clientName.IndexOf(prefixText) == 0
                        orderby p.clientName ascending
                        select p.clientName).Distinct()).Take(count).ToList();

                break;
            case (int)EnumSearchBy.ByJobType:

                tar = ((from p in db.View_FindMatter
                        where p.jobTypeName.Contains(prefixText) && p.jobTypeName.IndexOf(prefixText) == 0
                        orderby p.jobTypeName ascending
                        select p.jobTypeName).Distinct()).Take(count).ToList();

                break;
            //case (int)EnumSearchBy.ByCountry:

            //    //tar = ((from p in db.View_FindMatter
            //    //        where p.matterNum.Contains(prefixText) && p.matterNum.IndexOf(prefixText) == 0
            //    //        orderby p.matterNum ascending
            //    //        select p.matterNum).Distinct()).Take(count).ToList();

            //    break;
            //case (int)EnumSearchBy.ByClass:

            //    //tar = ((from p in db.View_FindMatter
            //    //        where p.matterNum.Contains(prefixText) && p.matterNum.IndexOf(prefixText) == 0
            //    //        orderby p.matterNum ascending
            //    //        select p.matterNum).Distinct()).Take(count).ToList();

            //    break;
            case (int)EnumSearchBy.ByReferer:

                tar = ((from p in db.View_FindMatter
                        where p.refererName.Contains(prefixText) && p.refererName.IndexOf(prefixText) == 0
                        orderby p.refererName ascending
                        select p.refererName).Distinct()).Take(count).ToList();

                break;
            //case (int)EnumSearchBy.ByApplicationNum:

            //    //tar = ((from p in db.View_FindMatter
            //    //        where p.matterNum.Contains(prefixText) && p.matterNum.IndexOf(prefixText) == 0
            //    //        orderby p.matterNum ascending
            //    //        select p.matterNum).Distinct()).Take(count).ToList();

            //    break;
            //case (int)EnumSearchBy.ByRegistrationNum:

            //    //tar = ((from p in db.View_FindMatter
            //    //        where p.matterNum.Contains(prefixText) && p.matterNum.IndexOf(prefixText) == 0
            //    //        orderby p.matterNum ascending
            //    //        select p.matterNum).Distinct()).Take(count).ToList();

            //    break;


            case (int)EnumSearchBy.BySubject:
                //todo
                //tar = ((from p in db.View_FindMatter
                //        where p.refererName.Contains(prefixText) && p.refererName.IndexOf(prefixText) == 0
                //        orderby p.refererName ascending
                //        select p.refererName).Distinct()).Take(count).ToList();

                break;
        }
    }


    [WebMethod]
    public string[] GetIntroducer(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }

        //List<string> tmp = new List<string>();

        var q = ((from p in db.LFUsers
                  where p.nickName.Contains(prefixText) && p.nickName.IndexOf(prefixText) == 0
                  orderby p.nickName ascending
                  select p.nickName).Distinct()).Take(count).ToList();

        return q.ToArray();
    }
}
