using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace Tenaris.Tamsa.View.ViewModel
{
    public class DataAccess2
    {
        string cadenaConexion = "Data Source=TENARIS;Initial Catalog=TenarisPipes;Integrated Security=True";

        //private SqlConnection CN;
        //private SqlCommand CMD;
        //private SqlDataReader RDR;

        //private SqlTransaction TR;


        //public int GuardarNuevoTubo()
        //{
        //        CN = new SqlConnection(cadenaConexion);
        //        CMD = new SqlCommand();
        //        CMD.Connection = CN;
        //        CMD.CommandType = CommandType.Text;

        //        CMD.CommandText = "INSERT INTO dbo.InformationPipes (ID, Heat, WO, CreateDate, UpdateDate)" +
        //            "VALUES (@id, @heat, @wo, SYSDATETIME(), SYSDATETIME());";
        //}
    }
}

    


