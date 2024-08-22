using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace AnimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private Humano mulher = new Humano(1, "Mafalda", 65, "anos");
        private Humano bebeMenina = new Humano(2, "Valentina", 0, "meses");
        private List<Humano> humanoList;
        private HumansServices service;

        public HumanController()
        {
            humanoList = new List<Humano>() { mulher, bebeMenina };
            service = new HumansServices();
        }


        [HttpGet]
        public List<Humano> Get() => humanoList;

        [HttpGet("GetCyclopMorty")]
        public async Task<string?> GetCyclopMorty() => await service.GetCyclopMorty();

        [HttpGet("{id}")]
        public Humano Get(int id) => humanoList.Where(p => p.ID == id).FirstOrDefault();

        [HttpPost]
        public void Post([FromBody] Humano value) => humanoList.Add(value);

        [HttpPut("{id}")]
        public List<Humano> Put(int id, [FromBody] Humano value)
        {
            var humano = humanoList.Where(p => p.ID == id).FirstOrDefault();

            if (humano == null)
            {
                NotFound();
                return new List<Humano>();
            }

            humano.Nome = value.Nome;
            humano.Idade = value.Idade;

            return humanoList;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var humano = humanoList.Where(p => p.ID == id).FirstOrDefault();

            if (humano != null)
                humanoList.Remove(humano);
        }
    }
}