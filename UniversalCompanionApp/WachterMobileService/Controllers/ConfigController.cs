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
    public class ConfigController : TableController<Config>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Config>(context, Request, Services);
        }

        // GET tables/Config
        public IQueryable<Config> GetAllConfig()
        {
            return Query(); 
        }

        // GET tables/Config/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Config> GetConfig(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Config/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Config> PatchConfig(string id, Delta<Config> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Config
        public async Task<IHttpActionResult> PostConfig(Config item)
        {
            Config current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Config/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteConfig(string id)
        {
             return DeleteAsync(id);
        }

    }
}