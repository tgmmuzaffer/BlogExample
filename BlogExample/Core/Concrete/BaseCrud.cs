using Core.Abstract;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Core.Concrete
{
    public class BaseCrud : IBaseCrud
    {
        //burada veritabanı bağlantısı sağlanacağından -core katmanında olduğunu varsayarsak- alt sınıfın üst sınıfa referans vermesi c# da mümükün değildir.bu yüzden data katmanında
        private readonly IConfiguration _conf;
        private string Connectionstring = "DefaultConnection";
        public BaseCrud(IConfiguration conf)
        {
            _conf = conf;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_conf.GetConnectionString(Connectionstring)))
            {
                return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            };
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_conf.GetConnectionString(Connectionstring)))
            {
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            };
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_conf.GetConnectionString(Connectionstring));
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection db = new SqlConnection(_conf.GetConnectionString(Connectionstring)))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
                return result;
            };
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using (IDbConnection db = new SqlConnection(_conf.GetConnectionString(Connectionstring)))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
                return result;
            };
        }
    }
}
