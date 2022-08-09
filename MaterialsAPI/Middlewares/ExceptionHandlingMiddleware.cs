namespace MaterialsAPI.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (KeyNotFoundException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (NullReferenceException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Error occured");
            }
        }
    }
}
