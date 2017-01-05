using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RBJLLawFirmDBModel;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for MaterItem
/// </summary>
public partial class MaterItem : DBEntity
{
    public MaterItem()
        : base()
    {
    }

    public MaterItem(string userName)
        : base(userName)
    {

    }



    public IQueryable<Referer> getReferer(IQueryable<Referer> tar, bool isLegalAid)
    {
        var result = from q in tar
                     where q.islegalAid == isLegalAid
                     select q;
        return result;

    }

    public Client getClientById(int id)
    {
        return db.Clients.Where(p => p.id == id).FirstOrDefault();
    }

    public double? getClientDiscount(int id)
    {
        return getClientById(id).discount;
    }


    public string findClientNameByClientId(int id)
    {
        return getClientById(id).clientName;
    }

    public List<ListItem> getClientAddress(int id)
    {
        List<ListItem> result = new List<ListItem>();
        Client cl = getClientById(id);

        result.Add(new ListItem("[Not Set]", "0"));
        string addr1 = String.Format("{0} {1}", cl.billingAddressFirst, cl.billingAddressSecond);
        result.Add(new ListItem(addr1, addr1));
        if (!String.IsNullOrEmpty(cl.correspondingAddress1First))
        {
            string addr2 = String.Format("{0} {1}", cl.correspondingAddress1First, cl.correspondingAddress1Second);
            result.Add(new ListItem(addr2, addr2));
        }
        if (!String.IsNullOrEmpty(cl.correspondingAddress2First))
        {
            string addr3 = String.Format("{0} {1}", cl.correspondingAddress2First, cl.correspondingAddress2Second);
            result.Add(new ListItem(addr3, addr3));
        }
        return result;
    }


    public List<ListItem> getClientContactPerson(int id)
    {
        List<ListItem> result = new List<ListItem>();
        Client findClient = getClientById(id);

        //result.Add(new ListItem("[Not Set]", "0"));

        string info1 = String.Format("{0}, Email:{1}", findClient.contactPerson, findClient.email, findClient.tel);
        string value1 = String.Format("{0}●{1}●{2}", findClient.contactPerson, findClient.email, findClient.tel);
        result.Add(new ListItem(info1, value1));

        if (!String.IsNullOrEmpty(findClient.contactPerson02))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson02, findClient.email02, findClient.tel02);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson02, findClient.email02, findClient.tel02);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson03))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson03, findClient.email03, findClient.tel03);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson03, findClient.email03, findClient.tel03);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson04))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson04, findClient.email04, findClient.tel04);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson04, findClient.email04, findClient.tel04);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson05))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson05, findClient.email05, findClient.tel05);

            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson05, findClient.email05, findClient.tel05);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson06))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson06, findClient.email06, findClient.tel06);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson06, findClient.email06, findClient.tel06);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson07))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson07, findClient.email07, findClient.tel07);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson07, findClient.email07, findClient.tel07);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson08))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson08, findClient.email08, findClient.tel08);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson08, findClient.email08, findClient.tel08);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson09))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson09, findClient.email09, findClient.tel09);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson09, findClient.email09, findClient.tel09);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson10))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson10, findClient.email10, findClient.tel10);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson10, findClient.email10, findClient.tel10);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson11))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson11, findClient.email11, findClient.tel11);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson11, findClient.email11, findClient.tel11);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson12))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson12, findClient.email12, findClient.tel12);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson12, findClient.email12, findClient.tel12);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson13))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson13, findClient.email13, findClient.tel13);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson13, findClient.email13, findClient.tel13);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson14))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson14, findClient.email14, findClient.tel14);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson14, findClient.email14, findClient.tel14);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson15))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson15, findClient.email15, findClient.tel15);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson15, findClient.email15, findClient.tel15);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson16))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson16, findClient.email16, findClient.tel16);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson16, findClient.email16, findClient.tel16);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson17))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson17, findClient.email17, findClient.tel17);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson17, findClient.email17, findClient.tel17);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson18))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson18, findClient.email18, findClient.tel18);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson18, findClient.email18, findClient.tel18);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson19))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson19, findClient.email19, findClient.tel19);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson19, findClient.email19, findClient.tel19);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson20))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson20, findClient.email20, findClient.tel20);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson20, findClient.email20, findClient.tel20);
            result.Add(new ListItem(info, value));
        }




        return result;
    }

    public IQueryable<OtherParty> getOtherPatiesAll()
    {
        return db.OtherParties;
    }

    public OtherParty getOtherPartiesById(int id)
    {
        return db.OtherParties.Where(p => p.id == id).FirstOrDefault();
    }

    public List<ListItem> getOtherPartiesAllList()
    {
        List<ListItem> result = new List<ListItem>();
        var tar = getOtherPatiesAll();

        result.Add(new ListItem("[Not Set]", "0"));
        foreach (var item in tar)
        {
            result.Add(new ListItem(item.otherPartiesName, item.id.ToString()));
        }
        return result;
    }

    public List<ListItem> getOtherPartiesAddress(int id)
    {
        OtherParty cl = getOtherPartiesById(id);
        List<ListItem> result = new List<ListItem>();

        result.Add(new ListItem("[Not Set]", "0"));
        string addr1 = String.Format("{0} {1}", cl.billingAddressFirst, cl.billingAddressSecond);
        result.Add(new ListItem(addr1, addr1));
        if (!String.IsNullOrEmpty(cl.correspondingAddress1First))
        {
            string addr2 = String.Format("{0} {1}", cl.correspondingAddress1First, cl.correspondingAddress1Second);
            result.Add(new ListItem(addr2, addr2));
        }
        if (!String.IsNullOrEmpty(cl.correspondingAddress2First))
        {
            string addr3 = String.Format("{0} {1}", cl.correspondingAddress2First, cl.correspondingAddress2Second);
            result.Add(new ListItem(addr3, addr3));
        }
        return result;
    }


    public List<ListItem> getOtherPartiesContactPerson(int id)
    {
        OtherParty cl = getOtherPartiesById(id);
        List<ListItem> result = new List<ListItem>();

        result.Add(new ListItem("[Not Set]", "0"));

        string info1 = String.Format("{0}, Email:{1}, Tel:{2}", cl.contactPerson, cl.email, cl.tel);
        string value1 = String.Format("{0}●{1}●{2}", cl.contactPerson, cl.email, cl.tel);
        result.Add(new ListItem(info1, value1));
        return result;
    }


    public Referer getRefererById(int id)
    {
        return db.Referers.Where(p => p.id == id).FirstOrDefault(); ;
    }

    public string findRefererNameByRefererId(int id)
    {
        return getRefererById(id).refererName;
    }

    public List<ListItem> getRefererAddress(int id)
    {
        Referer cl = getRefererById(id);
        List<ListItem> result = new List<ListItem>();

        result.Add(new ListItem("[Not Set]", "0"));
        string addr1 = String.Format("{0} {1}", cl.billingAddressFirst, cl.billingAddressSecond);
        result.Add(new ListItem(addr1, addr1));
        if (!String.IsNullOrEmpty(cl.correspondingAddress1First))
        {
            string addr2 = String.Format("{0} {1}", cl.correspondingAddress1First, cl.correspondingAddress1Second);
            result.Add(new ListItem(addr2, addr2));
        }
        if (!String.IsNullOrEmpty(cl.correspondingAddress2First))
        {
            string addr3 = String.Format("{0} {1}", cl.correspondingAddress2First, cl.correspondingAddress2Second);
            result.Add(new ListItem(addr3, addr3));
        }

        return result;
    }


    public List<ListItem> getRefererContactPerson(int id)
    {
        List<ListItem> result = new List<ListItem>();
        Referer findClient = getRefererById(id);

        //result.Add(new ListItem("[Not Set]", "0"));

        string info1 = String.Format("{0}, Email:{1}", findClient.contactPerson, findClient.email, findClient.tel);
        string value1 = String.Format("{0}●{1}●{2}", findClient.contactPerson, findClient.email, findClient.tel);
        result.Add(new ListItem(info1, value1));

        if (!String.IsNullOrEmpty(findClient.contactPerson02))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson02, findClient.email02, findClient.tel02);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson02, findClient.email02, findClient.tel02);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson03))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson03, findClient.email03, findClient.tel03);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson03, findClient.email03, findClient.tel03);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson04))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson04, findClient.email04, findClient.tel04);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson04, findClient.email04, findClient.tel04);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson05))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson05, findClient.email05, findClient.tel05);

            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson05, findClient.email05, findClient.tel05);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson06))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson06, findClient.email06, findClient.tel06);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson06, findClient.email06, findClient.tel06);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson07))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson07, findClient.email07, findClient.tel07);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson07, findClient.email07, findClient.tel07);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson08))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson08, findClient.email08, findClient.tel08);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson08, findClient.email08, findClient.tel08);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson09))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson09, findClient.email09, findClient.tel09);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson09, findClient.email09, findClient.tel09);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson10))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson10, findClient.email10, findClient.tel10);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson10, findClient.email10, findClient.tel10);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson11))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson11, findClient.email11, findClient.tel11);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson11, findClient.email11, findClient.tel11);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson12))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson12, findClient.email12, findClient.tel12);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson12, findClient.email12, findClient.tel12);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson13))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson13, findClient.email13, findClient.tel13);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson13, findClient.email13, findClient.tel13);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson14))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson14, findClient.email14, findClient.tel14);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson14, findClient.email14, findClient.tel14);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson15))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson15, findClient.email15, findClient.tel15);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson15, findClient.email15, findClient.tel15);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson16))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson16, findClient.email16, findClient.tel16);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson16, findClient.email16, findClient.tel16);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson17))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson17, findClient.email17, findClient.tel17);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson17, findClient.email17, findClient.tel17);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson18))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson18, findClient.email18, findClient.tel18);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson18, findClient.email18, findClient.tel18);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson19))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson19, findClient.email19, findClient.tel19);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson19, findClient.email19, findClient.tel19);
            result.Add(new ListItem(info, value));
        }
        if (!String.IsNullOrEmpty(findClient.contactPerson20))
        {
            string info = String.Format("{0}, Email:{1}", findClient.contactPerson20, findClient.email20, findClient.tel20);
            string value = String.Format("{0}●{1}●{2}", findClient.contactPerson20, findClient.email20, findClient.tel20);
            result.Add(new ListItem(info, value));
        }




        return result;
    }



    public double getPriceValueById(int priceId)
    {
        var find = db.PricingDetails.Where(p => p.id == priceId).FirstOrDefault();
        return find.priceValue;

    }


    public List<DDLValueDto> getTemplDDL(string templateIdValue)
    {
        int deV = 1;
        int templateId;

        bool checking = int.TryParse(templateIdValue, out templateId);
        templateId = checking ? templateId : deV;

        var findTar = db.TemplateDetails.Where(p => p.typeId == templateId);

        List<DDLValueDto> result = new List<DDLValueDto>();

        foreach (var item in findTar)
        {
            result.Add(new DDLValueDto
            {
                value = item.detailsDescription,
                id = item.id.ToString()
            });
        }
        return result;
    }


    public List<DDLValueDto> getPringDDL(string PringIdValue)
    {
        int deV = 1;
        int PringId;

        bool checking = int.TryParse(PringIdValue, out PringId);
        PringId = checking ? PringId : deV;

        var findTar = db.PricingDetails.Where(p => p.typeId == PringId);

        List<DDLValueDto> result = new List<DDLValueDto>();

        foreach (var item in findTar)
        {
            result.Add(new DDLValueDto
            {
                value = item.detailsDescription,
                id = item.priceValue.ToString()
            });
        }
        return result;
    }
}