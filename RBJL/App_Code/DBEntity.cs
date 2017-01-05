using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;
using System.Web.Security;

/// <summary>
/// Summary description for DBEntity
/// </summary>
public class DBEntity
{
    public DBEntity()
    {
        db = new RBJLLawFirmDBEntities();
        currentUser = Membership.GetUser();
        userGuid = new Guid(currentUser.ProviderUserKey.ToString());
        tarUser = getEntity();
        tempTimeEntryId = Guid.Parse("ee28cd2c-d1c3-45a7-b315-42baebf6f830");
        userLevel = getRole(Roles.GetRolesForUser());

        adminId = new Guid("F29C0884-B603-491D-B404-1E0A9ADDE261");
        feeEarner = new Guid("4370404C-B04D-4EDA-A959-879BCF8C1566");
        accountUser = new Guid("A5E26039-4A06-457D-A22A-25B89863F2A5");
        superP = new Guid("2f995574-a64b-463b-ada9-09f203e51ba8");
    }

    public DBEntity(string userName)
    {
        db = new RBJLLawFirmDBEntities();
        currentUser = Membership.GetUser(userName);
        if (currentUser != null)
        {
            userGuid = new Guid(currentUser.ProviderUserKey.ToString());
            userLevel = getRole(Roles.GetRolesForUser(userName));
        }
        tarUser = getEntity();
        tempTimeEntryId = Guid.Parse("ee28cd2c-d1c3-45a7-b315-42baebf6f830");


        adminId = new Guid("F29C0884-B603-491D-B404-1E0A9ADDE261");
        feeEarner = new Guid("4370404C-B04D-4EDA-A959-879BCF8C1566");
        accountUser = new Guid("A5E26039-4A06-457D-A22A-25B89863F2A5");
        superP = new Guid("2f995574-a64b-463b-ada9-09f203e51ba8");
    }

    public RBJLLawFirmDBEntities db { get; private set; }
    public MembershipUser currentUser { get; private set; }
    public Guid userGuid { get; private set; }
    public LFUser tarUser { get; private set; }
    public Guid tempTimeEntryId { get; private set; }
    public EnumUserLevel userLevel { get; private set; }
    public Guid adminId { get; private set; }
    public Guid feeEarner { get; private set; }
    public Guid accountUser { get; private set; }
    public Guid superP { get; private set; }


    private LFUser getEntity()
    {
        var lfUser = (from q in db.LFUsers
                      where q.userid == userGuid
                      select q).FirstOrDefault();
        return lfUser;
    }

    private EnumUserLevel getRole(string[] rolesList)
    {
        EnumUserLevel userLevel = EnumUserLevel.notRole;
        foreach (var item in rolesList)
        {
            if (item == UserLevelConst.administrator)
            {
                userLevel = EnumUserLevel.administrator;
                break;
            }
            else if (item == UserLevelConst.FeeEarner)
            {
                userLevel = EnumUserLevel.FeeEarner;
                break;
            }
            else if (item == UserLevelConst.supervisingPartner)
            {
                userLevel = EnumUserLevel.Partner;
                break;
            }

            else if (item == UserLevelConst.GeneralUser)
            {
                userLevel = EnumUserLevel.GeneralUser;
                break;
            }
            else if (item == UserLevelConst.account)
            {
                userLevel = EnumUserLevel.account;
                break;
            }
        }
        return userLevel;
    }


    public virtual void addLog(string logMessage)
    {
        if (currentUser != null)
        {
            UserLog ul = new UserLog();
            ul.CreateByUserId = userGuid;
            ul.date = DateTime.Now;
            ul.logDescription = logMessage;
            db.UserLogs.AddObject(ul);
            db.SaveChanges();
        }
    }

    public virtual string getUserNameBySystemId(Guid systemId)
    {
        var lfUser = (from q in db.LFUsers
                      where q.userid == systemId
                      select q).FirstOrDefault();
        return lfUser.nickName;
    }

    public virtual string getIntroducer(string userGuid)
    {
        string result = "";
        if (!String.IsNullOrEmpty(userGuid))
        {
            List<string> list = new List<string>();

            var arr = userGuid.Split(',');
            foreach (var item in arr)
            {
                Guid userG = new Guid(item);
                list.Add(getUserNameBySystemId(userG));
            }
            result = String.Join(",", list.ToArray());
        }
        return result;
    }




    public List<Guid> getUserIdInRole(EnumFeeEarnerAndHandlingColleague type)
    {
        List<Guid> result = new List<Guid>();

        if (type == EnumFeeEarnerAndHandlingColleague.FeeEarner)
        {
            result = (from q in db.vw_aspnet_UsersInRoles
                      where q.RoleId == feeEarner || q.RoleId == superP
                      select q.UserId).ToList();

        }
        else
        {
            result = (from q in db.vw_aspnet_UsersInRoles
                      where q.RoleId != adminId && q.RoleId != accountUser
                      select q.UserId).ToList();
        }
        return result;
    }



}