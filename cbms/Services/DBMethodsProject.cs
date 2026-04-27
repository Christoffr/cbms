using cbms.Models;
using Microsoft.Data.SqlClient;

namespace cbms.Services
{
    public class DBMethodsProject : DBMethods<Project>
    {
        public DBMethodsProject(IConfiguration configuration) : base(configuration, "cbms_Project", "(@Title, @Tagline, @Text, @Link)")
        {
        }

        protected override void AddParametersValues(SqlCommand command, Project entity)
        {
            command.Parameters.AddWithValue("@Title", entity.Title);
            command.Parameters.AddWithValue("@Tagline", entity.Tagline);
            command.Parameters.AddWithValue("@Text", entity.Text);
            command.Parameters.AddWithValue("@Link", entity.Link);
        }

        protected override Project GetRow(SqlDataReader reader)
        {
            Project project = new Project
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Tagline = reader.GetString(reader.GetOrdinal("Tagline")),
                Text = reader.GetString(reader.GetOrdinal("Text")),
                Link = reader.GetString(reader.GetOrdinal("Link"))
            };

            return project;
        }
    }
}
