    public class NoteRepository : INoteRepository
    {
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\NoteTakingApp.mdf;Integrated Security=True;";

        public void Create(Note note)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Notes (Title, Content, CreatedAt, UpdatedAt) VALUES (@Title, @Content, @CreatedAt, @UpdatedAt)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Title", note.Title);
                    cmd.Parameters.AddWithValue("@Content", note.Content);
                    cmd.Parameters.AddWithValue("@CreatedAt", note.CreatedAt);
                    cmd.Parameters.AddWithValue("@UpdatedAt", note.UpdatedAt);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<Note> GetAll()
        {
            var notes = new List<Note>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Title, Content, CreatedAt, UpdatedAt FROM Notes";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        notes.Add(new Note
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            UpdatedAt = (DateTime)reader["UpdatedAt"]
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return notes;
        }

        public Note GetById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT Id, Title, Content, CreatedAt, UpdatedAt FROM Notes WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Note
                        {
                            Id = (int)reader["Id"],
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            UpdatedAt = (DateTime)reader["UpdatedAt"]
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return null;
        }

        public void Update(Note note)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Notes SET Title = @Title, Content = @Content, UpdatedAt = @UpdatedAt WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", note.Id);
                    cmd.Parameters.AddWithValue("@Title", note.Title);
                    cmd.Parameters.AddWithValue("@Content", note.Content);
                    cmd.Parameters.AddWithValue("@UpdatedAt", note.UpdatedAt);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Notes WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



    }
