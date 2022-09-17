using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace SongGuessBackend.Filters
{
    public class DevelopmentOnly : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var env = context.HttpContext.RequestServices.GetService<IWebHostEnvironment>();
            if (!env.IsDevelopment())
            {
                context.Result = new NotFoundResult();
            }
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
