using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for DDClinet
/// </summary>
/// 
namespace RBJLLawFirmDBModel
{
    [DisplayColumnAttribute("clientName", "clientName", false)]
    public partial class Client
    {

    }

    [DisplayColumnAttribute("refererName", "refererName", false)]
    public partial class Referer
    {

    }

    [DisplayColumnAttribute("otherPartiesName", "otherPartiesName", false)]
    public partial class OtherParties
    {

    }

    [DisplayColumnAttribute("agentName", "agentName", false)]
    public partial class OutgoingAgent
    {

    }


    [DisplayColumnAttribute("countryName", "countryName", false)]
    public partial class Country
    {

    }


}