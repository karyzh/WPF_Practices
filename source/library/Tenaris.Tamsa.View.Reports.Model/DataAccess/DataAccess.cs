using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenaris.Tamsa.View.Reports.Model.Models;

namespace Tenaris.Tamsa.View.Reports.Model.DataAccess
{
    public class DataAccess
    {
        private readonly string _conexion;

        public string Conexion { get { return _conexion; } }

        public DataAccess()
        {
            _conexion = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
                /*ConfigurationManager.ConnectionStrings["connection"].ConnectionString;*/
        }

        public List<Pipe> CargarPipes()
        {
            List<Pipe> pipes = new List<Pipe>();
            string query = "[TenarisPipes].[dbo.InformationPipes].[insertpipes]";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(query, cn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        pipes.Add(new Pipe
                        {
                            Id = (int)reader["Id"],
                            Heat = (string)reader["Heat"],
                            WO = (string)reader["WO"],
                            CreateDate = (DateTimeOffset)reader["CreateDate"],
                            UpdateDate = (DateTimeOffset)reader["UpdateDate"]
                        });
                    }
                    reader.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return pipes;
        }
    }
}

