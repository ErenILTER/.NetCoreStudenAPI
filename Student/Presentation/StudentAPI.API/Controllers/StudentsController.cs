using StudentAPI.Domain.Entities.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Repositories;
using Student.Application.ViewModels.StudentInformations;
using Student.Domain.Entities;
using Student.Persistence.Repositories;
using System.Net;

namespace StudentAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        readonly private IStudentInformationsReadRepository _studentInformationsReadRepository;
        readonly private IStudentInformationsWriteRepository _studentInformationsWriteRepository;

        public StudentsController
            (IStudentInformationsReadRepository studentInformationsReadRepository, 
            IStudentInformationsWriteRepository studentInformationsWriteRepository)
        {
            _studentInformationsReadRepository = studentInformationsReadRepository;
            _studentInformationsWriteRepository = studentInformationsWriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_studentInformationsReadRepository.GetAll(false));
        }

        [HttpGet("IDcard")]
        public async Task<IActionResult> Get(string IDCard)
        {
            return Ok(await _studentInformationsReadRepository.GetByIdAsync(IDCard, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_StudentInformations_Create Model)
        {
            await _studentInformationsWriteRepository.AddAsync(new()
            {
                StudentId = Model.StudentId,
                StudentName = Model.StudentName,
                StudentSurname = Model.StudentSurname,
                StudentAge = Model.StudentAge
            });
            await _studentInformationsWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_StudentInformations_Update model)
        {
            StudentInformations studentInformations = await _studentInformationsReadRepository.GetByIdAsync(model.IDCard);
            studentInformations.StudentName = model.StudentName;
            studentInformations.StudentSurname = model.StudentSurname;
            studentInformations.StudentAge = model.StudentAge;
            await _studentInformationsWriteRepository.SaveAsync();
            return Ok(studentInformations);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string IDCard)
        {
            await _studentInformationsWriteRepository.RemoveAsync(IDCard);
            await _studentInformationsWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

//public async Task Get()
//{
//    //await _studentInformationsWriteRepository.AddRangeAsync(new()
//    //{
//    //    new() { IDCard =Guid.NewGuid(), StudentId = 4 , StudentName ="Ali", StudentSurname ="Kısa" , StudentAge = 19 ,},
//    //    new() { IDCard =Guid.NewGuid(), StudentId = 5 , StudentName ="Ömer", StudentSurname ="Kaş" , StudentAge = 25 ,},
//    //    new() { IDCard =Guid.NewGuid(), StudentId = 6 , StudentName ="Ekin", StudentSurname ="Lale" , StudentAge = 23 ,},
//    //});
//    //var count = await _studentInformationsWriteRepository.SaveAsync();

//    //StudentInformations P = await _studentInformationsReadRepository.GetByIdAsync("ea513da1-2d89-4deb-90fb-977e32b29014");
//    //P.StudentName = "Eren";
//    //await _studentInformationsWriteRepository.SaveAsync();
//    //await _studentInformationsWriteRepository.AddAsync(new);    
//}
//[HttpGet("{IDCard}")]
//public async Task<IActionResult> Get(string IDCard)
//{
//    StudentInformations studentInformations = await _studentInformationsReadRepository.GetByIdAsync(IDCard);
//    return Ok(studentInformations);
//}
