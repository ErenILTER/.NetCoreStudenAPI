using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Repositories;
using Student.Domain.Entities;

namespace StudentAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        readonly private IStudentInformationsReadRepository _studentInformationsReadRepository;
        readonly private IStudentInformationsWriteRepository _studentInformationsWriteRepository;

        public StudentsController(IStudentInformationsReadRepository studentInformationsReadRepository, IStudentInformationsWriteRepository studentInformationsWriteRepository = null)
        {
            _studentInformationsReadRepository = studentInformationsReadRepository;
            _studentInformationsWriteRepository = studentInformationsWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await _studentInformationsWriteRepository.AddRangeAsync(new()
            {
                new() { IDCard =Guid.NewGuid(), StudentId = 4 , StudentName ="Ali", StudentSurname ="Kısa" , StudentAge = 19 ,},
                new() { IDCard =Guid.NewGuid(), StudentId = 5 , StudentName ="Ömer", StudentSurname ="Kaş" , StudentAge = 25 ,},
                new() { IDCard =Guid.NewGuid(), StudentId = 6 , StudentName ="Ekin", StudentSurname ="Lale" , StudentAge = 23 ,},
            });
            var count = await _studentInformationsWriteRepository.SaveAsync();

        }
        [HttpGet("{IDCard}")]
        public async Task<IActionResult> Get(string IDCard)
        {
          StudentInformations studentInformations = await _studentInformationsReadRepository.GetByIdAsync(IDCard);
            return Ok(studentInformations);
        }
        
    }
}
