﻿
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

        public void Save(Todo todo)
        {
            try
            {
                string? connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = @"
                        INSERT INTO 
                        todos (title, description, priority, dueDate, createdAt, completedAt, isCompleted, projectId)
                        VALUES (@title, @description, @priority, @dueDate, @createdAt, @completedAt, @isCompleted, @projectId)
                    ";

                    command.Parameters.AddWithValue("@title", todo.Title);
                    command.Parameters.AddWithValue("@description", todo.Description);
                    command.Parameters.AddWithValue("@priority", todo.Priority);
                    command.Parameters.AddWithValue("@dueDate", todo.DueDate);
                    command.Parameters.AddWithValue("@createdAt", todo.CreatedAt);
                    command.Parameters.AddWithValue("@completedAt", todo.CompletedAt);
                    command.Parameters.AddWithValue("@isCompleted", todo.IsCompleted);
                    command.Parameters.AddWithValue("@projectId", todo.ProjectId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                string? connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "DELETE FROM Todos WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Todo? Find(int id)
        {
            try
            {
                string? connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SELECT * FROM Todos WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var key = (int)reader["Id"];
                            var title = reader["Title"] as string;
                            var description = reader["Description"] as string;
                            var priority = reader["Priority"] as int?;
                            var dueDate = reader["DueDate"] as DateTime?;
                            var completedAt = reader["CompletedAt"] as DateTime?;
                            var isCompleted = reader["IsCompleted"] as int?;
                            var projectId = reader["ProjectId"] as int?;

                            return new Todo()
                            {
                                Id = key,
                                Title = title,
                                Description = description,
                                Priority = priority,
                                DueDate = dueDate,
                                CompletedAt = completedAt,
                                IsCompleted = isCompleted,
                                ProjectId = projectId
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Todo> FindAll()
        {
            try
            {
                string? connectionString = _configuration.GetConnectionString("DefaultConnection");

                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "SELECT * FROM Todos";

                    using (var reader = command.ExecuteReader())
                    {
                        var todos = new List<Todo>();

                        while (reader.Read())
                        {
                            var id = (int)reader["Id"];
                            var title = reader["Title"] as string;
                            var description = reader["Description"] as string;
                            var priority = reader["Priority"] as int?;
                            var dueDate = reader["DueDate"] as DateTime?;
                            var completedAt = reader["CompletedAt"] as DateTime?;
                            var isCompleted = reader["IsCompleted"] as int?;
                            var projectId = reader["ProjectId"] as int?;

                            todos.Add(new Todo()
                            {
                                Id = id,
                                Title = title,
                                Description = description,
                                Priority = priority,
                                DueDate = dueDate,
                                CompletedAt = completedAt,
                                IsCompleted = isCompleted,
                                ProjectId = projectId
                            });
                        }

                        return todos;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
