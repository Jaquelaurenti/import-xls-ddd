using Microsoft.AspNetCore.Mvc;
using ImportSpreadsheet.Application.Dtos;
using ImportSpreadsheet.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace ImportSpreadsheet.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {

        private readonly IApplicationServiceImport applicationServiceImport;


        public ImportController(IApplicationServiceImport applicationServiceImport)
        {
            this.applicationServiceImport = applicationServiceImport;
        }
        // GET api/values
        [HttpGet]
        public object ImportSpredSheet(string directory)
        {
            return Ok(applicationServiceImport.ImportSpredSheet(directory));
        }
    }
}