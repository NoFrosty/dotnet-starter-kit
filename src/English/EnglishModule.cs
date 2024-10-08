﻿using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Starter.WebApi.English.Domain;
using FSH.Starter.WebApi.English.Endpoints.v1;
using FSH.Starter.WebApi.English.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.English.Infrastructure;
public static class EnglishModule
{
    public class Endpoints : CarterModule
    {
        public Endpoints() : base("english") { }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var beanGroup = app.MapGroup("beans").WithTags("beans");
            beanGroup.MapBeanCreationEndpoint();
            beanGroup.MapGetBeanEndpoint();
            beanGroup.MapGetBeanListEndpoint();
            beanGroup.MapBeanUpdationEndpoint();
            beanGroup.MapBeanDeletionEndpoint();
            var heartGroup = app.MapGroup("hearts").WithTags("hearts");
            heartGroup.MapHeartCreationEndpoint();
            heartGroup.MapGetHeartEndpoint();
            heartGroup.MapGetHeartListEndpoint();
            heartGroup.MapHeartUpdationEndpoint();
            heartGroup.MapHeartDeletionEndpoint();

            var cardGroup = app.MapGroup("cards").WithTags("cards");
            cardGroup.MapCardCreationEndpoint();
            cardGroup.MapGetCardEndpoint();
            cardGroup.MapGetCardListEndpoint();
            cardGroup.MapCardUpdationEndpoint();
            //cardGroup.MapCardDeletionEndpoint();

            var progressGroup = app.MapGroup("progress").WithTags("progress");
            progressGroup.MapProgressCreationEndpoint();
            progressGroup.MapGetProgressEndpoint();
            progressGroup.MapGetProgressListEndpoint();
            progressGroup.MapProgressUpdationEndpoint();
        }
    }

    public static WebApplicationBuilder RegisterEnglishServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.BindDbContext<EnglishDbContext>();
        builder.Services.AddScoped<IDbInitializer, EnglishDbInitializer>();
        builder.Services.AddKeyedScoped<IRepository<BeanItem>, EnglishRepository<BeanItem>>("english:beans");
        builder.Services.AddKeyedScoped<IReadRepository<BeanItem>, EnglishRepository<BeanItem>>("english:beans");
        builder.Services.AddKeyedScoped<IRepository<HeartItem>, EnglishRepository<HeartItem>>("english:hearts");
        builder.Services.AddKeyedScoped<IReadRepository<HeartItem>, EnglishRepository<HeartItem>>("english:hearts");
        builder.Services.AddKeyedScoped<IRepository<CardItem>, EnglishRepository<CardItem>>("english:cards");
        builder.Services.AddKeyedScoped<IReadRepository<CardItem>, EnglishRepository<CardItem>>("english:cards");
        builder.Services.AddKeyedScoped<IRepository<ProgressItem>, EnglishRepository<ProgressItem>>("english:progress");
        builder.Services.AddKeyedScoped<IReadRepository<ProgressItem>, EnglishRepository<ProgressItem>>("english:progress");

        return builder;
    }

    public static WebApplication UseEnglishModule(this WebApplication app)
    {
        return app;
    }
}
