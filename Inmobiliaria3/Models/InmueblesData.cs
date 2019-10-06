using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class InmueblesData
    {
        public Object agregarInmueble(Inmueble inmueble) {
            SqlConnection conn = Conexion.getConnection();

            String sql = "INSERT INTO inmueble (direccion, ambientes, tipo, uso, precio, disponible, id_propietario) VALUES (@direccion, @ambientes, @tipo, @uso, @precio, @disponible, @id_propietario)";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@direccion", inmueble.Direccion);
            command.Parameters.AddWithValue("@ambientes", inmueble.Ambientes);
            command.Parameters.AddWithValue("@tipo", inmueble.Tipo);
            command.Parameters.AddWithValue("@uso", inmueble.Uso);
            command.Parameters.AddWithValue("@precio", inmueble.Precio);
            command.Parameters.AddWithValue("@disponible", inmueble.Disponible);
            command.Parameters.AddWithValue("@id_propietario", inmueble.Propietario.Id);

            conn.Open();

            var id = command.ExecuteScalar();

            conn.Close();

            return id;
        }

        public List<Inmueble> obtenerInmueblesDisponibles()
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM inmueble WHERE disponible = 1";

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Inmueble> inmuebles = new List<Inmueble>();

            while (reader.Read())
            {
                PropietarioData propietarioData = new PropietarioData();
                Propietario p = propietarioData.obtenerPropietario(Int32.Parse(reader["id_propietario"].ToString()));

                bool disponible = false;

                if (String.Equals(reader["disponible"].ToString(), "1"))
                {
                    disponible = true;
                }

                Inmueble i = new Inmueble
                {
                    Id = reader.GetInt32(0),
                    Direccion = reader["direccion"].ToString(),
                    Ambientes = Int32.Parse(reader["ambientes"].ToString()),
                    Tipo = reader["tipo"].ToString(),
                    Uso = reader["uso"].ToString(),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    Disponible = disponible,
                    Propietario = p,
                };

                inmuebles.Add(i);
            }

            conn.Close();

            return inmuebles;
        }

        public List<Inmueble> obtenerInmueblesDePropietario(int IdPropietario)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM inmueble WHERE id_propietario = "+IdPropietario;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Inmueble> inmuebles = new List<Inmueble>();

            while (reader.Read())
            {
                PropietarioData propietarioData = new PropietarioData();
                Propietario p = propietarioData.obtenerPropietario(Int32.Parse(reader["id_propietario"].ToString()));

                bool disponible = false;

                if (String.Equals(reader["disponible"].ToString(), "1"))
                {
                    disponible = true;
                }

                Inmueble i = new Inmueble
                {
                    Id = reader.GetInt32(0),
                    Direccion = reader["direccion"].ToString(),
                    Ambientes = Int32.Parse(reader["ambientes"].ToString()),
                    Tipo = reader["tipo"].ToString(),
                    Uso = reader["uso"].ToString(),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    Disponible = disponible,
                    Propietario = p,
                };

                inmuebles.Add(i);
            }

            conn.Close();

            return inmuebles;
        }


        public List<Inmueble> obtenerInmuebles()
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM inmueble";

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Inmueble> inmuebles = new List<Inmueble>();

            while (reader.Read())
            {
                PropietarioData propietarioData = new PropietarioData();
                Propietario p = propietarioData.obtenerPropietario(Int32.Parse(reader["id_propietario"].ToString()));

                bool disponible = false;

                if (String.Equals(reader["disponible"].ToString(), "1")) {
                    disponible = true;
                }

                Inmueble i = new Inmueble
                {
                    Id = reader.GetInt32(0),
                    Direccion = reader["direccion"].ToString(),
                    Ambientes = Int32.Parse(reader["ambientes"].ToString()),
                    Tipo = reader["tipo"].ToString(),
                    Uso = reader["uso"].ToString(),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    Disponible = disponible,
                    Propietario = p,
                };

                inmuebles.Add(i);
            }

            conn.Close();

            return inmuebles;
        }

        public List<Inmueble> obtenerInmueblesFiltro(Inmueble inmuebleFiltro)
        {
            //Devuelve inmuebles de acuerdo al uso, tipo, ambientes y precio aproximado del parametro
            SqlConnection conn = Conexion.getConnection();

            System.Diagnostics.Debug.WriteLine("USO: " + inmuebleFiltro.Uso);
            System.Diagnostics.Debug.WriteLine("TIPO: " + inmuebleFiltro.Tipo);
            System.Diagnostics.Debug.WriteLine("AMBIENTES: " + inmuebleFiltro.Ambientes);
            System.Diagnostics.Debug.WriteLine("PRECIO: " + inmuebleFiltro.Precio);

            double precioMin = inmuebleFiltro.Precio - 1000;
            double precioMax = inmuebleFiltro.Precio + 1000;

            String sql = "SELECT * FROM inmueble WHERE uso = '"+inmuebleFiltro.Uso+ "' AND tipo = '" + inmuebleFiltro.Tipo+ "' AND ambientes = " + inmuebleFiltro.Ambientes+" AND precio BETWEEN "+precioMin+" AND "+precioMax+" AND disponible = 1";

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Inmueble> inmuebles = new List<Inmueble>();

            while (reader.Read())
            {
                PropietarioData propietarioData = new PropietarioData();
                Propietario p = propietarioData.obtenerPropietario(Int32.Parse(reader["id_propietario"].ToString()));

                bool disponible = false;

                if (String.Equals(reader["disponible"].ToString(), "1"))
                {
                    disponible = true;
                }

                Inmueble i = new Inmueble
                {
                    Id = reader.GetInt32(0),
                    Direccion = reader["direccion"].ToString(),
                    Ambientes = Int32.Parse(reader["ambientes"].ToString()),
                    Tipo = reader["tipo"].ToString(),
                    Uso = reader["uso"].ToString(),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    Disponible = disponible,
                    Propietario = p,
                };

                inmuebles.Add(i);
            }

            conn.Close();

            return inmuebles;
        }

        public Inmueble obtenerInmueble(int id)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM inmueble WHERE id = " + id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                PropietarioData propietarioData = new PropietarioData();
                Propietario p = propietarioData.obtenerPropietario(Int32.Parse(reader["id_propietario"].ToString()));


                bool disponible = false;

                if (String.Equals(reader["disponible"].ToString(), "1"))
                {
                    disponible = true;
                }

                Inmueble i = new Inmueble
                {
                    Id = reader.GetInt32(0),
                    Direccion = reader["direccion"].ToString(),
                    Ambientes = Int32.Parse(reader["ambientes"].ToString()),
                    Tipo = reader["tipo"].ToString(),
                    Uso = reader["uso"].ToString(),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    Disponible = disponible,
                    Propietario = p,
            };

                conn.Close();

                return i;
            }

            conn.Close();

            System.Diagnostics.Debug.WriteLine("NULLLLLLLLLLLLLLL inmuebles");

            return null;
        }

        public void marcarComoAlquilado(int id) {
            SqlConnection conn = Conexion.getConnection();

            String sql = "UPDATE inmueble SET disponible = 0 WHERE id = "+id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            command.ExecuteReader();

            conn.Close();
        }

        public void marcarComoDisponible(int id)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "UPDATE inmueble SET disponible = 1 WHERE id = " + id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            command.ExecuteReader();

            conn.Close();
        }

        public Inquilino eliminar(int id)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "DELETE FROM inmueble WHERE id = " + id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            conn.Close();

            return null;
        }
    }
}
