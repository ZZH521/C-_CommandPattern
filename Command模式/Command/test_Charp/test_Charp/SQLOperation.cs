using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace test_Charp
{
    public class SQLOperation
    {
        public static String connDB = null;
        private SqlConnection conn_ = null;
        private DataSet dataset_ = null;
                     
        public SQLOperation()
        {
            try
            {
                conn_ = new SqlConnection(PublicFunction.conString);
            } catch(Exception exp) {
                MessageBox.Show("错误信息: " + exp.Message);
            }
        }

        ~SQLOperation()
        {
            if (conn_ != null && conn_.State == ConnectionState.Open)
            {
                try
                {
                    conn_.Close();
                }
                catch(Exception ex){

                }

                try
                {
                    conn_.Dispose();
                }
                catch(Exception ex)
                {

                }
            }
        }
        
        public DataSet ExecQuery(String sql) 
        {
            if (dataset_ == null)
                dataset_ = new DataSet();
            else
                dataset_.Reset();
            try
            {
                SqlDataAdapter adpter = new SqlDataAdapter(sql, conn_);
                adpter.SelectCommand.CommandTimeout = 1;
                adpter.Fill(dataset_);
            } catch(Exception exp) {
                MessageBox.Show("错误信息: " + exp.Message);
            }

            return dataset_;
        }  

        public int ExecNoQuery(String sql)
        {
            int ret = 0;

            if(conn_.State == ConnectionState.Closed){
                conn_.Open();
            }
            SqlCommand comm = new SqlCommand(sql, conn_);
           
            ret = comm.ExecuteNonQuery();
            conn_.Close();
            return ret;
        }
    }
}
