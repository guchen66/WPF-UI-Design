/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample2.Db
{
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;
        public LocalDataAccess()
        {

        }
        *//*public LocalDataAccess(SqlDataAdapter sqlDataAdapter,SqlCommand sqlCommand,SqlConnection sqlConnection)
        {
            adapter = sqlDataAdapter;
            conn = sqlConnection;
            cmd=sqlCommand;
        }*//*
        public static LocalDataAccess GetInstance()
        {
            //不为空返回左边，为空返回右边
            return instance ??= new LocalDataAccess();
        }



       *//* SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;//适配器，连接数据集和数据源*//*
        private void Dispose()
        {

            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }

            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
            //conn?.Close(); conn?.Dispose();conn = null;
            // cmd?.Dispose();cmd = null;

        }

        private bool DBConnection()
        {

            //访问config文件
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            //string connStr = ConfigurationHelper.init();
            if (conn == null)
            {
                conn = new SqlConnection(connStr);
            }
            try
            {
                conn.Open();
                return true;
            }
            catch
            {

                return false;
            }
            //return true;
        }

        public UserInfo CheckUserInfo(string username, string pwd)
        {
            try
            {
                if (DBConnection())
                {
                    string userSql = "select * from users where user_name=@user_name and password=@pwd and is_vertifycode=1";
                    adapter = new SqlDataAdapter(userSql, conn);
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@user_name", SqlDbType.VarChar)
                    { Value = username });
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pwd", SqlDbType.VarChar)
                    { Value = pwd });
                    //{ Value = MD5Provider.GetMD5String(pwd + "@" + username) });//使用MD5加密


                    *//*string userSql = "select *from users where user_name=@user_name and password=@pwd and is_vertifycode=1";
                    SqlDataAdapter adapter = new SqlDataAdapter(userSql, conn);

                    DataSet customers = new DataSet();
                    adapter.Fill(customers, "users");*//*

                    DataTable table = new DataTable();
                    int count = adapter.Fill(table);
                    if (count <= 0)
                        throw new Exception("用户名和密码不正确");

                    DataRow row = table.Rows[0];
                    if (row.Field<Int32>("is_can_login") == 0)
                        throw new Exception("当前用户没有权限访问");


                    UserInfo userInfo = new UserInfo();
                    //userInfo.Id = row.Field<int>("user_id");
                    if (userInfo is not null)
                    {
                        userInfo.UserName = row.Field<string>("user_name");
                        userInfo.RealName = row.Field<string>("real_name");
                        userInfo.Age = row.Field<Int32>("age");
                        userInfo.Password = row.Field<string>("password");
                    }


                    return userInfo;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                this.Dispose();
            }
            return null;



        }
    }
}
*/