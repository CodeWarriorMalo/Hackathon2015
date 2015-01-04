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
    public class RawDataController : TableController<RawData>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<RawData>(context, Request, Services);
        }

        // GET tables/RawData
        public IQueryable<RawData> GetAllRawData()
        {
            return Query(); 
        }

        // GET tables/RawData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<RawData> GetRawData(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/RawData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<RawData> PatchRawData(string id, Delta<RawData> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/RawData
        public async Task<IHttpActionResult> PostRawData(RawData item)
        {
            RawData current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/RawData/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteRawData(string id)
        {
             return DeleteAsync(id);
        }

    }
}