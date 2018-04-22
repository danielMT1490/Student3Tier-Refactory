using Student.Common.Logic.Enums;
using Student.Common.Logic.Models;
using Student.DataAccess.Dao.DaoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Factory
{
    public interface IFactory<T> where T  :IVuelingObject 
    {
        IRepository<T> FactoryFormat();
    }
}
