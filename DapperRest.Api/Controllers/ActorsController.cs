using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using DapperRest.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;

namespace DapperRest.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActorsController : ControllerBase
  {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public ActorsController(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> GetAll()
    {
      using (IDbConnection connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        var result = await connection.QueryAsync<Actor>("SELECT * FROM ACTOR");
        return Ok(result);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Actor>> GetById(int id)
    {
      var actorSearch = await FindActor(id);
      if (actorSearch.Any())
      {
        return Ok(actorSearch.Single());
      }
      else
      {
        return NotFound();
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var actorSearch = await FindActor(id);
      if (!actorSearch.Any())
      {
        return NotFound();
      }
      using (IDbConnection connection = new MySqlConnection(_connectionString))
      {
        var result = await connection.ExecuteAsync("DELETE FROM MOVIE.ACTOR WHERE id = @Id", new { Id = id });
        return Accepted();
      }
    }

    [HttpPost]
    public async Task<ActionResult<Int32>> CreateActor(Actor actor)
    {
      Console.WriteLine($"Receiving {actor}");
      using (IDbConnection connection = new MySqlConnection(_connectionString))
      {
        connection.Open();
        await connection.ExecuteAsync(@"INSERT INTO MOVIE.ACTOR(name) VALUES (@Name)", actor);
        var newId = connection.Query("Select LAST_INSERT_ID() id");
        actor.Id = Convert.ToInt32(newId.First().id);
        return Accepted(actor);
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Actor actor)
    {
      Console.WriteLine($"Actor to update: {actor}");
      var actorSearch = await FindActor(id);
      if (!actorSearch.Any())
      {
        return NotFound();
      }

      using (IDbConnection connection = new MySqlConnection(_connectionString))
      {
        var result = await connection.ExecuteAsync(@"Update MOVIE.ACTOR set name=@Name WHERE id=@Id", new
        {
          Name = actor.Name,
          Id = id
        });
        return Accepted();
      }
    }

    private async Task<IEnumerable<Actor>> FindActor(int id)
    {
      using (IDbConnection connection = new MySqlConnection(_connectionString))
      {
        return await connection.QueryAsync<Actor>("SELECT * FROM ACTOR WHERE id = @Id", new { Id = id });
      }
    }

  }

}