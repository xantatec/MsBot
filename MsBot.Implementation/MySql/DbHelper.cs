using MySql.Data.MySqlClient;

namespace MsBot.Implementation.MySql
{
    public class DbHelper
    {
        private static DbHelper _instance;

        private DbHelper()
        {
        }

        /// <summary>
        /// 实例
        /// </summary>
        public static DbHelper Instance => _instance ??= new DbHelper();

        public MySqlConnection GetConnection(string connString)
        { 
            return new MySqlConnection(connString);
        }
    }
}