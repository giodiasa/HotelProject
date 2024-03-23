using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class HotelRepository
    {
        public List<Hotel> GetHotels()
        {
            List<Hotel> result = new();
            const string sqlExpression = "SELECT*FROM Hotels";
            using (SqlConnection connection = new(ApplicationDBContext.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            result.Add(new Hotel()
                            {
                                Id = reader.GetInt32(0),
                                Name = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                Rating = reader.GetDouble(2),
                                Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty,
                                City = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty,
                                PhysicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
        }

        public void AddHotel(Hotel hotel)
        {
            string sqlExpression = @$"INSERT INTO Hotels (Name, Rating, Country, City, PhysicalAddress) VALUES (N'{hotel.Name}', {hotel.Rating}, N'{hotel.Country}', N'{hotel.City}', N'{hotel.PhysicalAddress}')";
            using (SqlConnection connection = new(ApplicationDBContext.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void UpdateHotel(Hotel hotel)
        {
            string sqlExpression = @$"UPDATE Hotels SET Name = N'{hotel.Name}', Rating = {hotel.Rating}, Country = N'{hotel.Country}', City = N'{hotel.City}', PhysicalAddress = N'{hotel.PhysicalAddress}' WHERE Id = {hotel.Id}";
            using (SqlConnection connection = new(ApplicationDBContext.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteHotel(int id)
        {
            string sqlExpression = @$"DELETE FROM Hotels WHERE Id = {id}";
            using (SqlConnection connection = new(ApplicationDBContext.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
