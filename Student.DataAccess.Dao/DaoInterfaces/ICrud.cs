using Student.Common.Logic.Models;
using Student.DataAccess.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.DaoInterfaces
{
    public interface ICrud<T> : ICreate<T>, IRead<T>, ISelect<T>, IUpdate<T>, IDelete<T> where T : IVuelingObject
    {
    }
}
