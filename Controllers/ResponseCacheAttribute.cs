using System;

namespace Adondevamos.Controllers
{
    internal class ResponseCacheAttribute : Attribute
    {
        public int Duration { get; set; }
    }
}