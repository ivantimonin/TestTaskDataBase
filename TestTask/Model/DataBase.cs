using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestTask.Model
{
    public static class DataBase
    {
        /// <summary>
        /// Метод обработки запроса в БД
        /// </summary>        
        public static DataTable Select(string selectSQL) // функция  обработка запросов
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;//достаем строку подключения из config
            SqlConnection sqlConnection = new SqlConnection(connectionString); // подключаемся к базе данных
            try
            {

                DataTable dataTable = new DataTable("dataTable");// создаём таблицу в приложении

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();// открываем базу данных  
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
                    sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
                    sqlDataAdapter.Fill(dataTable);                                  // возращаем таблицу с результатом             
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlConnection.Close();
            }
            return null;
        }
    }
}
