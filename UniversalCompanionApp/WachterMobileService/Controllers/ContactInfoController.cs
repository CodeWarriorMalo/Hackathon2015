using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using WachterMobileService.DataObjects;
using WachterMobileService.Models;

namespace WachterMobileService.Controllers
{
    public class ContactInfoController : TableController<ContactInfo>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<ContactInfo>(context, Request, Services);
        }

        // GET tables/ContactInfo
        public IQueryable<ContactInfo> GetAllContactInfo()
        {
            return Query(); 
        }

        // GET tables/ContactInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ContactInfo> GetContactInfo(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ContactInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ContactInfo> PatchContactInfo(string id, Delta<ContactInfo> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ContactInfo
        public async Task<IHttpActionResult> PostContactInfo(ContactInfo item)
        {
            ContactInfo current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ContactInfo/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteContactInfo(string id)
        {
             return DeleteAsync(id);
        }

    }
}