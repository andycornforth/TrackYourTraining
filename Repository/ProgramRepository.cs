using DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProgramRepository : BaseSqlRepository
    {
        public List<Program> GetPrograms()
        {
            var query = "SELECT * FROM [Training_DB].[dbo].[Program]";

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Program>(command).ToList();
        }

        public Program GetProgramById(int id)
        {
            var query = "SELECT * FROM [Training_DB].[dbo].[Program] WHERE ProgramId = " + id;

            var command = GetCommand(query, CommandType.Text);

            return GetEntitiesFromDatabase<Program>(command).FirstOrDefault();
        }

        public int InsertNewProgram(Program program)
        {
            string insertion = @"INSERT into [Training_DB].[dbo].[Program] (ProgramName, Description) 
                VALUES ('" + program.Name + "', '" + program.Description + "'); SELECT SCOPE_IDENTITY()";

            var command = GetCommand(insertion, CommandType.Text);
            return ExecuteInt32Scalar(command);
        }

        protected override object MapRowToEntity(IDataReader reader)
        {
            var program = new Program();
            program.Id = reader.GetInt32(reader.GetOrdinal("ProgramId"));
            program.Name = reader.GetString(reader.GetOrdinal("ProgramName"));
            if (!reader.IsDBNull(2))
            {
                program.Description = reader.GetString(reader.GetOrdinal("Description"));
            }

            return program;
        }
    }
}
