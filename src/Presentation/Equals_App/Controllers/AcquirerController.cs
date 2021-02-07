using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Equals_App.Controllers
{
    [Route("/v1/api/[controller]")]
    [ApiController]
    public class AcquirerController : ControllerBase
    {
        private readonly Equals_Application.Interfaces.IAcquirer _repoacq;
        private readonly Equals_Application.Interfaces.IFile _repofile;

        public AcquirerController(Equals_Application.Interfaces.IAcquirer acq, Equals_Application.Interfaces.IFile file)
        {
            _repoacq = acq;
            _repofile = file;
        }

        [HttpPost, Route("acquirer")]
        public IActionResult Create([FromBody]Equals_Application.Input.Acquirer model)
        {
            if (model is null)
                return BadRequest();
            var resp = _repoacq.Add(model);

            return Ok(resp);
        }

        [HttpPost, Route("file")]
        public IActionResult Get([FromBody]Equals_Application.Input.Acquirer model)
        {
            if (model is null)
                return BadRequest();
            var resp = _repofile.Add(model);

            return Ok(resp);
        }

        [HttpGet, Route("adq/{name}")]
        public IActionResult Acquirer(string name)
        {
            if (name.Equals(string.Empty))
                return BadRequest();
            var resp = _repofile.File(name);

            return Ok(resp);
        }
    }
}