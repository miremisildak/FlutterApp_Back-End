using Business.Abstract;
using com.sun.org.apache.xpath.@internal.operations;
using CsQuery.Engine.PseudoClassSelectors;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        public IActionResult Task&Lt;IActionResult&Gt; Get([FromQuery] ListProductDetailDto filter) 
        {
            
        }
    }
}
