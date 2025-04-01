namespace Basket.Api.Middlewares
{
    public class LoggingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        public async Task Invoke(HttpContext context)
        {
            await _next(context);

        }
    }
}
