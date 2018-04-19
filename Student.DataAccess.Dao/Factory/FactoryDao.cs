using Student.Common.Logic.Enums;
using Student.Common.Logic.Models;
using Student.DataAccess.Dao.Dao;
using Student.DataAccess.Dao.DAO;
using Student.DataAccess.Dao.DaoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Factory
{
   
    public class FactoryDao<T> : IFactory<T> where T : IVuelingObject 
    {
        private readonly TypeFormat typeFormat ;
        public FactoryDao(TypeFormat type)
        {
            typeFormat = type;
        }

        public IDao<T> FactoryFormat()
        {
            switch (typeFormat)
            {
                case TypeFormat.txt:
                    return new StudentTxt<T>()  ;
                case TypeFormat.json:
                    return new StudentJson<T>() ;
                case TypeFormat.xml:
                    return new StudentXml<T>();
                case TypeFormat.sql:
                    return new StudentSql<T>();
                default:
                    return new StudentTxt<T>();
            }
        }
  
    }
}
