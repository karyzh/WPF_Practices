using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using log4net;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string Conexion { get { return _conexion; } }

        public DataAccess()
        {
            _conexion = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            /*ConfigurationManager.ConnectionStrings["connection"].ConnectionString;*/
        }

        //OBTENER O CARGAR TUBOS
        public List<Pipe> getPipes()
        {
            //string sp = "[TenarisPipes].[dbo].[sp_insertpipes]";
            List<Pipe> lstResults = new List<Pipe>();
            string query = "[TenarisPipes].[dbo].[sp_getpipes]";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(@query, cn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    //string formatStringInformationPipe = "Pipe({0}) have ({1}), work_order ({2}, created date ({3}) and Update date ({4}))";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //Console.WriteLine(formatStringInformationPipe, reader["ID"], reader["Heat"], reader["WO"], reader["CreateDate"], reader["UpdateDate"]);
                        lstResults.Add(new Pipe()
                        {
                            id = (int)reader["ID"],
                            heat = (int)reader["Heat"],
                            wo = (int)reader["WO"],
                            CreateDate = (DateTimeOffset)reader["CreateDate"],
                            UpdateDate = (DateTimeOffset)reader["UpdateDate"]
                        });
                    }
                    log.Info($"Executed SP {query}");
                    reader.Close();
                    cn.Close();


                    //cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@ID", pipe.Id);
                    //cmd.Parameters.AddWithValue("@Heat", pipe.Heat);
                    //cmd.Parameters.AddWithValue("@WO", pipe.WO);
                    //cmd.Parameters.AddWithValue("@CreateDate", pipe.CreateDate);
                    //cmd.Parameters.AddWithValue("@UpdateDate", pipe.UpdateDate);

                }
            }catch (Exception ex)
            {
                log.Info($"Error al obtener datos de la base de datos");
                log.Error(ex);
                
            }
            return lstResults;
            
        }

        //Insertar tubos
        
    }
        
}
            





