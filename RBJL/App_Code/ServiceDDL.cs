using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;
using RBJLLawFirmDBModel;

/// <summary>
/// Summary description for ServiceDDL
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ServiceDDL : System.Web.Services.WebService
{

    public ServiceDDL()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}


    [WebMethod]
    public CascadingDropDownNameValue[] GetTemplateCore(string knownCategoryValues)
    {

        List<CascadingDropDownNameValue> countries = GetData();
        return countries.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] GetTemplateDetails(string knownCategoryValues)
    {
        string tempLValue = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["id"];
        List<CascadingDropDownNameValue> countries = GetData(tempLValue);
        return countries.ToArray();
    }


    private List<CascadingDropDownNameValue> GetData()
    {
        RBJLLawFirmDBEntities db = new RBJLLawFirmDBEntities();

        var findTar = db.TemplateTypes;

        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        foreach (var item in findTar)
        {
            values.Add(new CascadingDropDownNameValue

            {

                name = item.typeDescription,

                value = item.id.ToString()

            });

        }

        return values;
    }

    private List<CascadingDropDownNameValue> GetData(string templateIdValue)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        values.Add(new CascadingDropDownNameValue { name = "-------", value = "-1" });

        RBJLLawFirmDBEntities db = new RBJLLawFirmDBEntities();

        int templateId = Convert.ToInt16(templateIdValue);

        var findTar = db.TemplateDetails.Where(p => p.typeId == templateId);



        foreach (var item in findTar)
        {
            values.Add(new CascadingDropDownNameValue

            {

                name = item.detailsDescription,

                value = item.id.ToString()

            });

        }

        return values;
    }
}
