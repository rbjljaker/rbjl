using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using RBJLLawFirmDBModel;
/// <summary>
/// Summary description for MiscellaneousSetting
/// </summary>
partial class MiscellaneousSetting
{
    public Miscellaneou getMiscellaneou(string fieldName)
    {
        var result = from q in db.Miscellaneous
                     where q.numberName == fieldName
                     select q;
        return result.First<Miscellaneou>();

    }
}