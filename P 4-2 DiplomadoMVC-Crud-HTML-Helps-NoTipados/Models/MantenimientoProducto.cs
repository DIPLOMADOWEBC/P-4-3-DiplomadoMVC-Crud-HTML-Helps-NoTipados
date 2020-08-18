using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace P_4_2_DiplomadoMVC_Crud_HTML_Helps_NoTipados.Models
{
    public class MantenimientoProducto
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            con = new SqlConnection(constr);

        }

        public int Agregar(Productos prod)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Productos(Descripcion, Tipo, Precio) values (@descripcion,@tipo,@precio)", con);
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@tipo", SqlDbType.VarChar);
            comando.Parameters.Add("@precio", SqlDbType.Float);
            comando.Parameters["@descripcion"].Value = prod.Descripcion;
            comando.Parameters["@tipo"].Value = prod.Tipo;
            comando.Parameters["@precio"].Value = prod.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Productos> RecuperarTodos()
        {
            Conectar();
            List<Productos> productos = new List<Productos>();

            SqlCommand com = new SqlCommand("select Id,Descripcion,Tipo,Precio from Productos", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while(registros.Read())
            {
                Productos prod = new Productos
                {
                    Id = int.Parse(registros["Id"].ToString()),
                    Descripcion = registros["Descripcion"].ToString(),
                    Tipo = registros["Tipo"].ToString(),
                    Precio = float.Parse(registros["Precio"].ToString())
                };
                productos.Add(prod);
            }
            con.Close();
            return productos;
        }

        public Productos Recuperar(int Id)
        {
            Conectar();
            SqlCommand com = new SqlCommand("select Id,Descripcion,Tipo,Precio from Productos where Id=@Id", con);
            com.Parameters.Add("@Id", SqlDbType.Int);
            com.Parameters["@Id"].Value = Id;
            con.Open();

            SqlDataReader registros = com.ExecuteReader();
            Productos producto = new Productos();
            if (registros.Read())
            {
                producto.Id = int.Parse(registros["Id"].ToString());
                producto.Descripcion = registros["Descripcion"].ToString();
                producto.Tipo = registros["Tipo"].ToString();
                producto.Precio = float.Parse(registros["Precio"].ToString());
            }
            else
                producto = null;
            con.Close();
            return producto;
        }
        public int Modificar(Productos prod)
        {
            Conectar();
            SqlCommand com = new SqlCommand("update Productos set descripcion=@descripcion, tipo=@tipo, precio=@precio where id=@id", con);
            com.Parameters.Add("@descripcion", SqlDbType.VarChar);
            com.Parameters["@descripcion"].Value = prod.Descripcion;
            com.Parameters.Add("@tipo", SqlDbType.VarChar);
            com.Parameters["@tipo"].Value = prod.Tipo;
            com.Parameters.Add("@precio", SqlDbType.Float);
            com.Parameters["@precio"].Value = prod.Precio;
            com.Parameters.Add("@id", SqlDbType.Int);
            com.Parameters["@id"].Value = prod.Id;
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(int id)
        {
            Conectar();
            SqlCommand com = new SqlCommand("delete form Productos where id=@id", con);
            com.Parameters.Add("@id", SqlDbType.Int);
            com.Parameters["@id"].Value = id;
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}