using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Capa_de_Datos;
namespace Capa_Negocio
{
   public  class CNproducto
    {
        private CDproductos objectoCD = new CDproductos();

        public DataTable leerProd()
        {
            DataTable table = new DataTable();
            table = objectoCD.Mostrar();
            return table;
        }
        public void InsProd(string nomprod, string desc, string precio,string cantidad,string estado)
        {

            objectoCD.insertar(nomprod, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad),
                Convert.ToInt32(estado));
         }
        public void ActProd(string nomprod, string desc, string precio, string cantidad, string estado, string idprod)
        {
            objectoCD.actualizar (nomprod, desc, Convert.ToDouble(precio), Convert.ToInt32(cantidad),
                Convert.ToInt32(estado),Convert.ToInt32(idprod));
        }
        public void EliProd(string idproducto)
        {
            objectoCD.Borrar(Convert.ToInt32(idproducto));

        }
    }
}

