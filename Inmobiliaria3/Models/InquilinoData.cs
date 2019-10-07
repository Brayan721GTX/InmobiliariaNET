using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class InquilinoData
    {
        public List<Inquilino> obtenerInquilinos()
        {
            //SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=inmobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM inquilino";

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Inquilino> inquilinos = new List<Inquilino>();

            while (reader.Read())
            {
                Inquilino i = new Inquilino
                {
                    Id = reader.GetInt32(0),
                    Dni = reader["dni"].ToString(),
                    Apellido = reader["apellido"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Direccion = reader["direccion"].ToString(),
                    Telefono = reader["telefono"].ToString(),
                };

                inquilinos.Add(i);
            }

            conn.Close();

            return inquilinos;
        }

        public Inquilino obtenerInquilino(int id)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM inquilino WHERE id = " + id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                Inquilino i = new Inquilino
                {
                    Id = reader.GetInt32(0),
                    Dni = reader["dni"].ToString(),
                    Apellido = reader["apellido"].ToString(),
                    Nombre = reader["nombre"].ToString(),
                    Direccion = reader["direccion"].ToString(),
                    Telefono = reader["telefono"].ToString(),
                };

                conn.Close();

                return i;
            }

            conn.Close();
            System.Diagnostics.Debug.WriteLine("NULLLLLLLLLLLLLLL inquilino");
            return null;
        }

        public int crear(Inquilino inquilino)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "INSERT INTO inquilino (dni, apellido, nombre, direccion, telefono) VALUES (@dni, @apellido, @nombre, @direccion, @telefono); SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@dni", inquilino.Dni);
            command.Parameters.AddWithValue("@apellido", inquilino.Apellido);
            command.Parameters.AddWithValue("@nombre", inquilino.Nombre);
            command.Parameters.AddWithValue("@direccion", inquilino.Direccion);
            command.Parameters.AddWithValue("@telefono", inquilino.Telefono);

            conn.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());
            System.Diagnostics.Debug.WriteLine("IDDDDDDDDDDDDDDDDDDDD NUEVO: " + id);

            conn.Close();

            return id;
        }

        public void editar(Inquilino inquilino)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "UPDATE inquilino SET dni = @dni, apellido=@apellido, nombre = @nombre, direccion=@direccion, telefono=@telefono WHERE id = "+inquilino.Id;

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@dni", inquilino.Dni);
            command.Parameters.AddWithValue("@apellido", inquilino.Apellido);
            command.Parameters.AddWithValue("@nombre", inquilino.Nombre);
            command.Parameters.AddWithValue("@direccion", inquilino.Direccion);
            command.Parameters.AddWithValue("@telefono", inquilino.Telefono);

            conn.Open();

            command.ExecuteScalar();

            conn.Close();
        }

        public Inquilino eliminar(int id)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "DELETE FROM inquilino WHERE id = " + id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            conn.Close();

            return null;
        }
    }
}
