using System;
using Microsoft.AspNetCore.Mvc;
using hywebapi.Models;
using Microsoft.Extensions.Logging;
using hywebapi.Filters;
using hywebapi.Repositories;

namespace hywebapi.Controllers
{

    [Route("api/[controller]")]
    public class UsersController :  Controller
    {
        private ILogger<UsersController> _logger;
        private readonly IUserRepository userRepository;

 
        public UsersController(ILogger<UsersController> logger,IUserRepository userRepo){
            _logger = logger;

            userRepository = userRepo;
        }

        

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = userRepository.GetAll();
            return new ObjectResult(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = userRepository.GetById(id);
            return new ObjectResult(user);
        }
        //[MyActionFilter]
        [HttpGet("{id}")]
        public IActionResult Get1(int id)
        {
             // 演示日志输出
            _logger.LogInformation("This is Information Log!");
            _logger.LogWarning("This is Warning Log!");
            _logger.LogError("This is Error Log!");

          
            var user = new User() { Id = id, Name = "Name:" + id, Sex = "Male" };
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user){
            if(user == null){
                return BadRequest();
            }

            // TODO：新增操作
            user.Id = new Random().Next(1, 10);
            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user){
            if(user == null){
                return BadRequest();
            }

            // TODO: 更新操作
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            // TODO: 删除操作
            
        }
    }
}