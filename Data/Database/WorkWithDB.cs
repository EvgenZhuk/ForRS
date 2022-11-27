using Npgsql;
using System.Data;

namespace ForRS.Data.Database
{
    public class WorkWithDB
    {
        public string _ConnectionString { get; set; }

        private NpgsqlConnection _myConnection;
        /// <summary>
        /// Метод OpenConnection устанавливает соединение с БД
        /// </summary>
        public void OpenConnection()
        {
            var cc = new ConfigurationConnect();
            _ConnectionString = $"Server={cc.Server};Port={cc.Port};User Id={cc.User_Id};Password={cc.Password};Database={cc.Database}";
            _myConnection = new NpgsqlConnection(_ConnectionString);
            _myConnection.Open();
        }
        /// <summary>
        /// Метод QuerySelect направляет SQL запрос типа SELECT
        /// для получения всех встреч
        /// </summary>
        /// <param name="query">Текстовое представление SQL запроса</param>
        /// <returns>Возвращает список встреч типа List</returns>
        public List<Meet> QuerySelect(string query)
        {
            var list = new List<Meet>();
            var cmd = new NpgsqlCommand(query, _myConnection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Meet meet = new Meet()
                {
                    Id = (int)reader["Id"],
                    Title = (string)reader["Title"],
                    StartMeet = (DateTime)reader["StartMeet"],
                    EndMeet = (DateTime)reader["EndMeet"],
                    Alert = (int)reader["Alert"]
                };
                list.Add(meet);
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Метод QuerySelectCheck  направляет SQL запрос типа SELECT
        /// для проверки пересечений с уже имеющимися встречами
        /// </summary>
        /// <param name="query">Текстовое представление SQL запроса</param>
        /// <returns>Возвращает количество записей удовлетворяющих запросу</returns>
        public int QuerySelectCheck(string query)
        {
            var cmd = new NpgsqlCommand(query, _myConnection);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            int numRows = dt.Rows.Count;

            return numRows;

        }
        /// <summary>
        /// Метод QueryOther выполняет переданные ей SQL инструкции
        /// </summary>
        /// <param name="query">SQL инструкция</param>
        public void QueryOther(string query)
        {
            var cmd = new NpgsqlCommand(query, _myConnection);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Метод CloseConnection закрывает соединение с БД
        /// </summary>
        public void CloseConnection()
        {
            _myConnection.Close();
        }
    }
}
