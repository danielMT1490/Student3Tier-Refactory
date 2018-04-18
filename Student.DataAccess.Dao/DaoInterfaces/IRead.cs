using Student.Common.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Dao
{
    public interface IRead<T> where T : IVuelingObject
    {
        List<T> ReadAll();
    }
}
