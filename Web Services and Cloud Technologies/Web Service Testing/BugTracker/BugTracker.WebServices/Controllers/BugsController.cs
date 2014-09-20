namespace BugTracker.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using BugTracker.Data;
    using BugTracker.Data.Contracts;
    using BugTracker.Model;
    using BugTracker.WebServices.Models;

    public class BugsController : ApiController
    {
        private readonly IBugTrackerData bugData;

        public BugsController(IBugTrackerData bugData)
        {
            this.bugData = bugData;
        }

        public BugsController()
            : this(new BugTrackerData())
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.bugData.Bugs.Select(BugOutputModel.FromBug));
        }

        [HttpGet]
        public IHttpActionResult PendingBugs()
        {
            return this.Ok(this.bugData.Bugs.Where(b => b.Status == Status.Pending).Select(BugOutputModel.FromBug));
        }

        [HttpPost]
        public IHttpActionResult Log(string bugDescription)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newBug = new Bug { Text = bugDescription, LogDate = DateTime.Now, Status = Status.Pending };
            this.bugData.Bugs.Add(newBug);
            this.bugData.SaveChanges();
            return this.Ok(newBug.Id);
        }

        [HttpGet]
        public IHttpActionResult ByType(Status status)
        {
            return this.Ok(this.bugData.Bugs.Where(b => b.Status == status).Select(BugOutputModel.FromBug));
        }

        [HttpGet]
        public IHttpActionResult After(DateTime date)
        {
            return this.Ok(this.bugData.Bugs.Where(b => b.LogDate >= date).Select(BugOutputModel.FromBug)); 
        }
    }
}