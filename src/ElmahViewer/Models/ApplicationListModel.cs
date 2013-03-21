namespace ElmahViewer.Models
{
    using System.Collections.Generic;

    public class ApplicationListModel
    {
        public IEnumerable<string> Applications { get; set; }
        public string CurrentApplication { get; set; }
    }
}