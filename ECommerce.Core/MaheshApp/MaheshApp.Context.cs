using System;
using Microsoft.AspNetCore.Http;

namespace Mahesh.MicroApp.Core
{
    public static partial class MaheshApp
    {
        private const string contextAccessorNullExceptionMessage="{0} is null and must be configures by calling the \"Configure\" or \"ConfigureContext\" method before it cane be used.";
        private static IHttpContextAccessor _httpContextAccessor;
        private static IHttpContextAccessor HttpContextAccessor{
            get{
                if(_httpContextAccessor==null)
                    throw new Exception(string.Format(contextAccessorNullExceptionMessage, $"{nameof(MaheshApp)}.{nameof(HttpContextAccessor)}"));
            return _httpContextAccessor;
            }
        }
        internal static HttpContext HttpContext=>HttpContextAccessor.HttpContext;
    }
}