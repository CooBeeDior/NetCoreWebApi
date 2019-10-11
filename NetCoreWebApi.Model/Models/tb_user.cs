using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreWebApi.Model.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("tb_User")]
    public class TbUser
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Key]
        [Column("userId")]
        [StringLength(32)]
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("userName")]
        [StringLength(20)]
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Column("email")]
        [StringLength(30)]
        public string Email { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("createTime")]
        public DateTime CreateTime { get; set; }
    }
}
