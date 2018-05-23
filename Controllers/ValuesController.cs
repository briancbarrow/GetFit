using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.Extensions.Configuration;
using getfit.Models;

namespace getfit.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //private readonly IDataAccessProvider
        //IEntityTypeConfiguration configuration;
        //readonly dynamic db;
        public ValuesController(IConfiguration config)
        {
            // var connStr = config["ConnectionStrings:getfitDbContext"];
            // var conn = new NpgsqlConnection(connStr);
            // this.db = conn.Open();
            Configuration = config;
        }
        public IConfiguration Configuration { get; }
        // GET api/values
        [HttpGet]
        public List<getfit.Models.Exercise> Get()
        //public IEnumerable<string> Get()
        {
            var connStr = Configuration.GetConnectionString("getfitDbContext");
            var optionsBuilder = new DbContextOptionsBuilder<getFitDbContext>();
            optionsBuilder.UseNpgsql(connStr);
            //optionsBuilder.UseNpgsql("Data Source=getfitDbContext.cs");
            using (getFitDbContext db = new getFitDbContext(optionsBuilder.Options))
            {
                List<getfit.Models.Exercise> myList = db.Exercises.ToList();
                return myList;
            }


            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            var connStr = Configuration.GetConnectionString("getfitDbContext");
            Exercise posted = value.ToObject<Exercise>();
            var optionsBuilder = new DbContextOptionsBuilder<getFitDbContext>();
            optionsBuilder.UseNpgsql(connStr);
            //optionsBuilder.UseNpgsql("Data Source=getfitDbContext.cs");
            using (getFitDbContext db = new getFitDbContext(optionsBuilder.Options))
            {
                db.Exercises.Add(posted);
                db.SaveChanges();
            }
            return;
        }

        // PUT api/values/5`
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var connStr = Configuration.GetConnectionString("getfitDbContext");
            var optionsBuilder = new DbContextOptionsBuilder<getFitDbContext>();
            optionsBuilder.UseNpgsql(connStr);
            using (getFitDbContext db = new getFitDbContext(optionsBuilder.Options))
            {
                if (db.Exercises.Where(t => t.ExerciseId == id).Count() > 0) // Check if element exists
                    db.Exercises.Remove(db.Exercises.First(t => t.ExerciseId == id));
                db.SaveChanges();
            }            
        }
    }
}
