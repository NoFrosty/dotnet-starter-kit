using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Starter.WebApi.Math.Domain;
using FSH.Starter.WebApi.Math.Endpoints.v1;
using FSH.Starter.WebApi.Math.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Math.Infrastructure
{
    public static class MathModule
    {
        public class Endpoints : CarterModule
        {
            public Endpoints() : base("math") { }
            public override void AddRoutes(IEndpointRouteBuilder app)
            {
                var elemNumScores = app.MapGroup("elemNumScores").WithTags("elemNumScores");
                elemNumScores.MapCreateElemNumScoreEndpoint();
                elemNumScores.MapGetElemNumScoreEndpoint();
                elemNumScores.MapUpdateElemNumScoreEndpoint();
                elemNumScores.MapGetElemNumScoreTopRanksEndpoint();

                var middleLinearScores = app.MapGroup("middleLinearScores").WithTags("middleLinearScores");
                middleLinearScores.MapCreateMiddleLinearScoreEndpoint();
                middleLinearScores.MapGetMiddleLinearScoreEndpoint();
                middleLinearScores.MapUpdateMiddleLinearScoreEndpoint();
                middleLinearScores.MapGetMiddleLinearScoreTopRanksEndpoint();

                var middleLinearProgress = app.MapGroup("middleLinearProgress").WithTags("middleLinearProgress");
                middleLinearProgress.MapGetMiddleLinearProgressEndpoint();
                middleLinearProgress.MapUpdateMiddleLinearProgressEndpoint();
            }
        }

        public static WebApplicationBuilder RegisterMathServices(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);
            builder.Services.BindDbContext<MathDbContext>();
            builder.Services.AddScoped<IDbInitializer, MathDbInitializer>();
            builder.Services.AddKeyedScoped<IRepository<ElemNumScoreItem>, MathRepository<ElemNumScoreItem>>("math:elemNumScores");
            builder.Services.AddKeyedScoped<IReadRepository<ElemNumScoreItem>, MathRepository<ElemNumScoreItem>>("math:elemNumScores");

            builder.Services.AddKeyedScoped<IRepository<MiddleLinearScoreItem>, MathRepository<MiddleLinearScoreItem>>("math:middleLinearScores");
            builder.Services.AddKeyedScoped<IReadRepository<MiddleLinearScoreItem>, MathRepository<MiddleLinearScoreItem>>("math:middleLinearScores");

            builder.Services.AddKeyedScoped<IRepository<MiddleLinearProgressItem>, MathRepository<MiddleLinearProgressItem>>("math:middleLinearProgress");
            builder.Services.AddKeyedScoped<IReadRepository<MiddleLinearProgressItem>, MathRepository<MiddleLinearProgressItem>>("math:middleLinearProgress");

            return builder;
        }

        public static WebApplication UseMathModule(this WebApplication app)
        {
            return app;
        }
    }
}
