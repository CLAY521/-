using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper
{
    public class Student
    {
        /// <summary>
        ///ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 班级Id
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// 是否删除（1删除 0未删除）
        /// </summary>
        public bool IsDel { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Photo { get; set; }
        public Grade GradeEntity { get; set; }
    }
}
