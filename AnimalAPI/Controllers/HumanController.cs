using Domain;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private Humano mulher = new Humano(1, "Mafalda", 65, "anos");
        private Humano bebeMenina = new Humano(2, "Valentina", 0, "meses");

        private List<Humano> humanoList;


        public HumanController()
        {
            humanoList = new List<Humano>() { mulher, bebeMenina };
        }

        // GET: api/<HumanController>
        [HttpGet]
        public List<Humano> Get() => humanoList;


        // POST api/<HumanController>
        [HttpPost]
        public void Post([FromBody] Humano value) => humanoList.Add(value);

        // PUT api/<HumanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var menina = humanoList.Where(p => p.ID == id).FirstOrDefault();

            if (menina == null)
            {
                NotFound();
                return;
            }

            menina.Nome = value;
        }

        // DELETE api/<HumanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var menina = humanoList.Where(p => p.ID == id).FirstOrDefault();

            if (menina != null)
                humanoList.Remove(menina);
        }
    }
}