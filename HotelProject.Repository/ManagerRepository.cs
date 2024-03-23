using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;

namespace HotelProject.Repository
{
    public class ManagerRepository
    {
        public List<Manager> GetManagers()
        {
            List<Manager> result = new();
            const string sqlExpression = "SELECT*FROM Managers";
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
                            result.Add(new Manager()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty,
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

        public void AddManager(Manager manager)
        {
            string sqlExpression = @$"INSERT INTO Managers(FirstName,LastName) VALUES (N'{manager.FirstName}',N'{manager.LastName}')";
            using(SqlConnection connection = new(ApplicationDBContext.ConnectionString))
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
        public void UpdateManager(Manager manager)
        {
            string sqlExpression = @$"UPDATE Managers SET FirstName = N'{manager.FirstName}', LastName = N'{manager.LastName}' WHERE Id = {manager.Id}";
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

        public void DeleteManager(int id)
        {
            string sqlExpression = @$"DELETE FROM Managers WHERE Id = {id}";
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

