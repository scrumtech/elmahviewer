
namespace ElmahViewer.Infrastructure
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    public static class NameValueCollectionHelpers
    {
        public static IDictionary<string, string> ToStringBasedDictionary(this NameValueCollection collection)
        {
            // add all items to the dictionary
            return collection.Keys.Cast<string>().ToDictionary(key => key, key => collection[key.ToString()]);
        }
    }
}