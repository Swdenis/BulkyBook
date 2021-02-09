using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using BulkyBook.DataAccess;
using Dapper;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class SP_Call : ISP_call
    {
        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }

        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (SQLiteConnection sqlCon = new SQLiteConnection(ConnectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SQLiteConnection sqlCon = new SQLiteConnection(ConnectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (SQLiteConnection sqlCon = new SQLiteConnection(ConnectionString))
            {
                sqlCon.Open();
                var value = sqlCon.Query(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (SQLiteConnection sqlCon = new SQLiteConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            using (SQLiteConnection sqlCon = new SQLiteConnection(ConnectionString))
            {
                sqlCon.Open();
                var result = SqlMapper.QueryMultiple(sqlCon, procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();
                sqlCon.Query(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);

                if(item1!=null && item2!=null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
