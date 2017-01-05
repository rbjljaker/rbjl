using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StatusBarHelper
/// </summary>
public class StatusBarHelper : TimeEntryInfo
{
    public StatusBarHelper()
        : base()
    {
    }

    public StatusBarHelper(string userName)
        : base(userName)
    {

    }




    public string[] getStatusBar()
    {
        string[] result = null;
        result = SetProgress(getFixedCost(), 7.75);
        return result;
    }

    //public string SetProgress(double current, double max)
    //{
    //    double checkingBillable = current > max ? max : current;
    //    //double value = 100 - checking * (100 / max);
    //    double value = checkingBillable * (100 / max);
    //    string percent = value.ToString("0");



    //    //if ((!percent.Equals("0")
    //    //            && !percent.Equals("100")))
    //    //{
    //    //    String.Format("");
    //    //}


    //    return percent;
    //}

    public string[] SetProgress(double current, double max)
    {
        string[] result = new string[2];
        double checkingBillable = current > max ? max : current;
        //double value = 100 - checking * (100 / max);
        double value = checkingBillable * (100 / max);
        string percent = value.ToString("0");

        //if ((!percent.Equals("0")
        //            && !percent.Equals("100")))
        //{
        //    String.Format("");
        //}

        result[0] = percent;
        result[1] = (100 - value).ToString("0");

        return result;
    }


    //public string[] SetProgress(double[] current, double max)
    //{
    //    string[] result = new string[2];
    //    double checkingBillable = current[0] > max ? max : current[0];
    //    //double value = 100 - checking * (100 / max);
    //    double value = checkingBillable * (100 / max);
    //    string percent = value.ToString("0");

    //    double maxNonBillable = max - checkingBillable;
    //    double checkingNonBillable = current[1] > maxNonBillable ? maxNonBillable : current[1];
    //    double valueBillable = checkingNonBillable * (100 / max);
    //    string percentBillable = valueBillable.ToString("0");

    //    //if ((!percent.Equals("0")
    //    //            && !percent.Equals("100")))
    //    //{
    //    //    String.Format("");
    //    //}

    //    result[0] = percent;
    //    result[1] = percentBillable;

    //    return result;
    //}



    public string[] getBillableOrNonBillable()
    {
        string[] result = null;
        var details = getBillableBar();
        if (details.totalRecord != 0)
        {
            result = SetProgress(details.billable, details.totalRecord);
        }
        else
        {
            result = new string[2];
            result[0] = result[1] = "0";
        }
        return result;
    }

    //public string getBillableOrNonBillableByMonth()
    //{
    //    string result = null;
    //    var details = getBillableBarByMonth();
    //    result = SetProgress(details.billable, details.totalRecord);
    //    return result;
    //}


    public string getBilledByMonth()
    {
        var findTar = getDebitNoteCores.AsEnumerable();
        getDebitNoteTarUser(ref findTar);
        var result = getDebitNoteBilledValue(findTar);
        return String.Format("Monthly Billed ${0:#,0.##}", result);
    }
}