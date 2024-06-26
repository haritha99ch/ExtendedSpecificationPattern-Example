﻿using Microsoft.Extensions.DependencyInjection;
using Persistence.Contracts.Repositories;
using Persistence.Repositories;

namespace Persistence;
public static class Configure
{
    public static void AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
    }
}
