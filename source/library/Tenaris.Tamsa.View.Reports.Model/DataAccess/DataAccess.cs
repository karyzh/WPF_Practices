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

        List<Pipe> lstPipes = new List<Pipe>();
        public DataAccess()
        {
            _conexion = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            /*ConfigurationManager.ConnectionStrings["connection"].ConnectionString;*/
            Console.WriteLine();
        }

        //OBTENER O CARGAR TUBOS
        public void CargarPipes()
        {
            //string sp = "[TenarisPipes].[dbo].[sp_insertpipes]";

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("[TenarisPipes].[dbo].[sp_getpipes]", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();
                        while(sqlDataReader.Read())
                        {
                            string formatStringInformationPipe = "Pipe({0}) have ({1}), work_order ({2}, created date ({3}) and Update date ({4}))";
                            Console.WriteLine(formatStringInformationPipe ,sqlDataReader["ID"], sqlDataReader["Heat"], sqlDataReader["WO"], sqlDataReader["CreateDate"], sqlDataReader["UpdateDate"]);
                        }

                        sqlDataReader.Close();
                        //cmd.Parameters.AddWithValue("@ID", pipe.Id);
                        //cmd.Parameters.AddWithValue("@Heat", pipe.Heat);
                        //cmd.Parameters.AddWithValue("@WO", pipe.WO);
                        //cmd.Parameters.AddWithValue("@CreateDate", pipe.CreateDate);
                        //cmd.Parameters.AddWithValue("@UpdateDate", pipe.UpdateDate);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine(lstPipes);
            }
        }

        //INSERTAR TUBOS
        public void InsertarPipes()
        {
            //string sp = "[TenarisPipes].[dbo].[sp_insertpipes]";

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("[TenarisPipes].[dbo].[sp_insertpipes]", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            string formatStringInformationPipe = "Pipe({0}) have ({1}), work_order ({2}, created date ({3}) and Update date ({4}))";
                            Console.WriteLine(formatStringInformationPipe, sqlDataReader["ID"], sqlDataReader["Heat"], sqlDataReader["WO"], sqlDataReader["CreateDate"], sqlDataReader["UpdateDate"]);
                        }

                        sqlDataReader.Close();
                        //cmd.Parameters.AddWithValue("@ID", pipe.Id);
                        //cmd.Parameters.AddWithValue("@Heat", pipe.Heat);
                        //cmd.Parameters.AddWithValue("@WO", pipe.WO);
                        //cmd.Parameters.AddWithValue("@CreateDate", pipe.CreateDate);
                        //cmd.Parameters.AddWithValue("@UpdateDate", pipe.UpdateDate);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine(lstPipes);
            }
        }

    }
}

