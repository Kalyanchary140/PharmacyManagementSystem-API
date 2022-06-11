using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharmacyManagementSystem.Dto;
using pharmacyManagementSystem.Models;
using pharmacyManagementSystem.Repository;
using System;
using System.Threading.Tasks;

namespace pharmacyManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly IDrugRepository _drugRepository;

        public DrugController(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var drug = await _drugRepository.GetAll();
                return Ok(drug);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException();
                }
                var supplier = _drugRepository.GetDrug(id);
                if (supplier == null)
                {
                    throw new ArgumentException();
                }
                return new OkObjectResult(supplier);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
        }
        [HttpGet("Drugs/{drugName}")]
        public IActionResult GetDrugName(string drugName)
        {
            var drug = _drugRepository.GetDrugName(drugName);
            return new OkObjectResult(drug);
        }
        [HttpPost]
        public IActionResult Post(DrugDto drugDto)
        {
            var drug = new DrugDetail
            {
                DrugName = drugDto.DrugName,
                Quantity = drugDto.Quantity,
                ExpiryDate = drugDto.ExpiryDate,
                Price = drugDto.Price,
                SupplierId = drugDto.SupplierId,
            };
            var newSupplier = _drugRepository.Create(drug);
            return Created("Sucess", newSupplier);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, DrugDto drugDto)
        {
            var drug = new DrugDetail
            {
                DrugId = drugDto.DrugId,
                DrugName = drugDto.DrugName,
                Quantity = drugDto.Quantity,
                ExpiryDate = drugDto.ExpiryDate,
                Price = drugDto.Price,
                SupplierId = drugDto.SupplierId,
            };

            _drugRepository.UpdateDrug(drug);
            return new OkResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _drugRepository.DeleteDrug(id);
            return Ok();
        }
    }
}
