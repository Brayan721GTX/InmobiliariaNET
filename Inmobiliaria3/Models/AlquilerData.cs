using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class AlquilerData
    {
        public List<Alquiler> obtenerAlquileres()
        {
            //SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=inmobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM alquiler";

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Alquiler> alquileres = new List<Alquiler>();

            while (reader.Read())
            {
                InquilinoData inquilinoData = new InquilinoData();
                Inquilino inquilino = inquilinoData.obtenerInquilino(Int32.Parse(reader["id_inquilino"].ToString()));

                InmueblesData inmuebleData = new InmueblesData();
                Inmueble inmueble = inmuebleData.obtenerInmueble(Int32.Parse(reader["id_inmueble"].ToString()));

                Alquiler a = new Alquiler
                {
                    Id = reader.GetInt32(0),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    FechaInicio = Convert.ToDateTime(reader["fecha_inicio"].ToString()),
                    FechaFin = Convert.ToDateTime(reader["fecha_fin"].ToString()),
                    Inquilino = inquilino,
                    Inmueble = inmueble,
                };

                alquileres.Add(a);
            }

            conn.Close();

            return alquileres;
        }

        public List<Alquiler> obtenerAlquileresDeInmueble(int idInmueble)
        {
            //SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=inmobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM alquiler WHERE id_inmueble = "+idInmueble;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Alquiler> alquileres = new List<Alquiler>();

            while (reader.Read())
            {
                InquilinoData inquilinoData = new InquilinoData();
                Inquilino inquilino = inquilinoData.obtenerInquilino(Int32.Parse(reader["id_inquilino"].ToString()));

                InmueblesData inmuebleData = new InmueblesData();
                Inmueble inmueble = inmuebleData.obtenerInmueble(Int32.Parse(reader["id_inmueble"].ToString()));

                Alquiler a = new Alquiler
                {
                    Id = reader.GetInt32(0),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    FechaInicio = Convert.ToDateTime(reader["fecha_inicio"].ToString()),
                    FechaFin = Convert.ToDateTime(reader["fecha_fin"].ToString()),
                    Inquilino = inquilino,
                    Inmueble = inmueble,
                };

                alquileres.Add(a);
            }

            conn.Close();

            return alquileres;
        }

        public List<Alquiler> obtenerAlquileresVigentes()
        {
            //SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=inmobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM alquiler";

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            List<Alquiler> alquileres = new List<Alquiler>();

            while (reader.Read())
            {
                InquilinoData inquilinoData = new InquilinoData();
                Inquilino inquilino = inquilinoData.obtenerInquilino(Int32.Parse(reader["id_inquilino"].ToString()));

                InmueblesData inmuebleData = new InmueblesData();
                Inmueble inmueble = inmuebleData.obtenerInmueble(Int32.Parse(reader["id_inmueble"].ToString()));

                Alquiler a = new Alquiler
                {
                    Id = reader.GetInt32(0),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    FechaInicio = Convert.ToDateTime(reader["fecha_inicio"].ToString()),
                    FechaFin = Convert.ToDateTime(reader["fecha_fin"].ToString()),
                    Inquilino = inquilino,
                    Inmueble = inmueble,
                };

                if (DateTime.Compare(a.FechaFin, DateTime.Now) > 0)
                {
                    alquileres.Add(a);
                }
            }

            conn.Close();

            return alquileres;
        }

        public Alquiler obtenerAlquiler(int idAlquiler)
        {
            //SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=inmobiliaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection conn = Conexion.getConnection();

            String sql = "SELECT * FROM alquiler WHERE Id = "+idAlquiler;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                InquilinoData inquilinoData = new InquilinoData();
                Inquilino inquilino = inquilinoData.obtenerInquilino(Int32.Parse(reader["id_inquilino"].ToString()));

                InmueblesData inmuebleData = new InmueblesData();
                Inmueble inmueble = inmuebleData.obtenerInmueble(Int32.Parse(reader["id_inmueble"].ToString()));

                Alquiler a = new Alquiler
                {
                    Id = reader.GetInt32(0),
                    Precio = Double.Parse(reader["precio"].ToString()),
                    FechaInicio = Convert.ToDateTime(reader["fecha_inicio"].ToString()),
                    FechaFin = Convert.ToDateTime(reader["fecha_fin"].ToString()),
                    Inquilino = inquilino,
                    Inmueble = inmueble,
                };

                return a;
            }

            conn.Close();

            return null;
        }

        public int crear(Alquiler alquiler)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "INSERT INTO alquiler (precio, fecha_inicio, fecha_fin, id_inquilino, id_inmueble) VALUES (@precio, @fecha_inicio, @fecha_fin, @id_inquilino, @id_inmueble)";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@precio", alquiler.Precio);
            command.Parameters.AddWithValue("@fecha_inicio", alquiler.FechaInicio);
            command.Parameters.AddWithValue("@fecha_fin", alquiler.FechaFin);
            command.Parameters.AddWithValue("@id_inquilino", alquiler.Inquilino.Id);
            command.Parameters.AddWithValue("@id_inmueble", alquiler.Inmueble.Id);

            conn.Open();

            int id = Convert.ToInt32(command.ExecuteScalar());

            conn.Close();

            return id;
        }

        public void cancelarAlquiler(int idAlquiler)
        {
            SqlConnection conn = Conexion.getConnection();
            //String fecha = DateTime.Now.ToString("dd/mm/yyyy");
            String sql = "UPDATE alquiler SET fecha_fin = GETDATE() WHERE id = " + idAlquiler;

            InmueblesData inmueblesData = new InmueblesData();
            inmueblesData.marcarComoDisponible(new AlquilerData().obtenerAlquiler(idAlquiler).Inmueble.Id);

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            command.ExecuteReader();

            conn.Close();
        }

        public void renovarAlquiler(int idAlquiler, DateTime fechaInicio, DateTime fechaFin, double Precio)
        {
            SqlConnection conn = Conexion.getConnection();
            String sql = "UPDATE alquiler SET fecha_inicio = '" + fechaInicio.ToString("dd/mm/yyyy")+ "', fecha_fin = '"+ fechaFin.ToString("dd/mm/yyyy") + "', precio = '" + Precio + "' WHERE id = " + idAlquiler;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            command.ExecuteReader();

            conn.Close();
        }

        public void eliminar(int id)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "DELETE FROM alquiler WHERE id = " + id;

            SqlCommand command = new SqlCommand(sql, conn);

            conn.Open();

            var reader = command.ExecuteReader();

            conn.Close();
        }

        public void editar(Alquiler alquiler)
        {
            SqlConnection conn = Conexion.getConnection();

            String sql = "UPDATE alquiler SET precio=@precio, fecha_inicio=@fecha_inicio, fecha_fin=@fecha_fin WHERE id = " + alquiler.Id;

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@precio", alquiler.Precio);
            command.Parameters.AddWithValue("@fecha_inicio", alquiler.FechaInicio);
            command.Parameters.AddWithValue("@fecha_fin", alquiler.FechaFin);

            conn.Open();

            command.ExecuteScalar();

            conn.Close();
        }
    }
}
