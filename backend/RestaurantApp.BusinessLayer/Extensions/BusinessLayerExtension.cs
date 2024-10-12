using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.BusinessLayer.Concretes;
using RestaurantApp.BusinessLayer.ValidationRules.BookingValidations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BusinessLayer.Extensions
{
    public static class BusinessLayerExtension
    {
        public static IServiceCollection LoadBusinessLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IMenuTableService, MenuTableManager>();
            services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<CreateBookingValidation>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });
            
            return services;
        }
    }
}
