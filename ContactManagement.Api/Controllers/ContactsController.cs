namespace ContactManagement.Api.Controllers{
    using ContactManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly List<Contacts> contacts = new();

        // GET: api/Contacts
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(contacts);
        }
    
        [HttpGet("{id}")]
        public IActionResult GetContactById(int id ){
            var contact =contacts.FirstOrDefault(c =>c.Id ==id);
            if (contact == null)
            {
               return NotFound();
           }
            return Ok(contact);
    
        }
    [HttpPost]
    public IActionResult CreateContact(Contacts contact){
        contact.Id=contacts.Count +1;
        contact.CreatedAt=DateTime.UtcNow;
        contacts.Add(contact);
        return CreatedAtAction(nameof(GetContactById),new {id=contact.Id} ,contact);

        }

[HttpPut("{id}")]
public IActionResult UpdateContact(int id ,Contacts updatedContact){

    var contact = contacts.FirstOrDefault( c => c.Id == id);
    if(contact == null){
        return NotFound();
    }
    contact.FirstName=updatedContact.FirstName;
    contact.LastName=updatedContact.LastName;
    contact.Email=updatedContact.Email;
    contact.PhoneNumber=updatedContact.PhoneNumber;
    return Ok(contact);
}
[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var contact = contacts.FirstOrDefault(c => c.Id == id);

    if (contact == null)
    {
        return NotFound();
    }

    contacts.Remove(contact);

    return NoContent();
}
}
}