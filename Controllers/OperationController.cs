﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }
        [HttpPost]
        public decimal Add(Numbers numbers, [FromHeader] string Host,
            [FromHeader(Name = "Content-Length")] String ContentLength)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);       
            return numbers.A - numbers.B;
        }
        [HttpPut]
        public decimal Edit(decimal a, decimal b)
        {
            return a/b;
        }
        [HttpDelete]
        public decimal Delete(decimal a, decimal b)
        {
            return a*b;
        }
    }

    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }
}
