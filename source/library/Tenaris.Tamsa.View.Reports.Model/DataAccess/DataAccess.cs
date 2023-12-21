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

                }
            }
            catch (Exception ex)
            {
                log.Info($"Error al obtener datos de la base de datos");
                log.Error(ex);

            }
            return lstResults;

        }

        public void Clear()  //Método para eliminar los registros de la tabla
        {
            string query = "[TenarisPipes].[dbo].[sp_deleteall]";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(@query, cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                log.Info($"Error al insertar los tubos");
                log.Error(ex);
            }
        }


        //Insertar tubos
        public List<Pipe> insertPipes(List<Pipe> lstPipe)
        {

            string query = "[TenarisPipes].[dbo].[sp_insertpipes]";
            try
            {

                using (SqlConnection cn = new SqlConnection(Conexion))
                {
                    cn.Open();
                    Clear(); //Se manda a llamar
                    SqlCommand cmd = new SqlCommand(@query, cn)
                    {

                        CommandType = CommandType.StoredProcedure
                    };

                    foreach (Pipe pipe in lstPipe)
                    {

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ID", pipe.id);
                        cmd.Parameters.AddWithValue("@Heat", pipe.heat);
                        cmd.Parameters.AddWithValue("@WO", pipe.wo);
                        //cmd.Parameters.AddWithValue("@CreateDate", pipe.CreateDate);
                        //cmd.Parameters.AddWithValue("@UpdateDate", pipe.UpdateDate);
                        cmd.ExecuteNonQuery();
                        log.Info($"Executed SP {query}: {pipe}");
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                log.Info($"Error al insertar los tubos");
                log.Error(ex);
            }
            return getPipes();
        }



        public void updatePipe(Pipe updPipe)
        {
            string query = "[TenarisPipes].[dbo].[sp_updatepipe]";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(query, cn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@ID", updPipe.id);
                    cmd.Parameters.AddWithValue("@Heat", updPipe.heat);
                    cmd.Parameters.AddWithValue("@WO", updPipe.wo);
                

                    log.Info($"Executed SP {query}: {updPipe}");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
            catch (Exception ex)
            {
                log.Info($"Error al actualizar el tubo");
                log.Error(ex);

            }
        }

        //Eliminar tubo
        public void deletePipe(Pipe dltPipe)
        {

            string query = "[TenarisPipes].[dbo].[sp_deletepipe]";
            try
            {

                using (SqlConnection cn = new SqlConnection(Conexion))
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand(@query, cn)
                    {

                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@ID", dltPipe.id);
                   
                    log.Info($"Executed SP {query}: {dltPipe}");
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                log.Info($"Error al borrar los tubos");
                log.Error(ex);
            }

        }

    }
}





//ACTUALIZAR TUBOS
// public void updatePipes(List<Pipe> updPipe)
// public List<Pipe> updatePipes(List<Pipe> updPipe) 
//{
//    string query = "[TenarisPipes].[dbo].[sp_updatepipe]";
//    try
//    {

//        using (SqlConnection cn = new SqlConnection(Conexion))
//        {
//            cn.Open();
//            SqlCommand cmd = new SqlCommand(@query, cn)
//            {

//                CommandType = CommandType.StoredProcedure
//            };
//            foreach (Pipe pipe in updPipe)
//            {
//                cmd.Parameters.Clear();
//                cmd.Parameters.AddWithValue("@ID", pipe.id);
//                //cmd.Parameters.AddWithValue("@Heat", pipe.heat);
//                //cmd.Parameters.AddWithValue("@WO", pipe.wo);
//                //cmd.Parameters.AddWithValue("@CreateDate", pipe.CreateDate);
//                //cmd.Parameters.AddWithValue("@UpdateDate", pipe.UpdateDate);
//                log.Info($"Executed SP {query}: {pipe}");

//                cmd.ExecuteNonQuery();

//            Console.WriteLine(pipe);

//            }
//            cn.Close();
//        }


//    }
//    catch (Exception ex)
//    {
//        log.Info($"Error al actualizar el tubo");
//        log.Error(ex);
//    }
//    return getPipes();



//}