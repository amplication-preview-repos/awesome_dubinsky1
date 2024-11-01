using DecentralizedErp.APIs;

namespace DecentralizedErp;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentsService, DepartmentsService>();
        services.AddScoped<IFinancesService, FinancesService>();
        services.AddScoped<IOrganizationsService, OrganizationsService>();
        services.AddScoped<IProjectsService, ProjectsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
