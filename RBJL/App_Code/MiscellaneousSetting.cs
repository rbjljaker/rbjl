using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;

/// <summary>
/// Summary description for MiscellaneousSetting
/// </summary>
public partial class MiscellaneousSetting : DBEntity
{
    public MiscellaneousSetting()
        : base()
    {

    }

    private IQueryable<Miscellaneou> getEntity()
    {
        return db.Miscellaneous.Select(q => q);
    }


    public Miscellaneou getData(int id)
    {
        Miscellaneou result = getEntity().Where(q => q.id == id).First();
        return result;
    }

    public bool setData(SettingMiscellaneousDto smd)
    {
        try
        {
            Miscellaneou updateTar = getEntity().Where(q => q.id == smd.id).First();
            updateTar.numberValue = smd.dataValue;
            updateTar.countValue = smd.dataValue;
            updateTar.isAutoGen = smd.isGen;
            updateTar.UpdateDate = DateTime.Now;
            updateTar.CreateByUserId = base.userGuid;

            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}