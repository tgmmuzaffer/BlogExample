using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Businness.Abstract
{
    public interface IBaseCrud 
    {
        // Bu tarz merkezi işlemler normalde core katmanında olmalı. Bu sınıfın gerçeği başka bir assembly içerisinde olamayacağından core katmanında değil data katmanında yer alıyor. 
        DbConnection GetDbconnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        bool Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
       bool Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
      bool   Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    }
}
