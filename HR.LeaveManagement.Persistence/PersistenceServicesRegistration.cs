﻿using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HrLeaveManagementDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("HrLeaveManagementConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

        return services;
    }
}