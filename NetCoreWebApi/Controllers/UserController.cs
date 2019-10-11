using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Model;
using NetCoreWebApi.Model.Models;

namespace NetCoreWebApi.Controllers
{
    /// <summary>
    /// 用户模块
    /// </summary>
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 构造函数注入上下文
        /// </summary>
        private readonly MyDbContext _myDbContext;
        public UserController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        [Route("createUser")]
        [HttpPost]
        public TbUser CreateUser(TbUser dto)
        {
            _myDbContext.TbUsers.Add(dto);
            _myDbContext.SaveChanges();
            return dto;
        }
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <returns></returns>
        [Route("getUser")]
        [HttpGet]
        public List<TbUser> GetUser()
        {
            return _myDbContext.TbUsers.ToList();
        }

    }
}
