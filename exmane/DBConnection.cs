using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;




namespace exmane
{
    class DBConnection
    {
        public static string StringConnect = @"Database=pp; Data Source=localhost; user=root;  password=qwerty; ";
        public static MySqlCommand MyCommand;
        public static MySqlConnection MyConnect;
        public static MySqlDataAdapter MSAdapter = new MySqlDataAdapter();
        static public string fio;
        static public DataTable dtWork = new DataTable();
              static public DataTable dtProp = new DataTable();

        public static bool Connection()
        {
            try
            {
                MyConnect = new MySqlConnection(StringConnect);
                MyCommand = new MySqlCommand();
                MyCommand.Connection = MyConnect;
                MyConnect.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("Базы данных не сущетсвует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        static public void Close()
        {
            try
            {
                MyConnect.Close();
            }
            catch
            {
            }

        }

        static public void Auth(String login, String password)
        {
            String Sql = $@"SELECT FIO FROM workers WHERE login='{login}' and password ='{password}'";
            MyCommand.CommandText = Sql;
            Object result = MyCommand.ExecuteScalar();
            if (result != null)
            {
                fio = result.ToString();
            }
            else
            {
                fio = null;
            }

        }

        static public void GetWorkers()
        {
           MyCommand.CommandText = @"SELECT * FROM workers,propusk where workers.propusk=propusk.propusk";
            MSAdapter = new MySqlDataAdapter(MyCommand);
            dtWork.Clear();
            MSAdapter.Fill(dtWork);
        }

        static public void GetPropusk()
        {
            MyCommand.CommandText = @"SELECT * FROM propusk";
            MSAdapter = new MySqlDataAdapter(MyCommand);
            dtProp.Clear();
            MSAdapter.Fill(dtProp);
        }

        static public bool DeleteWorkers(string kod)
        {
            MyCommand.CommandText = $"DELETE FROM workers WHERE ID_worker='{kod}';";
            if (MyCommand.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }

        static public bool AddWorkers(string fio, string login, string pass, string propid)
        {
            MyCommand.CommandText = $"INSERT INTO workers VALUES(NULL,'{fio}','{login}','{pass}','{propid}');";
            if (MyCommand.ExecuteNonQuery() > 0)
                return true;
            else
            return false;
        }

        static public bool ChangeWorkers(string id, string fio, string login, string pass, string propid)
        {
            MyCommand.CommandText = $"UPDATE workers SET fio='{fio}',login='{login}',password='{pass}',propusk='{propid}';";
            if (MyCommand.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }

    }
}
