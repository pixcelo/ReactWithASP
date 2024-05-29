
using Microsoft.Data.SqlClient;
using WebAPI.Models;
using WebAPI.Repositories.Implementations;

namespace WebAPI.Repositories.Interfaces
{

    public class TodoRepository : ITodoRepository
    {
        private readonly IConfiguration _configuration;

        public TodoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Delete(Todo history)
        {
            throw new NotImplementedException();
        }

        public Todo Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Todo todo)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"
                    INSERT INTO 
                    todos (title, description)
                    VALUES  (@title, @description)
                ";

                command.Parameters.Add(new SqlParameter("@title", todo.Title));
                command.Parameters.Add(new SqlParameter("@description", todo.Description));
                command.ExecuteNonQuery();
            }
        }
    }
}
