using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Student.Application.Repositories;
using Student.Persistence;
using Student.Persistence.Contexts;
using Student.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAPI.Persistence
{
    public static class ServisRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection Services)
        {
            Services.AddDbContext<StudentAPIDbContext>(Options => Options.UseNpgsql(Configuration.ConnectionString));
            //Services.AddScoped<ISstudentClubsReadRepository, StudentClubsReadRepository>();
            //Services.AddScoped<ISstudentClubsWriteRepository, StudentClubsWriteRepository>();
            Services.AddScoped<IStudentInformationsReadRepository, StudentInformationsReadRepository>();
            Services.AddScoped<IStudentInformationsWriteRepository, StudentInformationsWriteRepository>();
        }
    }
}
