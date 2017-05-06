using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace Data.Helper
{
    public static class SqlHelper
    {
        public static string ConnectionString(string connectionString)
        {
            return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }

        /// <summary>
        /// General Method to Insert one record and retrieve ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="type"></param>
        /// <returns>Identity(integer)</returns>
        public static int AddObject<T>(string query, DynamicParameters parameters,string connectionString, CommandType type = CommandType.Text)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString(connectionString)))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    return db.Query<int>(query, parameters, commandType: type).Single();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// General Menthod to retrieve objects. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetObjects<T>(string query, string connectionString, DynamicParameters parameters = null, CommandType type = CommandType.Text)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString(connectionString)))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    if (parameters != null)
                        return (List<T>)db.Query<T>(query, parameters, commandType: type);
                    return (List<T>)db.Query<T>(query, commandType: type);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// General method for executing NonQuery
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="type"></param>
        /// <param name="usingTrans"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string query, ref DynamicParameters parameters, string connectionString, CommandType type = CommandType.Text, bool usingTrans = false)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString(connectionString)))
                {
                    IDbTransaction trans = null;

                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    if (usingTrans)
                        trans = db.BeginTransaction();

                    db.Execute(query, parameters, trans, commandType: type);

                    if (usingTrans)
                        trans.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool ExecuteNonQuery<T>(string query, DynamicParameters parameters, string connectionString, CommandType type = CommandType.Text, bool usingTrans = false)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString(connectionString)))
                {
                    IDbTransaction trans = null;

                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    if (usingTrans)
                        trans = db.BeginTransaction();

                    db.Execute(query, parameters, trans, commandType: type);

                    if (usingTrans)
                        trans.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// General method for executing scalar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string query, DynamicParameters parameters, string connectionString, CommandType type = CommandType.Text, bool usingTrans = false)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString(connectionString)))
                {
                    IDbTransaction trans = null;

                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    if (usingTrans)
                        trans = db.BeginTransaction();

                    var returnedObject = db.ExecuteScalar(query, parameters, trans, commandType: type);

                    if (usingTrans)
                        trans.Commit();

                    return returnedObject;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static IDbConnection db_batch;
        private static IDbTransaction trans_batch;
        public static bool BatchExecuteNonQuery<T>(string query, DynamicParameters parameters,string connectionString, CommandType type = CommandType.Text, bool isFinished = true)
        {
            try
            {
                db_batch = db_batch ?? new SqlConnection(ConnectionString(connectionString));

                if (db_batch.State == ConnectionState.Closed)
                    db_batch.Open();

                //trans_batch = trans_batch ?? db_batch.BeginTransaction();

                db_batch.Execute(query, parameters, trans_batch, commandType: type);

                //if (isFinished)
                //    trans_batch.Commit();

            }
            catch (Exception ex)
            {
                trans_batch = null;
                db_batch = null;
                throw ex;
            }
            return true;
        }

    }
}
