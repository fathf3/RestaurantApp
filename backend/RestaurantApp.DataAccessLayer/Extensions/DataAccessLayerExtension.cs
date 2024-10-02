﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.DataAccessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DataAccessLayer.Extensions
{
    public static class DataAccessLayerExtension
    {
        public static IServiceCollection LoadDataAccessLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SignalRContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped<IAboutDal, EfAboutDal>();

            return services;
        }
    }
}
