
using AutoMapper;
using Cores.Abstracts;
using Cores.Features.DepartmentCQRS.Command.Handler;
using Cores.Features.DepartmentCQRS.Command.Mapping;
using Cores.Features.DepartmentCQRS.Command.Request;
using Cores.Features.DepartmentCQRS.Query.Handler;
using Cores.Features.DepartmentCQRS.Query.Request;
using Cores.Features.StudentCQRS.Command.Handler;
using Cores.Features.StudentCQRS.Command.Requests;
using Cores.Features.StudentCQRS.Queries.Handlers;
using Cores.Features.StudentCQRS.Queries.Models.mapping;
using Cores.Features.StudentCQRS.Queries.Models.requests;
using Cores.Mapper;
using Cores.Services;
using Data.Entities;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstracts;
using Services.Services;
using System;

namespace Clean_Architecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("defualtconnection");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(connection));

           
            

            #region registration some services


            //  builder.Services.AddTransient<IServiceGenaric<Department>, DepartmentService>();
            builder.Services.AddTransient<IServiceGenaric<Student>, StudentService>();
            builder.Services.AddTransient<IServiceGenaric<Department>, DepartmentService>();   builder.Services.AddTransient<IRequestHandler<StudentlistQuery,List<StudentlistQueryResponse>> , StudentlistHandler > ();
            builder.Services.AddTransient<IRequestHandler<StudentAddCommand, Student>, StudentAddHandler>();
            // irequesthandler<request, response> 
            builder.Services.AddTransient<IRequestHandler<StudentRemoveCommand, Student>, StudentAddHandler>();

            builder.Services.AddTransient<IRequestHandler<StudentUpdateCommand,Student>,StudentAddHandler>();


            builder.Services.AddTransient<IRequestHandler<Departmentlistquery,List<Department>>,Departmentthandler>();
            builder.Services.AddTransient<IRequestHandler<DepartmentGetbyidQuery,Department>,Departmentthandler>();

            builder.Services.AddTransient<IRequestHandler<DepartmentADDCommand, Department>, DepartmentHandler>();

            builder.Services.AddTransient<IRequestHandler<DepartmentremoveCommand, Department>,DepartmentHandler>();
            builder.Services.AddAutoMapper(typeof(Mapperprofile));

            // add mediatR to all DI 
            builder.Services.AddMediatR(Cfg => Cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
         //   builder.Services.AddMediatR(typeof(StudentlistHandler).Assembly);





            #endregion

            var app = builder.Build();
        
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}