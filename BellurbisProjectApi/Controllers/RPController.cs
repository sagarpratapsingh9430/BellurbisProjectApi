using Microsoft.AspNetCore.Mvc;
using BellurbisProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using BellurbisProjectApi.Repository;

namespace BellurbisProjectApi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RPController : Controller

    {
        private RPRepository FirstRepo;

        public RPController(RPRepository _FirstRepo)
        {
            FirstRepo = _FirstRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var a = FirstRepo.Index();
            return Ok(a);
        }

        [HttpGet]
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
            var a = FirstRepo.Edit(id);
            return Ok(a);
        }


        [HttpGet("{id}")]
        public IActionResult PlayerEdit(int id)
        {
            var a = FirstRepo.PlayerEdit(id);
            return Ok(a);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FirstRepo.Delete(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult PlayerDelete(int id)
        {
            FirstRepo.PlayerDelete(id);
            return Ok();
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
        public FavRestraurantPlayer favplyRes(string name)
        {
            var statuss = true;
            return (FirstRepo.FvtplyRest(name, statuss));
        }
    }
}
