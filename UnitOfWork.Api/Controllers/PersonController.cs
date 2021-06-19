using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnitOfWork.Api.Data;
using UnitOfWork.Api.Models;

namespace UnitOfWork.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            this.personRepository = personRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            try
            {
                await personRepository.AddAsync(person);
                return !await unitOfWork.CommitAsync() ? (IActionResult)BadRequest() : Ok();
            }
            catch
            {
                unitOfWork.RoolBack();
                return BadRequest();
            }
        }
    }
}
