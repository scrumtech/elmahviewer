namespace ElmahViewer.Models
{
    using System;
    using System.Collections.Generic;
    using Elmah;

    using ElmahViewer.Infrastructure;

    /// <summary>
    /// Represents an error
    /// </summary>
    public class ErrorDetailsViewModel
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Message { get; set; }

        public string Detail { get; set; }

        public string ApplicationName { get; set; }

        public IDictionary<string, string> Cookies { get; protected set; }

        public IDictionary<string, string> Form { get; protected set; }

        public string HostName { get; set; }

        public IDictionary<string, string> QueryString { get; protected set; }

        public IDictionary<string, string> ServerVariables { get; protected set; }

        public string Source { get; set; }

        public int StatusCode { get; set; }

        public DateTime Time { get; set; }

        public string User { get; set; }

        public string WebHostHtmlMessage { get; set; }

        public ErrorDetailsViewModel(string id, Error errorDetail)
        {
            Id = id;
            Type = errorDetail.Type;
            Message = errorDetail.Message;
            Detail = errorDetail.Detail;
            ApplicationName = errorDetail.ApplicationName;
            Cookies = errorDetail.Cookies.ToStringBasedDictionary();
            Form = errorDetail.Form.ToStringBasedDictionary();
            HostName = errorDetail.HostName;
            QueryString = errorDetail.QueryString.ToStringBasedDictionary();
            ServerVariables = errorDetail.ServerVariables.ToStringBasedDictionary();
            Source = errorDetail.Source;
            StatusCode = errorDetail.StatusCode;
            Time = errorDetail.Time;
            User = errorDetail.User;
            WebHostHtmlMessage = errorDetail.WebHostHtmlMessage;
        }
    }
}