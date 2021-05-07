using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;

        IMongoCollection<Infected> _infectedCollection;

        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectedDto dto)
        {
            var Infected = new Infected(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectedCollection.InsertOne(Infected);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

    }
}