using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ZaszloArusAPI_EF.Models;

namespace ZaszloArusAPI_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        [HttpGet]

        public JsonResult Get()
        {
            List<Sale> sales = new List<Sale>();
            using (var context = new zaszloarusContext())
            {
                try
                {
                    return new JsonResult(context.Sales.ToList());
                }
                catch (System.Exception ex)
                {
                    return new JsonResult(ex.Message);
                }
            }
        }
    }
}
