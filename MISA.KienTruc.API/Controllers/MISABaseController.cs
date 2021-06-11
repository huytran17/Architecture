using Microsoft.AspNetCore.Mvc;
using MISA.KienTruc.Core.Intefaces.Repositories;
using MISA.KienTruc.Core.Intefaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.KienTruc.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class MISABaseController<MISAEntity> : ControllerBase
    {
        #region Declare
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion

        #region Constructor
        public MISABaseController(IBaseService<MISAEntity> baseService,
        IBaseRepository<MISAEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        // GET: api/<MISABaseController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _baseRepository.GetAll();
            return Ok(entities);
        }

        // GET api/<MISABaseController>/5
        [HttpGet("{entityId}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            return Ok(entity);
        }

        // POST api/<MISABaseController>
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            var response = _baseService.Insert(entity);
            return Ok(response);
        }

        // PUT api/<MISABaseController>/5
        [HttpPut("{entityId}")]
        public IActionResult Put([FromBody] MISAEntity entity, [FromRoute] Guid entityId)
        {
            var response = _baseService.Update(entity, entityId);
            return Ok(response);
        }

        // DELETE api/<MISABaseController>/5
        [HttpDelete("{entityId}")]
        public IActionResult Delete([FromRoute] Guid entityId)
        {
            var response = _baseService.Delete(entityId);
            return Ok(response);
        }
        #endregion
    }
}
