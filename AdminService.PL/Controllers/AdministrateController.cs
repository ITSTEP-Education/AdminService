using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using AdminService.BLL.Interfaces;
using AdminService.DAL.Entities;
using AdminService.BLL.Infrastructures;
using Asp.Versioning;

namespace AdminService.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdministrateController : ControllerBase
    {
        private readonly IOrderService orderServ;
        private readonly ILogger<AdministrateController> logger;

        public AdministrateController(IOrderService orderService, ILogger<AdministrateController> logger)
        {
            this.orderServ = orderService;
            this.logger = logger;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("product-orders", Name = "GetProductOrders")]
        public ActionResult<IEnumerable<ProductOrder>> getAllProductOrders()
        {
            try
            {
                return Ok(orderServ.getAllOrders());
            }
            catch (AdminServiceException ex)
            {
                return NotFound(new { msg = ex.Message, prop = ex.property });
            }
            catch (DbException ex)
            {
                return BadRequest(new { msg = ex.Message, prop = ex.SqlState });
            }
        }
    }
}
