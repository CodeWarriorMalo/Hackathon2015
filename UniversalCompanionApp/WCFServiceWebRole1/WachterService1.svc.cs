using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WactherService1 : IWachterService1
    {
            public WachterConfig GetConfiguration(string deviceId) 
        {
            WachterConfig config = new WachterConfig();

            return config;
        }
        public void SetConfiguration(WachterConfig config)
        {
        }
        public ContactInfo GetContact(string deviceId, string contactName)
        {
            ContactInfo contact = new ContactInfo();

            return contact;
        }
        
        public ContactInfo[] GetContacts(string deviceId)
        {
            List<ContactInfo> contacts = new List<ContactInfo>();

            return contacts.ToArray();
        }
        public bool AddOrUpdateContact(ContactInfo contact)
        {
            bool success = true;


            return success;
        }
        public bool RemoveContact(ContactInfo contact)
        {
            bool success = true;

            return success;
        }
    }
}
