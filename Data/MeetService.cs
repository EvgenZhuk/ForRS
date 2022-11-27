using ForRS.Data.Database;
using Npgsql;

namespace ForRS.Data
{
    public class MeetService
    {
        private List<Meet> _meets = new List<Meet>();
        WorkWithDB workWithDB = new WorkWithDB();
        GenerateRequests genSQLRequests = new GenerateRequests();

        public Task<List<Meet>> GetMeetAsync()
        {
            try
            {
                workWithDB.OpenConnection();
                string sql = genSQLRequests.GetMeets();
                List<Meet> response = workWithDB.QuerySelect(sql);
                workWithDB.CloseConnection();
                return Task.FromResult(response);
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                _meets = new List<Meet>();
                return Task.FromResult(_meets);
            }
        }
    }
}
