using bendita_ajuda_back_end.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace bendita_ajuda_back_end.Extensions
{
	public static class ApiExceptionMiddlewareExtensions
	{
		public static void ConfigureExceptionHandler(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";

					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						await context.Response.WriteAsync(new ErrorDetails()
						{
							StatusCode = context.Response.StatusCode,
							Message = contextFeature.Error.Message,
							Trace = contextFeature.Error.StackTrace
						}.ToString());
					}
				});
			});
		}
	}
}
