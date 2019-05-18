using DKBS.DTO;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKBS.Infrastructure.Sharepoint
{
    public interface ISharepointService
    {
        Task<bool> InsertCustomerAsync(CustomerDTO customer);
        Task<bool> UpdateCustomerAsync(CustomerUpdateDTO customer, string accountId);

        Task<bool> InsertCustomerContactAsync(ContactPersonDTO contact);
        Task<bool> UpdateCustomerContactAsync(string contactId, ContactPersonUpdateDTO contact);
    }
    public class SharepointService : ISharepointService
    {
        public const string webSPOUrl = "https://bookon.dkbs.dk";
        public const string listName = "Customers";
        public async Task<bool> InsertCustomerAsync(CustomerDTO customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException("Customer can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                foreach (var prop in customer.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(customer);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle(listName);
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Organisation");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("ContentType can't be null.");
                    }

                    string zipCodeItemId = null;
                    string industryCodeItemId = null;

                    if (itemMetaData.Find(x => x.FieldName == "postNumber") != null)
                    {
                        //filter by zipcode item ID
                        List zipsList = web.Lists.GetByTitle("TownZipCodes");
                        CamlQuery query = new CamlQuery();
                        string zipCode = itemMetaData.Find(x => x.FieldName == "postNumber").Value;
                        query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='WorkZip' /><Value Type='Text'>" + zipCode + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
                        ListItemCollection zipColl = zipsList.GetItems(query);
                        context.Load(zipColl);
                        context.ExecuteQuery();
                        if (zipColl.Count == 1)
                        {
                            zipCodeItemId = zipColl[0].Id.ToString() + ";#";
                        }
                    }

                    if (itemMetaData.Find(x => x.FieldName == "industryCode") != null)
                    {
                        string industryTitle = itemMetaData.Find(x => x.FieldName == "industryCode").Value;
                        List industryLst = web.Lists.GetByTitle("IndustryCode");
                        CamlQuery query = new CamlQuery();
                        query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + industryTitle + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
                        ListItemCollection industryColl = industryLst.GetItems(query);
                        context.Load(industryColl);
                        context.ExecuteQuery();
                        if (industryColl.Count == 1)
                        {
                            industryCodeItemId = industryColl[0].Id.ToString() + ";#";
                        }
                    }

                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem newItem = lst.AddItem(itemCreateInfo);
                    newItem["ContentTypeId"] = ct.Id;

                    if (itemMetaData.Find(x => x.FieldName == "companyName") != null)
                    {
                        newItem["Title"] = itemMetaData.Find(x => x.FieldName == "companyName").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "address1") != null)
                    {
                        newItem["Address"] = itemMetaData.Find(x => x.FieldName == "address1").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "address2") != null)
                    {
                        newItem["Address2"] = itemMetaData.Find(x => x.FieldName == "address2").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "postNumber") != null)
                    {
                        newItem["ZipMachingFilter"] = zipCodeItemId;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "country") != null)
                    {
                        string country = itemMetaData.Find(x => x.FieldName == "country").Value;
                        switch (country)
                        {
                            case "Denmark":
                                newItem["Country"] = "1;#";
                                break;
                            case "Germany":
                                newItem["Country"] = "2;#";
                                break;
                            case "Sweden":
                                newItem["Country"] = "3;#";
                                break;
                            case "Andora":
                                newItem["Country"] = "4;#";
                                break;
                            default:
                                break;
                        }
                    }

                    if (itemMetaData.Find(x => x.FieldName == "phoneNumber") != null)
                    {
                        newItem["Phone"] = itemMetaData.Find(x => x.FieldName == "phoneNumber").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        newItem["accountID"] = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "industryCode") != null)
                    {
                        newItem["IndustryCode"] = industryCodeItemId;
                    }
                    newItem.Update();
                    context.ExecuteQuery();
                    return await Task.FromResult<bool>(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<bool> UpdateCustomerAsync(CustomerUpdateDTO customer,string acctId)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException("Customer can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                itemMetaData.Add(new FieldMataData { FieldName = "accountId", Value = acctId });
                foreach (var prop in customer.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(customer);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle(listName);
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Organisation");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("ContentType can't be null.");
                    }

                    string zipCodeItemId = null;
                    string industryCodeItemId = null;

                    if (itemMetaData.Find(x => x.FieldName == "postNumber") != null)
                    {
                        //filter by zipcode item ID
                        List zipsList = web.Lists.GetByTitle("TownZipCodes");
                        CamlQuery query = new CamlQuery();
                        string zipCode = itemMetaData.Find(x => x.FieldName == "postNumber").Value;
                        query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='WorkZip' /><Value Type='Text'>" + zipCode + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
                        ListItemCollection zipColl = zipsList.GetItems(query);
                        context.Load(zipColl);
                        context.ExecuteQuery();
                        if (zipColl.Count == 1)
                        {
                            zipCodeItemId = zipColl[0].Id.ToString() + ";#";
                        }
                    }

                    if (itemMetaData.Find(x => x.FieldName == "industryCode") != null)
                    {
                        string industryTitle = itemMetaData.Find(x => x.FieldName == "industryCode").Value;
                        List industryLst = web.Lists.GetByTitle("IndustryCode");
                        CamlQuery query = new CamlQuery();
                        query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + industryTitle + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/></ViewFields></View>";
                        ListItemCollection industryColl = industryLst.GetItems(query);
                        context.Load(industryColl);
                        context.ExecuteQuery();
                        if (industryColl.Count == 1)
                        {
                            industryCodeItemId = industryColl[0].Id.ToString() + ";#";
                        }
                    }

                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        string accountId = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                        ListItem updatableItem = GetCustomerItem(context, lst, accountId, "accountID");

                        if (updatableItem != null)
                        {
                            if (itemMetaData.Find(x => x.FieldName == "companyName") != null)
                            {
                                updatableItem["Title"] = itemMetaData.Find(x => x.FieldName == "companyName").Value;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "address1") != null)
                            {
                                updatableItem["Address"] = itemMetaData.Find(x => x.FieldName == "address1").Value;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "address2") != null)
                            {
                                updatableItem["Address2"] = itemMetaData.Find(x => x.FieldName == "address2").Value;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "postNumber") != null)
                            {
                                updatableItem["ZipMachingFilter"] = zipCodeItemId;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "country") != null)
                            {
                                string country = itemMetaData.Find(x => x.FieldName == "country").Value;
                                switch (country)
                                {
                                    case "Denmark":
                                        updatableItem["Country"] = "1;#";
                                        break;
                                    case "Germany":
                                        updatableItem["Country"] = "2;#";
                                        break;
                                    case "Sweden":
                                        updatableItem["Country"] = "3;#";
                                        break;
                                    case "Andora":
                                        updatableItem["Country"] = "4;#";
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (itemMetaData.Find(x => x.FieldName == "phoneNumber") != null)
                            {
                                updatableItem["Phone"] = itemMetaData.Find(x => x.FieldName == "phoneNumber").Value;
                            }

                            if (itemMetaData.Find(x => x.FieldName == "industryCode") != null)
                            {
                                updatableItem["IndustryCode"] = industryCodeItemId;
                            }
                            updatableItem.Update();
                            context.ExecuteQuery();
                        }
                    }
                }

                return await Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public async Task<bool> InsertCustomerContactAsync(ContactPersonDTO contact)
        {

            try
            {
                if (contact == null)
                {
                    throw new ArgumentNullException("ContactPerson can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                foreach (var prop in contact.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(contact);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle(listName);
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Kontaktperson");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("ContentType can't be null.");
                    }

                    string relatedOrgId = null;
                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        string accountId = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                        ListItem organization = GetCustomerItem(context, lst, accountId, "accountID");
                        if (organization != null)
                        {
                            relatedOrgId = organization.Id.ToString() + ";#";
                        }
                    }


                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem newItem = lst.AddItem(itemCreateInfo);
                    newItem["ContentTypeId"] = ct.Id;

                    if (itemMetaData.Find(x => x.FieldName == "firstName") != null || itemMetaData.Find(x => x.FieldName == "lastName") != null)
                    {
                        string firstName = itemMetaData.Find(x => x.FieldName == "firstName") != null ? itemMetaData.Find(x => x.FieldName == "firstName").Value : "";
                        string lastName = itemMetaData.Find(x => x.FieldName == "lastName") != null ? itemMetaData.Find(x => x.FieldName == "lastName").Value : "";
                        string joinedName = firstName + " " + lastName;
                        newItem["Title"] = joinedName;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "email") != null)
                    {
                        newItem["Email"] = itemMetaData.Find(x => x.FieldName == "email").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "telephone") != null)
                    {
                        newItem["Phone"] = itemMetaData.Find(x => x.FieldName == "telephone").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "mobilePhone") != null)
                    {
                        newItem["CellPhone"] = itemMetaData.Find(x => x.FieldName == "mobilePhone").Value;
                    }

                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        string accountId = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                        newItem["accountID"] = accountId;
                        newItem["RelatedOrganization"] = relatedOrgId;
                    }
                    if (itemMetaData.Find(x => x.FieldName == "contactId") != null)
                    {
                        newItem["contactID"] = itemMetaData.Find(x => x.FieldName == "contactId").Value;
                    }
                    newItem.Update();
                    context.ExecuteQuery();
                }

                return await Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public async Task<bool> UpdateCustomerContactAsync(string cntId, ContactPersonUpdateDTO contact)
        {
            try
            {
                if (contact == null)
                {
                    throw new ArgumentNullException("ContactPerson can't be null.");
                }
                List<FieldMataData> itemMetaData = new List<FieldMataData>();
                itemMetaData.Add(new FieldMataData { FieldName = "contactId", Value = cntId });
                foreach (var prop in contact.GetType().GetProperties())
                {
                    FieldMataData obj = new FieldMataData();
                    var value = prop.GetValue(contact);
                    obj.FieldName = string.Concat(prop.Name.ToCharArray()[0].ToString().ToLower(), prop.Name.Remove(0, 1));
                    obj.Value = value == null ? "" : value.ToString();
                    itemMetaData.Add(obj);
                }

                using (var context = GetClientContext())
                {
                    Web web = context.Web;
                    List lst = web.Lists.GetByTitle(listName);
                    ContentTypeCollection ctColl = lst.ContentTypes;
                    context.Load(ctColl);
                    context.ExecuteQuery();
                    ContentType ct = ctColl.FirstOrDefault(p => p.Name == "Kontaktperson");

                    if (ct == null)
                    {
                        throw new ArgumentNullException("ContentType can't be null.");
                    }

                    string relatedOrgId = null;
                    if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                    {
                        string accountId = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                        ListItem organization = GetCustomerItem(context, lst, accountId, "accountID");
                        if (organization != null)
                        {
                            relatedOrgId = organization.Id.ToString() + ";#";
                        }
                    }

                    ListItem updatableItem = null;
                    if (itemMetaData.Find(x => x.FieldName == "contactId") != null)
                    {
                        string contactId = itemMetaData.Find(x => x.FieldName == "contactId").Value;
                        updatableItem = GetCustomerItem(context, lst, contactId, "contactID");
                    }

                    if (updatableItem != null)
                    {
                        if (itemMetaData.Find(x => x.FieldName == "firstName") != null || itemMetaData.Find(x => x.FieldName == "lastName") != null)
                        {
                            string firstName = itemMetaData.Find(x => x.FieldName == "firstName") != null ? itemMetaData.Find(x => x.FieldName == "firstName").Value : "";
                            string lastName = itemMetaData.Find(x => x.FieldName == "lastName") != null ? itemMetaData.Find(x => x.FieldName == "lastName").Value : "";
                            string joinedName = firstName + " " + lastName;
                            updatableItem["Title"] = joinedName;
                        }

                        if (itemMetaData.Find(x => x.FieldName == "email") != null)
                        {
                            updatableItem["Email"] = itemMetaData.Find(x => x.FieldName == "email").Value;
                        }

                        if (itemMetaData.Find(x => x.FieldName == "telephone") != null)
                        {
                            updatableItem["Phone"] = itemMetaData.Find(x => x.FieldName == "telephone").Value;
                        }

                        if (itemMetaData.Find(x => x.FieldName == "mobilePhone") != null)
                        {
                            updatableItem["CellPhone"] = itemMetaData.Find(x => x.FieldName == "mobilePhone").Value;
                        }

                        if (itemMetaData.Find(x => x.FieldName == "accountId") != null)
                        {
                            string accountId = itemMetaData.Find(x => x.FieldName == "accountId").Value;
                            updatableItem["accountID"] = accountId;
                            updatableItem["RelatedOrganization"] = relatedOrgId;
                        }
                        updatableItem.Update();
                        context.ExecuteQuery();
                    }
                }

                return await Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private ClientContext GetClientContext()
        {
            ClientContext context = new ClientContext(webSPOUrl);
            context.AuthenticationMode = ClientAuthenticationMode.FormsAuthentication;
            context.FormsAuthenticationLoginInfo = new FormsAuthenticationLoginInfo("CRM Automation", "9LEkTny4");
            context.ExecuteQuery();
            return context;
        }

        private static ListItem GetCustomerItem(ClientContext context, List customersLst, string accountId, string searchableField)
        {
            ListItem result = null;
            CamlQuery query = new CamlQuery();
            query.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='" + searchableField + @"' /><Value Type='Text'>" + accountId + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='ID'/><FieldRef Name='Title'/><FieldRef Name='Address'/><FieldRef Name='Address2'/><FieldRef Name='ZipMachingFilter'/><FieldRef Name='Country'/><FieldRef Name='Phone'/><FieldRef Name='IndustryCode'/></ViewFields></View>";
            ListItemCollection customerColl = customersLst.GetItems(query);
            context.Load(customerColl);
            context.ExecuteQuery();
            if (customerColl.Count == 1)
            {
                result = customerColl[0];
            }
            else
            {
                CamlQuery query2 = new CamlQuery();
                query2.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='ID' /><Value Type='Text'>" + accountId + @"</Value></Eq></Where></Query>
                                                        <ViewFields><FieldRef Name='Title'/><FieldRef Name='Address'/><FieldRef Name='Address2'/><FieldRef Name='ZipMachingFilter'/><FieldRef Name='Country'/><FieldRef Name='Phone'/><FieldRef Name='IndustryCode'/></ViewFields></View>";
                ListItemCollection customerColl2 = customersLst.GetItems(query2);
                context.Load(customerColl2);
                context.ExecuteQuery();
                if (customerColl2.Count == 1)
                {
                    result = customerColl2[0];
                }
            }

            return result;
        }
    }
}
