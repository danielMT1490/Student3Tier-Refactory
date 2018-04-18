﻿using Student.Common.Logic.Models;
using Student.DataAccess.Dao.Dao;
using Student.DataAccess.Dao.DaoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.DAO
{
    public class StudentSPSql<T> : IDao<T>, ICrud<T> where T : IVuelingObject
    {
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public T SelectByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
