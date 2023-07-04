using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evoltis.DTOs;
using Evoltis.UseCasesPort;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Evoltis.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsUseCasesPort useCasesPort;

        public ProductsController(IProductsUseCasesPort useCasesPort)
        {
            this.useCasesPort = useCasesPort;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = useCasesPort.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = useCasesPort.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductsCreateDTO dto)
        {
            var response = useCasesPort.Create(dto);
            return Ok(response);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductsCreateDTO dto)
        {
            var response = useCasesPort.Update(id, dto);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = useCasesPort.Delete(id);
            return Ok(response);
        }
    }
}

