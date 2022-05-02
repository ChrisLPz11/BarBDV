using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Capa_de_Datos
{
   public class CDproductos
    {
        private CDconexion conexion = new CDconexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void insertar(string nombre, string descrip, double precio, int cantidad, int estado)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", descrip);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        public void actualizar(string nombre, string descrip, double precio, int cantidad, int estado, int idproducto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", descrip);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@idproducto", idproducto);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        public void Borrar( int idproducto)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idproducto", idproducto);

            comando.BeginExecuteNonQuery();

            comando.Parameters.Clear();

        }




        
    }
}
   
