using CV.Business.Services.Abstract;
using CV.Core.DTOs.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
       public async Task<IActionResult> CreatePerson(CreatePersonDto createPersonDto)
        {
            var result = await _personService.AddAsync(createPersonDto);
            return Ok(result);
        }

    }
}
