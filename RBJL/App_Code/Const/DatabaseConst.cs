using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConst
/// </summary>
public struct DatabaseConst
{
    public const string id = "id";
    public const string createDate = "CreateDate";
    public const string updateDate = "UpdateDate";
    public const string createByUserId = "CreateByUserId";
    public const string updateByUserId = "UpdateByUserId";
    public const string putAwayDate = "putAwayDate";
    public const string isEnable = "isEnable";
    public const string and = " and ";
    public const string or = " or ";

    public struct matterConst
    {
        public const string id = "id";
        public const string matterNum = "matterNum";
        public const string matterSubject = "matterSubject";
        public const string clientId = "clientId";
        public const string refererId = "refererId";
        public const string refererFee = "refererFee";
        public const string jobTypeId = "jobTypeId";
        public const string jobTypeName = "jobTypeName";
        public const string fileOpenDate = "fileOpenDate";
        public const string discount = "discount";
        public const string hourlyRate = "hourlyRate";
        public const string masterKeywordId = "masterKeywordId";
        public const string masterKeywordName = "masterKeywordName";
        public const string introducer = "introducer";
        public const string customKeywordFirst = "customKeywordFirst";
        public const string customKeywordSecond = "customKeywordSecond";
        public const string customKeywordThird = "customKeywordThird";
        public const string logo = "logo";
        public const string releaseToPublic = "releaseToPublic";
        public const string outgoingAgentId = "outgoingAgentId";
        public const string status = "status";
        public const string addUserToCase = "addUserToCase";
        public const string remarks = "remarks";
        public const string isReopen = "isReopen";
        public const string isPending = "isPending";
        public const string adminStatus = "matterNum";

        public const string SPList = "SPList";
    }

    public struct REFERE
    {
        public const string refererName = "refererName";
        public const string billingAddressFirst = "billingAddressFirst";
        public const string billingAddressSecond = "billingAddressSecond";
        public const string correspondingAddress1First = "correspondingAddress1First";
        public const string correspondingAddress1Second = "correspondingAddress1Second";
        public const string correspondingAddress2First = "correspondingAddress2First";
        public const string correspondingAddress2Second = "correspondingAddress2Second";
        public const string contactPerson = "contactPerson";
        public const string tel = "tel";
        public const string fax = "fax";
        public const string email = "email";
    }
    public struct CLIENT
    {
        public const string clientName = "clientName";
        public const string billingAddressFirst = "billingAddressFirst";
        public const string billingAddressSecond = "billingAddressSecond";
        public const string correspondingAddress1First = "correspondingAddress1First";
        public const string correspondingAddress1Second = "correspondingAddress1Second";
        public const string correspondingAddress2First = "correspondingAddress2First";
        public const string correspondingAddress2Second = "correspondingAddress2Second";
        public const string contactPerson = "contactPerson";
        public const string tel = "tel";
        public const string fax = "fax";
        public const string email = "email";
    }

    public struct OutgoingAgent
    {
        public const string agentName = "agentName";
        public const string agentNum = "agentNum";
        public const string correspondingAddress1First = "correspondingAddress1First";
        public const string correspondingAddress1Second = "correspondingAddress1Second";
        public const string correspondingAddress2First = "correspondingAddress2First";
        public const string correspondingAddress2Second = "correspondingAddress2Second";
        public const string billingAddressFirst = "billingAddressFirst";
        public const string billingAddressSecond = "billingAddressSecond";
        public const string contactPerson = "contactPerson";
        public const string tel = "tel";
        public const string fax = "fax";
        public const string email = "email";
    }

    public struct OtherParties
    {
        public const string otherPartiesName = "otherPartiesName";
        public const string otherPartiesNum = "otherPartiesNum";
        public const string correspondingAddress1First = "correspondingAddress1First";
        public const string correspondingAddress1Second = "correspondingAddress1Second";
        public const string correspondingAddress2First = "correspondingAddress2First";
        public const string correspondingAddress2Second = "correspondingAddress2Second";
        public const string correspondingAddress3First = "correspondingAddress3First";
        public const string correspondingAddress3Second = "correspondingAddress3Second";
        public const string contactPerson = "contactPerson";
        public const string tel = "tel";
        public const string fax = "fax";
        public const string email = "email";
    }



    public struct MatterDetail
    {
        public const string timespan = "timespan";
        public const string fixedCost = "fixedCost";
        public const string billable = "billable";
        public const string wittenOff = "wittenOff";


        public const string itemNum = "itemNum";
        public const string date = "date";
        public const string feeEarner = "feeEarner";
        public const string otherFeeEarner = "otherFeeEarner";
        public const string templateType = "templateType";
        public const string templateDescription = "templateDescription";
        public const string matterId = "matterId";
        public const string hourlyRateH = "hourlyRateH";
    }

    public struct ViewFindMatter
    {
        public const string id = "id";
        public const string matterNum = "matterNum";
        public const string clientId = "clientId";
        public const string matterSubject = "matterSubject";
        public const string status = "status";
        public const string masterKeywordName = "masterKeywordName";
        public const string customKeywordFirst = "customKeywordFirst";
        public const string customKeywordSecond = "customKeywordSecond";
        public const string customKeywordThird = "customKeywordThird";
        public const string clientName = "clientName";
        public const string jobTypeId = "jobTypeId";
        public const string jobTypeName = "jobTypeName";
        public const string correspondingAddress2First = "correspondingAddress2First";
        public const string correspondingAddress1First = "correspondingAddress1First";
        public const string billingAddressFirst = "billingAddressFirst";
        public const string refererId = "refererId";
        public const string refererName = "refererName";
        public const string correspondingAddress2Second = "correspondingAddress2Second";
        public const string correspondingAddress1Second = "correspondingAddress1Second";
        public const string billingAddressSecond = "billingAddressSecond";
        public const string isEnable = "isEnable";
        public const string adminStatus = "adminStatus";
        public const string fileOpenDate = "fileOpenDate";
        public const string releaseToPublic = "releaseToPublic";
        public const string isPending = "isPending";
        public const string isReopen = "isReopen";
    }

    public struct DebitNoteCore
    {
        public const string debitNoteNum = "debitNoteNum";
        public const string startDate = "startDate";
        public const string endDate = "endDate";
        public const string clientId = "clientId";
        public const string otherPartiesId = "otherPartiesId";
        public const string refererId = "refererId";
        public const string address = "address";
        public const string debitNoteRef = "ref";
        public const string yourRef = "yourRef";
        public const string status = "status";
        public const string version = "version";
        public const string matterNumId = "matterNumId";
        public const string debitNoteOther = "debitNoteOther";
        public const string debitNoteType = "debitNoteType";
        public const string price = "price";
        public const string isDiscount = "isDiscount";
        public const string isCancel = "isCancel";
        public const string matterNumIdList = "matterNumIdList";
        public const string category = "category";

        public const string reportDate = "reportDate";

    }
    public struct DebitNoteNarrative
    {
        public const string debitNoteId = "debitNoteId";


    }
    public struct DebitNoteCost
    {
        public const string debitNoteId = "debitNoteId";
    }

    public struct DebitNoteMisc
    {
        public const string debitNoteId = "debitNoteId";
    }

    public struct DebitNoteDisbursement
    {
        public const string debitNoteId = "debitNoteId";
    }
}
