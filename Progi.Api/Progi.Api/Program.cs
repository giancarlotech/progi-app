using FluentValidation;
using FluentValidation.AspNetCore;
using Progi.Api.Fees;
using Progi.Api.Pipeline;
using Progi.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();


// Adding Pipeline Steps in case the Pipeline will be used in other endpoints
/*
builder.Services.AddScoped<IPipelineStep<FeeContext>, BasicBuyerFeeStep>();
builder.Services.AddScoped<IPipelineStep<FeeContext>, SpecialFeeStep>();
builder.Services.AddScoped<IPipelineStep<FeeContext>, AssociationFeeStep>();
builder.Services.AddScoped<IPipelineStep<FeeContext>, StorageFeeStep>();
builder.Services.AddScoped<Pipeline<FeeContext>>();
*/

builder.Services.AddValidatorsFromAssemblyContaining<FeeRequestValidator>();

//Adding Cors
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:5173")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();


//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Cors
app.UseCors();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();