﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace getfit.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        //IEntityTypeConfiguration configuration;
        //readonly dynamic db;
        public ValuesController(IConfiguration config)
        {
            var connStr = config["ConnectionStrings:getfitDbContext"];
            var conn = new NpgsqlConnection(connStr);
            //this.db = conn.Open();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/valuess
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
            Exercise posted = value.ToObject<Exercise>();
            var optionsBuilder = new DbContextOptionsBuilder<getFitDbContext>();
            //optionsBuilder.UseNpgsql(Configuration.GetConnectionString("getfitDbContext"));
            //optionsBuilder.UseNpgsql("Data Source=getfitDbContext.cs");
            using (getFitDbContext db = new getFitDbContext(optionsBuilder.Options))
            {
                db.Exercises.Add(posted);
                db.SaveChanges();
            }
            return;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
