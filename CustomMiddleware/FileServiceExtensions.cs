using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomMiddleware
{
    public static class FileServiceExtensions
    {
        public static IApplicationBuilder UseStaticFileServer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FileServerMiddleware>();
        }
    }
}
