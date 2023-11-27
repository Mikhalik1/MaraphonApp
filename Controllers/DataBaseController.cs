using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaraphonApp.Controllers
{
    public class DataBaseController
    {
        /// <summary>
        /// Проверка подключения к БД
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        /// <returns>
        /// bool
        /// </returns>
        public async Task<bool> DataBaseConnect(string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.ConnectionString = connectionString;
                    await sqlConnection.OpenAsync();
                    return true;
                }
                catch
                {
                    sqlConnection.Close();
                    return false;
                }
                finally
                {
                    // если подключение открыто
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                }
            }
        }

    }
}
