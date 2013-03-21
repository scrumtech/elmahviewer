namespace ElmahViewer.Models
{
    using System.Collections.Generic;

    public class ErrorListViewModel
    {
        public int Count { get; set; }
        public IList<ErrorModel> Errors { get; set; }
        public string ApplicationName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}