namespace Project.Settings
{
    public static class Dependencies
    {

        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {

        }

    }
}
