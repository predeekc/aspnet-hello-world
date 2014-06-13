using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Builder.Extensions;

using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using System;

namespace KWebStartup
{
    public class Startup
    {
        public void Configure(IBuilder app)
        {
        	// Step 4: Add a pipeline for child folders
    		app.Map("/private", childApp => {
				childApp.UseMyPrivateMiddleware();
				childApp.Run(MyHandler);
			});

    		// Step 3: Use static files middleware
            app.UseStaticFiles();

            // Step 1b: Use athe simple handler
            app.Run(MyHandler);         
        }

        // Step 1a: Build a simple handler
        public Task MyHandler(HttpContext context)
        {
			Console.WriteLine("{0} - {1}", context.Request.Method, context.Request.Path.ToString());			

    		var writer = new StreamWriter(context.Response.Body);
			writer.Write("<html><head><title>Sample Page</title></head><body>Hello World!<br/><img src='images/helloWorld.png'/></body></html>");
			writer.Flush();

			return Task.FromResult<object>(null);
        }
    }

	// Step 2a: Build a simple header injector middleware (before and after)
    public class MyPrivateMiddleware
    {
    	RequestDelegate _next;

    	public MyPrivateMiddleware(RequestDelegate next)
    	{
    		_next = next;
    	}

		public async Task Invoke(HttpContext context)
        {
    		context.Response.Headers.Set("cache-control", "private, max-age=0, no-cache");

    		await _next(context);

    		// Do cleanup work here
        }
    }

    // Step 2b: Build a simple extension wrapper around middleware registration
    public static class MyPrivateMiddlewareExtensions
    {
    	public static void UseMyPrivateMiddleware(this IBuilder app)
    	{
    		app.Use(next => new MyPrivateMiddleware(next).Invoke);
    	}
    }
}