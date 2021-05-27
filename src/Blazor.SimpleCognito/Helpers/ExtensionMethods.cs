using System;
using System.Collections.Specialized;
using System.Web;
using Microsoft.AspNetCore.Components;

namespace Blazor.SimpleCognito.Helpers
{
    public static class ExtensionMethods
    {
        // get entire querystring name/value collection
        public static NameValueCollection QueryString(this NavigationManager navigationManager)
        {
            return HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);
        }

        // get single querystring value with specified key
        public static string QueryString(this NavigationManager navigationManager, string key)
        {
            return navigationManager.QueryString()[key];
        }

        public static NameValueCollection Fragment(this NavigationManager navigationManager)
        {
            string fragment = new Uri(navigationManager.Uri).Fragment;
            string query = fragment.Substring(1);
            return HttpUtility.ParseQueryString(query);
        }

        // get single querystring value with specified key
        public static string Fragment(this NavigationManager navigationManager, string key)
        {
            return navigationManager.Fragment()[key];
        }

        public static NameValueCollection QueryString(this string uri)
        {
            return HttpUtility.ParseQueryString(new Uri(uri).Query);
        }

        // get single querystring value with specified key
        public static string QueryString(this string uri, string key)
        {
            return uri.QueryString()[key];
        }
    }
}