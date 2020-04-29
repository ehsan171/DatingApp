using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController: ControllerBase
    {
        
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        // GET api/stydent
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {

           


    Language[] languages = new Language[]
    {
        new Language {Id = 1, Name = "English"},
        new Language {Id = 2, Name = "Russian"}
    };

    Person[] persons = new Person[]
    {
        new Person { LanguageId = 1, FirstName = "Tom" },
        new Person { LanguageId = 1, FirstName = "Sandy" },
        new Person { LanguageId = 2, FirstName = "Vladimir" },
        new Person { LanguageId = 2, FirstName = "Mikhail" },
    };

    var result = languages.GroupJoin(persons, lang => lang.Id, pers => pers.LanguageId, 
        (lang, ps) => new { Key = lang.Name, Persons = ps });

    Debug.WriteLine("Group-joined list of people speaking either English or Russian:");
    foreach (var language in result)
    {
        Debug.WriteLine(String.Format("Persons speaking {0}:", language.Key));

        foreach (var person in language.Persons)
        {
            Debug.WriteLine(person.FirstName);
        }
    }

            var students = await _context.Students.ToListAsync();
            return Ok(students);
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            return Ok(student);
        }
    }
}