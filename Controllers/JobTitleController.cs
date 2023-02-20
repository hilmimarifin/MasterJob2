using MasterJob.DTO;
using MasterJob.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace MasterJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {   
        public DateTime datenow = DateTime.Now;

        private readonly MasterJobContext masterJobContext;
        public JobTitleController(MasterJobContext masterJobContext)
        {
            this.masterJobContext = masterJobContext;
        }
        [HttpGet("/job-title")]
        public async Task<ActionResult<List<JobTitleDTO>>> Get()
        {
            var List = await masterJobContext.JobTitles.Select(x => new JobTitleDTO
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
            }).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
                return Ok(List);
        }

        [HttpGet("/job-title/{Id}")]
        public async Task<ActionResult<JobTitleDTO>> GetById(string Id)
        {
            var title = await masterJobContext.JobTitles.FirstOrDefaultAsync(s => s.Id == Id);
            if (title == null)
            {
                return NotFound();
            } else
            {
                return Ok(title);
            }
        }


        [HttpPost("/job-title/create")]
        public async Task<HttpStatusCode> Create(JobTitleCreateDTO jobTitle)
        {
            var newJobtitle = new JobTitle()
            {   
                Id = new DateTimeOffset(datenow).ToUnixTimeMilliseconds().ToString(),
                Name = jobTitle.Name,
                Code = jobTitle.Code,
            };
            masterJobContext.JobTitles.Add(newJobtitle);
            await masterJobContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPatch("/job-title/update")]
        public async Task<HttpStatusCode> Update(JobTitleEditDTO jobTitle)
        {
            var title = await masterJobContext.JobTitles.FirstOrDefaultAsync(s => s.Id == jobTitle.Id);
            if (title == null)
            {
                return HttpStatusCode.NotFound;
            }
            title.Name = jobTitle.Name;
            await masterJobContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("/job-title/delete")]
        public async Task<HttpStatusCode> Delete(JobTitleDeleteDTO jobTitle)
        {
            Console.WriteLine("is this trigered {0}", jobTitle.Id);

            var title1 = await masterJobContext.JobTitles.FirstOrDefaultAsync(s => s.Id == jobTitle.Id);
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
