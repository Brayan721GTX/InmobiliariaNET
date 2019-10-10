using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class PropietarioData
    {
        public List<Propietario> obtenerPropietarios() {
            //SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=inmobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM propietario";

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Propietario> propietarios = new List<Propietario>();

            while (reader.Read()) {
                Propietario p = new Propietario {
                    Id = reader.GetInt32(0),
                    Dni = reader["dni"].ToString(),
                    Apellido = reader["apellido"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Telefono = reader["telefono"].ToString(),
                    Mail = reader["mail"].ToString(),
                    Password = reader["password"].ToString(),
                };

                propietarios.Add(p);
            }

            conn.Close();

            return propietarios;
        }

        public Propietario obtenerPropietario(int id) {
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM propietario WHERE id = "+id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                Propietario p = new Propietario
                {
                    Id = reader.GetInt32(0),
                    Dni = reader["dni"].ToString(),
                    Apellido = reader["apellido"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Telefono = reader["telefono"].ToString(),
                    Mail = reader["mail"].ToString(),
                    Password = reader["password"].ToString(),
                };

                conn.Close();

                return p;
            }

            conn.Close();

            return null;
        }

        public Object crear(Propietario propietario) {
            SqlConnection conn = Conexion.getConnection();

            String sql = "INSERT INTO propietario (dni, apellido, nombre, telefono, mail, password) VALUES (@dni, @apellido, @nombre, @telefono, @mail, @password)";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@dni", propietario.Dni);
            command.Parameters.AddWithValue("@apellido", propietario.Apellido);
            command.Parameters.AddWithValue("@nombre", propietario.Nombre);
            command.Parameters.AddWithValue("@telefono", propietario.Telefono);
            command.Parameters.AddWithValue("@mail", propietario.Mail);
            command.Parameters.AddWithValue("@password", propietario.Password);

            conn.Open();

            var id = command.ExecuteScalar();

            conn.Close();

            return id;
        }

        public bool existe(int id) {
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM propietario WHERE id = "+id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            if (reader.Read()) {
                conn.Close();
                return true;
            }

            conn.Close();

            return false;
        }

        public Inquilino eliminar(int id)
        {
            SqlConnection conn = Conexion.getConnection();

            List<Inmueble> inmuebles = new InmueblesData().obtenerInmueblesDePropietario(id);

            foreach (Inmueble i in inmuebles) {
                new InmueblesData().eliminar(i.Id);
            }

            String sql = "DELETE FROM propietario WHERE id = " + id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            conn.Close();

            return null;
        }

        public void editar(Propietario propietario)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "UPDATE propietario SET dni=@dni, apellido=@apellido, nombre=@nombre, telefono=@telefono, mail=@mail, password=@password WHERE id = "+propietario.Id;

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@dni", propietario.Dni);
            command.Parameters.AddWithValue("@apellido", propietario.Apellido);
            command.Parameters.AddWithValue("@nombre", propietario.Nombre);
            command.Parameters.AddWithValue("@telefono", propietario.Telefono);
            command.Parameters.AddWithValue("@mail", propietario.Mail);
            command.Parameters.AddWithValue("@password", propietario.Password);

            conn.Open();

            command.ExecuteReader();

            conn.Close();
        }
    }
}
