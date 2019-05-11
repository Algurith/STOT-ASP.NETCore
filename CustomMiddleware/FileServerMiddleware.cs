using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace CustomMiddleware
{
    public class FileServerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        //private readonly IApplicationBuilder _app;

        public FileServerMiddleware(RequestDelegate next, IApplicationBuilder app, ILoggerFactory loggerFactory, IConfiguration config)
        {
            _next = next;
            //_app = app;
            _logger = loggerFactory.CreateLogger<RequestDelegate>();
            _config = config;

            Init();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"User IP：{context.Connection.RemoteIpAddress.ToString()}");
            await _next.Invoke(context);
        }

        private void Init()
        {
            var serverPath = _config.GetConnectionString("FileServerPath");
            if (!string.IsNullOrWhiteSpace(serverPath))
            {
                var staticFile = new StaticFileOptions();
                staticFile.FileProvider = new PhysicalFileProvider(string.Format(@"{0}", serverPath));
                //_app.UseStaticFiles(staticFile);
            }
        }
    }
}
