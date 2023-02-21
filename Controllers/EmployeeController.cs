using MasterJob.DTO;
using MasterJob.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MasterJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public DateTime datenow = DateTime.Now;

        private readonly MasterJobContext masterJobContext;
        public EmployeeController(MasterJobContext masterJobContext)
        {
            this.masterJobContext = masterJobContext;
        }

        [HttpPost("/employee/create")]
        public async Task<HttpStatusCode> Create(EmployeeCreateDTO employee)
        {
            var newEmployee = new Employee()
            {
                Id = new DateTimeOffset(datenow).ToUnixTimeMilliseconds().ToString(),
                Name= employee.Name,
                Address= employee.Address,
                Nik = employee.Nik,
                JobTitleId= employee.JobTitleId,
                JobPositionId= employee.JobPositionId,
            };
            masterJobContext.Employees.Add(newEmployee);
            await masterJobContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpGet("/employee")]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAll()
        {
            var List = await masterJobContext.Employees.Select(x => new EmployeeDTO
            {
                Id = x.Id,
                Name = x.Name,
                JobPositionId  = x.JobPositionId,
                JobTitleId= x.JobTitleId,
                Nik = x.Nik,
                Address= x.Address,
            }).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
                return Ok(List);
        }

        [HttpPatch("/employee/update")]
        public async Task<HttpStatusCode> Update(EmployeeEditDTO employee)
        {
            var employee1 = await masterJobContext.Employees.FirstOrDefaultAsync(s => s.Id == employee.Id);
            if (employee1 == null)
            {
                return HttpStatusCode.NotFound;
            }
            employee1.Name = employee.Name;
            employee1.Address = employee.Address;
            employee1.JobPositionId = employee.JobPositionId;
            employee1.JobTitleId= employee.JobTitleId;
            await masterJobContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("/employee/delete")]
        public async Task<HttpStatusCode> Delete(EmployeeDeleteDTO employee)
        {
            var employee1 = await masterJobContext.Employees.FirstOrDefaultAsync(s => s.Id == employee.Id);
            if (employee1 == null)
            {
                return HttpStatusCode.NotFound;
            }
            masterJobContext.Remove(employee1);
            await masterJobContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
