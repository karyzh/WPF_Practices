using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenaris.Tamsa.View.Reports.Model.Models;

namespace Tenaris.Tamsa.View.Reports.Model.DataAccess
{
    public class DataAccess
    {
        private readonly string _conexion;

        private SqlConnection CN;
        private SqlCommand CMD;
        private SqlDataReader RDR;
        private SqlTransaction TR;
        

        public string Conexion { get { return _conexion; } }

        
        public DataAccess()
        {
            _conexion = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            /*ConfigurationManager.ConnectionStrings["connection"].ConnectionString;*/
            Console.WriteLine();
        }

        //OBTENER O CARGAR TUBOS
        public List<Pipe> getPipes()
        {
            //string sp = "[TenarisPipes].[dbo].[sp_insertpipes]";
            List<Pipe> result = new List<Pipe>();
            using (SqlConnection cn = new SqlConnection(Conexion))
            {

                using (SqlCommand cmd = new SqlCommand("[TenarisPipes].[dbo].[sp_getpipes]", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();

                            string formatStringInformationPipe = "Pipe({0}) have ({1}), work_order ({2}, created date ({3}) and Update date ({4}))";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(formatStringInformationPipe, reader["ID"], reader["Heat"], reader["WO"], reader["CreateDate"], reader["UpdateDate"]);
                            result.Add(new Pipe()
                            {
                                id = Convert.ToInt32(reader["ID"].ToString()),
                                heat = Convert.ToInt32(reader["Heat"].ToString()),
                                wo = Convert.ToInt32(reader["WO"].ToString()),
                                //CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString()),
                                //UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString()),

                            });
                        }
                    }

                    //cmd.Parameters.AddWithValue("@ID", pipe.Id);
                    //cmd.Parameters.AddWithValue("@Heat", pipe.Heat);
                    //cmd.Parameters.AddWithValue("@WO", pipe.WO);
                    //cmd.Parameters.AddWithValue("@CreateDate", pipe.CreateDate);
                    //cmd.Parameters.AddWithValue("@UpdateDate", pipe.UpdateDate);

                    cmd.ExecuteNonQuery();
                    //cmd.Parameters.Clear();
                    cn.Close();
                }
            }
            Console.WriteLine("Esto es lo capturado de la base de datos -> ", result);
            return result;

        }

        //INSERTAR TUBOS
        

    }
}

