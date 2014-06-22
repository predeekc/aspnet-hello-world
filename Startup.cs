using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Builder.Extensions;
using Microsoft.AspNet.Http;

namespace AspNetHelloWorld
{
    public class Startup
    {
        public void Configure(IBuilder app)
        {
            // Step 1b: Use the simple handler
            app.Run(MyHandler);         
        }

        // Step 1a: Build a simple handler
        public Task MyHandler(HttpContext context)
        {
            Console.WriteLine("{0} - {1}", context.Request.Method, context.Request.Path.ToString());            

            return context.Response.WriteAsync("<html><head><title>Sample Page</title></head><body>Hello World!<br/><img src='images/helloWorld.png'/></body></html>");
        }
    }
}