using System;
using System.Collections.Generic;
using AutoMapper;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace CotecAPI.Controllers
{
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly UserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(UserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("api/v1/login/admin")]
        public ActionResult<AdminReadDTO> AdminLogin([FromBody] UserLoginDTO userDTO)
        {
            var user = _repository.GetAdmin(userDTO.Username);
            if(user == null)
                return new BadRequestObjectResult(new { message = "User Not Found", currentDate = DateTime.Now });
            
            if(user.Password!=userDTO.Password)
                return new BadRequestObjectResult(new { message = "User or Password Incorrect", currentDate = DateTime.Now });
            
            return Ok(_mapper.Map<AdminReadDTO>(user));
        }

        [HttpPost]
        [Route("api/v1/login/hospital")]
        public ActionResult<HEmployeeReadDTO> HEmployeeLogin([FromBody] UserLoginDTO userDTO)
        {
            var user = _repository.GetHEmployee(userDTO.Username);
            if(user == null)
                return new BadRequestObjectResult(new { message = "User Not Found", currentDate = DateTime.Now });
            
            if(user.Password!=userDTO.Password)
                return new BadRequestObjectResult(new { message = "User or Password Incorrect", currentDate = DateTime.Now });
            
            return Ok(_mapper.Map<HEmployeeReadDTO>(user));
        }
    }
}