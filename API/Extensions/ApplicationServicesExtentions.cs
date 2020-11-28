using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPhotoOfferRepository, PhotoOffersRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors = ActionContext.ModelState.Where(e => e.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Erros = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
