using GestorDeContactos.Server.Services;
using GestorDeContactos.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeContactos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        //Getlist
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _contactRepository.GetList(p => true);

            return Ok(result);
        }

        //Buscar
        [HttpGet("{Id}")]
        public async Task<IActionResult> Search(int Id)
        {
            var result = await _contactRepository.Search(Id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //Insert
        [HttpPost]
        public async Task<IActionResult> Save(Contact contact)
        {
            var result = await _contactRepository.Save(contact);

            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //Modificar
        [HttpPut]
        public async Task<IActionResult> Update(Contact contact)
        {
            var result = await _contactRepository.Update(contact);

            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _contactRepository.Delete(id);

            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
