namespace ElmahViewer.Controllers.Apis
{
    using ElmahViewer.Models;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    public class ElmahErrorsController : ApiController
    {
        /// <summary>
        /// Instance of <see cref="IErrorListViewModelFactory"/>
        /// </summary>
        private readonly IErrorListViewModelFactory listModelFactory;

        private readonly IErrorDetailsViewModelFactory detailsViewModelFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElmahErrorsController"/> class.
        /// </summary>
        /// <param name="listModelFactory"></param>
        /// <param name="detailsViewModelFactory"></param>
        public ElmahErrorsController(IErrorListViewModelFactory listModelFactory, IErrorDetailsViewModelFactory detailsViewModelFactory)
        {
            this.listModelFactory = listModelFactory;
            this.detailsViewModelFactory = detailsViewModelFactory;
        }

        // GET api/elmaherrors
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/elmaherrors
        public ErrorListViewModel GetElmahErrorsByApplication(string applicationId, int index = 0, int size = 20)
        {
            var model = this.listModelFactory.Create(applicationId, index, size);
            return model;
        }

        // GET api/elmaherrors/5
        public ErrorDetailsViewModel Get(string id, string applicationId)
        {
            var details = this.detailsViewModelFactory.Create(applicationId, id);
            return details;
        }

        // POST api/elmaherrors
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/elmaherrors/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/elmaherrors/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
