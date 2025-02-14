using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend1.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Backend1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRamdomService _ramdonServicesSingleton;
        private IRamdomService _ramdonServicesScoped;
        private IRamdomService _ramdonServicesTransient;

        private IRamdomService _ramdonServices2Singleton;
        private IRamdomService _ramdonServices2Scoped;
        private IRamdomService _ramdonServices2Transient;

        public RandomController(
            [FromKeyedServices("randomSingleton")] IRamdomService randomServiceSingleton,
            [FromKeyedServices("randomScoped")] IRamdomService randomServiceScoped,
            [FromKeyedServices("randomTransient")] IRamdomService randomServiceTransient,
            [FromKeyedServices("randomSingleton")] IRamdomService randomService2Singleton,
            [FromKeyedServices("randomScoped")] IRamdomService randomService2Scoped,
            [FromKeyedServices("randomTransient")] IRamdomService randomService2transient)
        {
            _ramdonServicesSingleton = randomServiceSingleton;
            _ramdonServicesScoped = randomServiceScoped;    
            _ramdonServicesTransient = randomServiceTransient;
            _ramdonServices2Singleton = randomService2Singleton;
            _ramdonServices2Scoped = randomService2Scoped;
            _ramdonServices2Transient = randomService2transient;

        }
        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int >();

            result.Add("Singleton 1", _ramdonServicesSingleton.Value);
            result.Add("Scope 1", _ramdonServicesScoped.Value);
            result.Add("Transient 1", _ramdonServicesTransient.Value);

            result.Add("Singleton 2", _ramdonServices2Singleton.Value);
            result.Add("Scope 2", _ramdonServices2Scoped.Value);
            result.Add("Transient 2", _ramdonServices2Transient.Value);

            return result;

        } 
    }
}
