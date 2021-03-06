﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_IOC
{
    public static class Docker
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped<Equals_Application.Interfaces.IAcquirer, Equals_Application.App.AppAcquirer>();
            service.AddScoped<Equals_Application.Interfaces.IFile, Equals_Application.App.AppFile>();

            service.AddScoped(typeof(Equals_Domain.Common.IRepository<>), typeof(Equals_Infra.Common.RepositoryBase<>));

            service.AddScoped<Equals_Domain.Interfaces.IAcquirer, Equals_Infra.Repository.RepositoryAcquirer>();
            service.AddScoped<Equals_Domain.Interfaces.IFile, Equals_Infra.Repository.RepositoryFile>();


            service.AddScoped<Equals_Infra.Context.EfCore>();

            service.AddScoped<Equals_Infra.Uow.IUoW, Equals_Infra.Uow.UnitOfWork>();
        }

    }
}
