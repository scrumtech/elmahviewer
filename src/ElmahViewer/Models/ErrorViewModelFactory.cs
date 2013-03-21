namespace ElmahViewer.Models
{
    using Elmah;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ErrorViewModelFactory : IErrorListViewModelFactory, IErrorDetailsViewModelFactory
    {
        private readonly IErrorLogFactory logFactory;

        public ErrorViewModelFactory(IErrorLogFactory logFactory)
        {
            this.logFactory = logFactory;
        }

        public ErrorListViewModel Create(string id, int index, int size)
        {
            if (index < 0)
            {
                index = 0;
            }
            if(size <= 0)
            {
                size = 10;
            }

            List<ErrorLogEntry> errors = new List<ErrorLogEntry>(size);
            int count = this.logFactory.Create(id).GetErrors(index, size, errors);

            var errorModels = errors.Select(e =>
                                            new ErrorModel
                                            {
                                                Id = e.Id,
                                                HostName = e.Error.HostName,
                                                StatusCode = e.Error.StatusCode,
                                                StatusDescription =
                                                    e.Error.StatusCode > 0
                                                        ? HttpWorkerRequest.GetStatusDescription(e.Error.StatusCode)
                                                        : null,
                                                Type = e.Error.Type,
                                                HumaneType = ErrorDisplay.HumaneExceptionErrorType(e.Error),
                                                Message = e.Error.Message,
                                                User = e.Error.User,
                                                When = FuzzyTime.FormatInEnglish(e.Error.Time),
                                                Iso8601Time = e.Error.Time.ToString("o"),
                                            }).ToList();


            var model = new ErrorListViewModel
                {
                    Count = count,
                    Errors = errorModels,
                    ApplicationName = id,
                    PageIndex = index,
                    PageSize = size
                };

            return model;
        }

        public ErrorDetailsViewModel Create(string applicationId, string errorId)
        {
            var entry = this.logFactory.Create(applicationId).GetError(errorId);
            return new ErrorDetailsViewModel(errorId, entry.Error);
        }
    }
}