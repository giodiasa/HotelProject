﻿using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class HotelRepository
    {
        public async Task<List<Hotel>> GetHotels()
        {
            List<Hotel> result = new();
            const string sqlExpression = "sp_GetAllHotels";
            using (SqlConnection connection = new(ApplicationDBContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.Add(new Hotel()
                            {
                                Id = reader.GetInt32(0),
                                Name = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                Rating = !reader.IsDBNull(1) ? reader.GetDouble(2) : 0,
                                Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty,
                                City = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty,
                                PhysicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty,
                                ManagerId = !reader.IsDBNull(6) ? reader.GetInt32(6) : 0
                            });
                        }
                    }
                    if (result.Count == 0)
                    {
                        throw new InvalidOperationException("No hotels found");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
                return result;
            }
        }

        public async Task AddHotel(Hotel hotel)
        {
            string sqlExpression = @$"sp_AddNewHotel";
            using (SqlConnection connection = new(ApplicationDBContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("name", hotel.Name);
                    command.Parameters.AddWithValue("rating", hotel.Rating);
                    command.Parameters.AddWithValue("country", hotel.Country);
                    command.Parameters.AddWithValue("city", hotel.City);
                    command.Parameters.AddWithValue("physicalAddress", hotel.PhysicalAddress);
                    command.Parameters.AddWithValue("managerId", hotel.ManagerId);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
        public async Task UpdateHotel(Hotel hotel)
        {
            string sqlExpression = @$"sp_UpdateHotel";
            using (SqlConnection connection = new(ApplicationDBContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", hotel.Id);
                    command.Parameters.AddWithValue("name", hotel.Name);
                    command.Parameters.AddWithValue("rating", hotel.Rating);
                    command.Parameters.AddWithValue("country", hotel.Country);
                    command.Parameters.AddWithValue("city", hotel.City);
                    command.Parameters.AddWithValue("physicalAddress", hotel.PhysicalAddress);
                    command.Parameters.AddWithValue("managerId", hotel.ManagerId);
                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No hotels found with this ID");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        public async Task DeleteHotel(int id)
        {
            string sqlExpression = @$"sp_DeleteHotel";
            using (SqlConnection connection = new(ApplicationDBContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);
                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("No hotels found with this ID");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }
    }
}
