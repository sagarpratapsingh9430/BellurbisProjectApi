using Microsoft.AspNetCore.Mvc;
using BellurbisProjectApi.Models;
using BellurbisProjectApi.Repository;

namespace BellurbisProjectApi.Controllers
{ 
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RPController : Controller

    {
        //private RPRepository FirstRepo;
        private readonly RPRepository FirstRepo = null;
        public RPController(RPRepository _FirstRepo)
        {
            FirstRepo = _FirstRepo;
        }
       
        public IActionResult Index()
        {
            var a = FirstRepo.Index();
            return Ok(a);
        }

        public IActionResult PlayerIndex()
        {
            var a = FirstRepo.PlayerIndex();
            return Ok(a);
        }
        [HttpPost]
        public IActionResult Create(RestaurantModel emp)
        {
            var a = FirstRepo.Create(emp);
            return Ok(a);
        }

        [HttpPost]
        public IActionResult PlayerCreate(PlayerModel mac)
        {
            var b = FirstRepo.PlayerCreate(mac);
            return Ok(b);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
             
            return Ok(FirstRepo.Edit(id));
        }


        [HttpGet("{id}")]
        public IActionResult PlayerEdit(int id)
        {
           
            return Ok(FirstRepo.PlayerEdit(id));
        }
        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            
            return Ok(FirstRepo.Delete(id));
        }

        [HttpGet("{id}")]
        public IActionResult PlayerDelete(int id)
        {
           
            return Ok(FirstRepo.PlayerDelete(id));
        }
        [HttpGet]
        public IActionResult PlayersFavRestroIndex()
        {
            return Ok(FirstRepo.Index());
        }
        public IActionResult Getall()
        {
            return Ok(FirstRepo.getall());
        }

        [HttpGet("{name}")]
        public List<RestaurantModel> ResturantByName(string name)
        {
            return (FirstRepo.ResturantByName(name));
        }
        [HttpGet("{name}")]
        public List<PlayerModel> PlayerByName(string name)
        {
            return (FirstRepo.PlayerByName(name));
        }

        [HttpGet("{name}")]
        public PlayersFavRestroList FvtplyRest(string name)
        {
            
            var statuss = true;
            return (FirstRepo.FvtplyRest(name, statuss));


        }

        [HttpGet("{Name}")]
        public IActionResult GetbyAge(string Name, int Age)
        {
            var result = FirstRepo.GetbyAge(Name, Age);
            return Ok(result);
        }

    }
}