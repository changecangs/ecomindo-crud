using Microsoft.AspNetCore.Mvc;
using ecomindo_crud.BLL;
using ecomindo_crud.API.Controllers.Company;
using ecomindo_crud.API.Controllers.Employee;
using ecomindo_crud.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecomindo_crud.API.Controllers.Company
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(IUnitOfWork uow)
        {
            _companyService ??= new CompanyService(uow);
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<EmployeeDTO>), 200)]
        public async Task<ActionResult> GetAllAsync()
        {
            List<Model.Company> result = await _companyService.GetAllCompanyAsync();


            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(List<EmployeeDTO>), 200)]
        public async Task<ActionResult> GetOneCompanyAsync([FromRoute] Guid id)
        {
            Model.Company result = await _companyService.GetCompanyByIdAsync(id);


            return Ok(result);
        }
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> CreateAsync([FromBody] Model.Company company)
        {
            try
            {
                await _companyService.CreateCompanyAsync(company);
                return new OkResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<ActionResult> UpdateAscync([FromBody] Model.Company company)
        {
            try
            {
                await _companyService.UpdateCompanyAsync(company);
                return new OkResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Model.Company), 200)]
        public async Task<ActionResult> DeleteAsync([FromBody] Model.Company company)
        {
            await _companyService.DeleteCompanyAsync(company.Id);
            return new OkResult();
        }
    }
}
