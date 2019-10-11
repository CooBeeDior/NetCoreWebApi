using Microsoft.EntityFrameworkCore;
using NetCoreWebApi.Model.Models;

namespace NetCoreWebApi.Model
{
    public class MyDbContext:DbContext
    {
        public MyDbContext()
        {
        }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        //定义数据集合：用于创建表
        public DbSet<TbUser> TbUsers { get; set; }
    }
}
