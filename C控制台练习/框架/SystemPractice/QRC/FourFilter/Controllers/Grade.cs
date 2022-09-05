using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourFilter.Controllers
{
    public class Grade
    {
        /// <summary>
        ///ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///班级名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 班级位置
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 班级口号
        /// </summary>
        public string Mes { get; set; }

        /// <summary>
        /// 是否删除（1删除 0未删除）
        /// </summary>
        public bool IsDel { get; set; }
    }
}