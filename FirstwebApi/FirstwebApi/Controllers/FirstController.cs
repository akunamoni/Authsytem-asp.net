using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {
        
        private readonly DataContext _context;

        public FirstController(DataContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<First>>> Get()
        {
           
            return Ok(await _context.First.ToListAsync());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<First>> Get(int Id)
        {
            var hero = await _context.First.FindAsync(Id);
            if (hero == null)
                return BadRequest("Hero not found");
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<First>>> AddHero(First hero)
        {
            _context.First.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.First.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<First>>> UpdateHero(First request)
        {
            var dbhero = await _context.First.FindAsync(request.Id);
            if (dbhero == null)
                return BadRequest("Hero not found.");

            dbhero.Name = request.Name;
            dbhero.FirstName = request.FirstName;
            dbhero.LastName = request.LastName;
            dbhero.Place = request.Place;

            await _context.SaveChangesAsync();


            return Ok(await _context.First.ToListAsync());

        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<First>> Delete(int Id)
        {
            var dbhero = await _context.First.FindAsync(Id);
            if (dbhero == null)
                return BadRequest("Hero not found");
            _context.First.Remove(dbhero);
            await _context.SaveChangesAsync();
            return Ok(await _context.First.ToListAsync());
        }
       // private static List<First> heroes = new List<First>
       // {

              //  new First {
               //     Id = 1,
               //     Name ="Spider Man",
               //     FirstName ="Peter",
               //     LastName="Parker",
                //    Place="New York City"
               // },
               // new First {
               //     Id = 2,
               //     Name ="Iron Man",
                //    FirstName ="Tony",
               //     LastName="Stark",
               //     Place="Long Island"
               // }


       // };
        //[HttpGet]
        // public async Task<ActionResult<List<First>>> Get()
        //{

        //  return Ok(heroes);
        //}
        //[HttpGet("{Id}")]
        //public async Task<ActionResult<First>> Get( int Id)
        //{
        //var hero = heroes.Find(h => h.Id == Id);
        //if (hero == null)
        //     return BadRequest("Hero not found");
        //  return Ok(hero);
        // }
        // [HttpPost]
        //public async Task<ActionResult<List<First>>> AddHero(First hero)
        // {
        //     heroes.Add(hero);
        //    return Ok(heroes);
        //}
        // [HttpPut]
        // public async Task<ActionResult<List<First>>> UpdateHero(First request)
        // {
        //    var hero = heroes.Find(h => h.Id == request.Id);
        //    if (hero == null)
        //        return BadRequest("Hero not found.");

        //   hero.Name = request.Name;
        //   hero.FirstName = request.FirstName;
        //   hero.LastName = request.LastName;
        //   hero.Place = request.Place;

        //   return Ok(heroes);

        // }
        //[HttpDelete("{Id}")]
        // public async Task<ActionResult<First>> Delete(int Id)
        // {
        //    var hero = heroes.Find(h => h.Id == Id);
        //    if (hero == null)
        //        return BadRequest("Hero not found");
        //    heroes.Remove(hero);
        //   return Ok(heroes);
        // }

    }
}
