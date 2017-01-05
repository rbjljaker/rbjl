using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;
using System.Web.Security;

/// <summary>
/// Summary description for UserInfo
/// </summary>
public class UserInfo : DBEntity
{
    public UserInfo()
        : base()
    {

    }

    public UserInfo(string userName)
        : base(userName)
    {

    }



    public bool addUserInfo(AddUserDto user)
    {
        bool result = false;
        try
        {
            LFUser addUser = new LFUser()
            {
                userid = base.userGuid,
                systemUserId = Guid.NewGuid(),
                systemUserNum = user.userNum,
                firstName = user.firstName,
                lastName = user.lastName,
                nickName = user.nickName,
                //UnitRate = user.unitRate,
                CreateDate = DateTime.Now,
                CreateByUserId = base.userGuid,
            };
            db.LFUsers.AddObject(addUser);
            db.SaveChanges();
            Roles.AddUserToRole(currentUser.ProviderName, user.userRoles);
            result = true;
        }
        catch (Exception ex)
        {

        }

        return result;
    }


    public bool editUserInfo(AddUserDto user)
    {
        bool result = false;
        try
        {
            tarUser.systemUserNum = user.userNum;
            tarUser.firstName = user.firstName;
            tarUser.lastName = user.lastName;
            tarUser.nickName = user.nickName;
            //tarUser.UnitRate = user.unitRate,
            tarUser.UpdateDate = DateTime.Now;
            tarUser.UpdateByUserId = base.userGuid;
            db.SaveChanges();
            result = true;
        }
        catch (Exception ex)
        {

        }

        return result;
    }



    public string sqlUser(EnumFeeEarnerAndHandlingColleague type)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (type != null)
        {
            List<Guid> tarUser = getUserIdInRole(type);
            if (tarUser != null)
            {
                sb.Append("(");
                int count = 0;
                foreach (var item in tarUser)
                {
                    sb.Append(SQLHelper.whereGuid("userid", item));
                    count++;
                    if (count != tarUser.Count)
                    {
                        sb.Append(DatabaseConst.or);
                    }

                }
                sb.Append(")");
            }
        }
        return sb.ToString();
    }



    public void disableUser()
    {
        try
        {
            tarUser.nickName = String.Format("{0} - Removed", tarUser.nickName);
            tarUser.systemUserNum = String.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
            tarUser.isEnable = false;
            db.SaveChanges();
        }
        catch (Exception ex)
        {

        }
    }


    public AddUserDto getUserDto()
    {
        AddUserDto userDto = new AddUserDto();
        userDto.userNum = tarUser.systemUserNum;
        userDto.firstName = tarUser.firstName;
        userDto.lastName = tarUser.lastName;
        userDto.nickName = tarUser.nickName;

        return userDto;
    }



}