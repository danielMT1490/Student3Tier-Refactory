using Student.DataAccess.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.DaoInterfaces
{
    public interface IRepository<T> : IDelete<T>,ISelect<T>,IRead<T>,ICreate<T>,IUpdate<T> where T : Common.Logic.Models.IVuelingObject
    {
    }
}
