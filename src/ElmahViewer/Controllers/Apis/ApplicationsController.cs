namespace ElmahViewer.Controllers.Apis
{
    using ElmahViewer.Data;
    using ElmahViewer.Models;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class ApplicationsController : ApiController
    {
        private readonly IElmahApplicationRepository repository;

        public ApplicationsController(IElmahApplicationRepository repository)
        {
            this.repository = repository;
        }

        // GET api/applications
        public ApplicationListModel Get()
        {
            var allApps = this.repository.GetAllApplicationNames().ToList();
            var allAppsModel = new ApplicationListModel { Applications = allApps };

            return allAppsModel;
        }

        // GET api/applications/5
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/applications
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/applications/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/applications/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
