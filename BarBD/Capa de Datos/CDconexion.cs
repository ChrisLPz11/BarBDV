using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace Capa_de_Datos
{
    class CDconexion
    {
        public SqlConnection Conexion = new SqlConnection("Server=DESKTOP-J88HH7S\\MSSQLSERVER02;DataBase= BarDb;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

    }
}
