using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : Controller
    {
        private INationalParkRepository _npRepository;

        private readonly IMapper _mapper;
        public NationalParksController(INationalParkRepository nationalParkRepository, IMapper mapper)
        {
            _npRepository = nationalParkRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetNationalParks()
        {
            var npList = _npRepository.GetNationalParks();

            var objlist = new List<NationalParkDto>();

            foreach(var obj in npList)
            {
                objlist.Add(_mapper.Map<NationalParkDto>(obj));
            }

            return Ok(objlist);
        }

        [HttpGet("{id:int}",Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int id)
        {
            var obj = _npRepository.GetNationalPark(id);
            if(obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<NationalParkDto>(obj);
            return Ok(objDto);
        }

        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDto nationalParkDto)
        {
            if(nationalParkDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_npRepository.NationalParkExists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park already exists");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_npRepository.CreateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }
            

            //returning the object that we just created
            return CreatedAtRoute("GetNationalPark", new { id = nationalParkObj.Id},nationalParkObj);

        }

        [HttpPatch("{id:int}",Name = "UpdateNationalPark")]
        public ActionResult UpdateNationalPark(int id,[FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null || id != nationalParkDto.Id)
            {
                return BadRequest(ModelState);
            }

            var nationalParkObj = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_npRepository.UpdateNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


        [HttpDelete("{id:int}",Name = "DeleteNationalPark")]
        public ActionResult DeleteNationalPark(int id)
        {
            if (!_npRepository.NationalParkExists(id))
            {
                return NotFound();
            }
            var nationalParkObj = _npRepository.GetNationalPark(id);

            if (!_npRepository.DeleteNationalPark(nationalParkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {nationalParkObj.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }



    }
}
