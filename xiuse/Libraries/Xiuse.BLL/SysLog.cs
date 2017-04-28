///增加操作日志（数据库表）
/// 增加相应的函数和查询的接口
///LogId（日志Id）、UserId（用户ID）、日志内容、日志类型、日志时间
///

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Xiuse.BLL
{
    class SysLog
    {
        private readonly Xiuse.DAL.SysLog dal = new Xiuse.DAL.SysLog();
        public SysLog() { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model">对象实体</param>
        public bool Insert(Xiuse.Model.SysLog model)
        {
            return dal.Insert(model);
        }
        /// <summary>
        /// 通过id查询日志信息
        /// </summary>

        public Xiuse.Model.SysLog GetData(string Id)
        {
            return dal.GetModel(Id);
        }

    }
}