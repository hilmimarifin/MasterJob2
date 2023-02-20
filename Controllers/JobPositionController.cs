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
    public class JobPositionController : ControllerBase
    {
        public DateTime datenow = DateTime.Now;

        private readonly MasterJobContext masterJobContext;
        public JobPositionController(MasterJobContext masterJobContext)
        {
            this.masterJobContext = masterJobContext;
        }
        [HttpGet("/job-position")]
        public async Task<ActionResult<List<JobTitleDTO>>> GetAll()
        {
            var List = await masterJobContext.JobPositions.Select(x => new JobPositionDTO
            {
                Id = x.Id,
                Name = x.Name,
                TitleId= x.TitleId,
                Code = x.Code,
            }).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
                return Ok(List);
        }

        [HttpGet("/job-position/{Id}")]
        public async Task<ActionResult<JobPositionDTO>> GetById(string Id)
        {
            var title = await masterJobContext.JobPositions.FirstOrDefaultAsync(s => s.Id == Id);
            if (title == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(title);
            }
        }


        [HttpPost("/job-position/create")]
        public async Task<HttpStatusCode> Create(JobPositionCreateDTO jobPosition)
        {
            var newJobPosition = new JobPosition()
            {
                Id = new DateTimeOffset(datenow).ToUnixTimeMilliseconds().ToString(),
                Name = jobPosition.Name,
                Code = jobPosition.Code,
                TitleId= jobPosition.TitleId,
            };
            masterJobContext.JobPositions.Add(newJobPosition);
            await masterJobContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPatch("/job-position/update")]
        public async Task<HttpStatusCode> Update(JobPositionEditDTO jobPosition)
        {
            var position = await masterJobContext.JobPositions.FirstOrDefaultAsync(s => s.Id == jobPosition.Id);
            if (position == null)
            {
                return HttpStatusCode.NotFound;
            }
            position.Name = jobPosition.Name;
            position.TitleId = jobPosition.TitleId;
            await masterJobContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("/job-position/{Id}")]
        public async Task<HttpStatusCode> Delete(JobPositionDeleteDTO jobPosition)
        {
            var title1 = await masterJobContext.JobPositions.FirstOrDefaultAsync(s => s.Id == jobPosition.Id);
            if (title1 == null)
            {
                return HttpStatusCode.NotFound;
            }
            masterJobContext.Remove(title1);
            await masterJobContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
