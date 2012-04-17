using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Data;
using System.Data.Odbc;
using Exceptions;
using System.Data.SqlClient;


namespace Genericas
{
    public class GenericaDAO
    {
        private SqlConnection connection;

        private static GenericaDAO genericaDAO;
        //public OdbcConnection objCon;

        private string Caminho = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
   
     
        public static GenericaDAO getInstancia(string connectionString = null)
        {
            if (connectionString != null)
            {
                genericaDAO = new GenericaDAO(connectionString);
            }
            else
            {
                if (genericaDAO == null)
                {
                    genericaDAO = new GenericaDAO(null);
                }
            }
            return genericaDAO;
        }



        private GenericaDAO(string connectionString)
        {
            try
            {
                connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"E:\\bck\\RasControl.mdf\";Integrated Security=True;User Instance=True;";
                //connectionString = "driver=MySQL ODBC 5.1 Driver;server=localhost;uid=root;pwd=;_database=bdrascontrol";
                if (connectionString == null)
                {
                    connection = new SqlConnection(@"Driver={MySQL ODBC 5.1 Driver};Server=localhost;Database=bdrascontrol;User=root;Password=;Option=3;");

                }
                else
                {
                    connection = new SqlConnection(connectionString);
                }

            }
            catch (Exception)
            {
                throw new Exception("Houve um problema ao instanciar ou acessar uma conexão!");
            }

        }

        public void ClearConnection()
        {
            try
            {                
                genericaDAO = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void OpenConnection()
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                    this.connection = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader ExecuteReader(CommandType cmd, string sql)
        {
            SqlCommand command;

            try
            {
                OpenConnection();
                command = new SqlCommand(sql.ToLower(), connection);
                command.CommandType = cmd;
                return command.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public int ExecuteNonQuery(CommandType cmd, string sql)
        {            
            
           SqlCommand command;      

            try
            {
                OpenConnection();
            
                command = new SqlCommand(sql.ToLower(), connection);    
                command.CommandType = CommandType.Text;

                int res = command.ExecuteNonQuery();
              
                return res;
            }
            catch (Exception ex)
            {               
                throw ex;
            }           
        }


        public DataSet ExecuteReaderDs(CommandType cmd, string sql)
        {
            SqlDataAdapter command;
            DataSet ds = new DataSet();

            try
            {
                OpenConnection();
                command = new SqlDataAdapter(sql.ToLower(), connection);
                command.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public SqlDataAdapter ExecuteReaderDa(CommandType cmd, string sql)
        {
            SqlCommand cm;
            SqlDataAdapter da;

            try
            {
                OpenConnection();
                cm = new SqlCommand(sql.ToLower());
                da = new SqlDataAdapter(cm);

                cm.Connection = this.connection ;
                da.SelectCommand = cm;

                return da;
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
    }
}
