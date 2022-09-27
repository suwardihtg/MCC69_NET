using API.Context;
using API.Models;
using API.Repositories.Data;
using API.Services;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository UserRepository;
        private readonly IConfiguration iconfiguration;

        public UserController(UserRepository userRepository, IConfiguration configuration)
        {
            this.UserRepository = userRepository;
            this.iconfiguration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = 200, data = UserRepository.Get() });
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(Register input)
        {
            /*if (string.IsNullOrWhiteSpace(user.UserName) && string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                int result = UserRepository.Post(user);
                if (result > 0)
                    return Ok(new { result = 200, message = "data entry Succes" });
            }
            return BadRequest();*/

            if (string.IsNullOrWhiteSpace(input.Email) || 
                string.IsNullOrWhiteSpace(input.FirstName) || 
                string.IsNullOrWhiteSpace(input.LastName) ||
                string.IsNullOrWhiteSpace(input.PhoneNumber) ||
                string.IsNullOrWhiteSpace(input.Salary.ToString()) ||
                string.IsNullOrWhiteSpace(input.Username) ||
                string.IsNullOrWhiteSpace(input.Password))
            {
                return BadRequest();
            }
            var checkEmail = UserRepository.GetEmployee(input.Email);
            if (checkEmail != null)
            {
                return BadRequest(new { message = "user with the same email already exists!" });
            }
            var check = UserRepository.GetByName(input.Username);
            if (check != null)
            {
                return BadRequest(new { message = "user with the same username already exists!" });
            }
            int result = UserRepository.Post(input);
            if (result > 0)
                return Ok(new { status = 200, message = "successfully registered!" });
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login )
        {
            if (string.IsNullOrWhiteSpace(login.Email) && string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest();
            }
            //var check = UserRepository.GetEmployee(login.Email);
            var data = UserRepository.Login(login.Email, login.Password);
            if(data == null)
            {
                return NotFound();
            }
            // return Ok(new { result = 200, message = "successfully Login" });
            var jwt = new JwtServices(iconfiguration);
            string FullName = data.Employees.FirstName + " " + data.Employees.LastName;
            string role = UserRepository.GetRoleById(data.Id);
            var token = jwt.GenerateSecurityToken(data.Employees.Email, FullName, role);
            return Ok(new { status = 200, message = "login successful!", token = token, data = new { Id = data.Id, Email = data.Employees.Email, Name = FullName, Role = role } });
        }
        [HttpPut]
        [Route("Update")]

        public IActionResult Put(int id, User user)
        {
           
            var result = UserRepository.Put(user);
            if(result > 0)
            {
                return Ok(new { result = 200, message = "successfully Updated" });
            }
            return BadRequest();
        }

        [HttpPut("Change-Password")]
        public IActionResult ChangePassword(Change_Password input)
        {/*
            if (string.IsNullOrWhiteSpace(id.ToString()) && string.IsNullOrWhiteSpace(user.Password.ToString()))
            {
                return BadRequest();
            }
            int result = UserRepository.ChangePassword(id, user.Password);
            if (result > 0)
                return Ok(new { status = 200, message = "password-change successful!" });
            return BadRequest();*/
            if (string.IsNullOrWhiteSpace(input.Email) ||
                string.IsNullOrWhiteSpace(input.OldPassword) ||
                string.IsNullOrWhiteSpace(input.NewPassword))
            {
                return BadRequest();
            }
            var check = UserRepository.GetUserByEmail(input.Email);
            if (check == null)
            {
                return NotFound();
            }
            int result = UserRepository.ChangePassword(input.Email, input.OldPassword, input.NewPassword);
            if (result > 0)
                return Ok(new { status = 200, message = "password-change successful!" });
            return BadRequest();
        }

        [HttpPut("Forgot-Password")]
        public IActionResult ForgotPassword(Forget_Password input)
        {
            /*if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(user.Password))
            {
                return BadRequest();
            }
            int result = UserRepository.ForgetPassword(username, user.Password);
            if (result > 0)
                return Ok(new { status = 200, message = "password-change successful!" });
            return BadRequest();*/
            if (string.IsNullOrWhiteSpace(input.Email) && string.IsNullOrWhiteSpace(input.NewPassword))
            {
                return BadRequest();
            }
            var check = UserRepository.GetUserByEmail(input.Email);
            if (check == null)
            {
                return NotFound();
            }
            int result = UserRepository.ForgetPassword(input.Email, input.NewPassword);
            if (result > 0)
                return Ok(new { status = 200, message = "password-change successful!" });
            return BadRequest();
        }


    }
}
