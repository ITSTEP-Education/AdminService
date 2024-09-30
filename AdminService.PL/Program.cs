using AdminService.BLL.Interfaces;
using AdminService.DAL.EF;
using AdminService.DAL.Interfaces;
using AdminService.DAL.Repositories;
using AdminService.BLL.Services;
using Microsoft.EntityFrameworkCore;
using AdminService.DAL.Filters;
using Asp.Versioning;
using AspNetWeb_Product.Swagger;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductContext>(configure => configure.UseSqlServer(builder.Configuration.GetConnectionString("SmarterDbConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IClientDataService, ClientDataService>();
builder.Services.AddControllers();

//set for varsioning in Swagger;
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddSwaggerGen(configure =>
{
    //add custom operation filter which sets default values
    configure.OperationFilter<SwaggerDefaultValues>();

    //connect attribute [SwaggerIgnore] to hide requested fields from SwaggerUI
    configure.SchemaFilter<SwaggerSkipPropertyFilter>();

    //connect service of display XML comments in SwaggerUI
    var basePath = AppContext.BaseDirectory;
    configure.IncludeXmlComments(Path.Combine(basePath, "AdministrateController.xml"));
});

//Add services of versioning in Swagger
builder.Services.AddApiVersioning(configure =>
{
    configure.DefaultApiVersion = new ApiVersion(1, 0);
    configure.AssumeDefaultVersionWhenUnspecified = true;
    configure.ReportApiVersions = true;
    configure.ApiVersionReader = new UrlSegmentApiVersionReader();
});

builder.Services.AddApiVersioning().AddApiExplorer(configure =>
{
    configure.GroupNameFormat = "'v'VVV";
    configure.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//add CORS policy for permission treat request from other protocols and ports
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        configurePolicy: policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    //configure API definition in Swagger GUI
    app.UseSwaggerUI(configure => {
        configure.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

        var descriptions = app.DescribeApiVersions();

        //Build a swagger endpoint for each dicovered API version
        foreach (var desctiption in descriptions)
        {
            var url = $"/swagger/{desctiption.GroupName}/swagger.json";
            var name = desctiption.GroupName.ToUpperInvariant();
            configure.SwaggerEndpoint(url, name);
        }
    });

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "/{controller=Administrate}/{action=Get}/{product-orders}"
            );
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
