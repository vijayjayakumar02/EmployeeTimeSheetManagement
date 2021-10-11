using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Access
{
    public class Dapper : IDapper
    {
        private readonly string _connectionString;

        public Dapper(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public List<Entry> GetEntry(string id)
        {
            List<Entry> entries = new();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                entries = connection.Query<Entry>("execute uspGetEntryByID @id", new { @id = id }).ToList();
            }
            return entries;
        }

        public AspNetUser GetUser(string name)
        {
            AspNetUser user = new();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                AspNetUser? aspNetUser = connection.Query<AspNetUser>("execute uspGetEmployee @mail", new { @mail = name }).FirstOrDefault();
                user = aspNetUser;
            }
            return user;
        }
        public void SetEntry(Entry entry)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Query("execute uspInsertPeviousEntry @date,@id,@intime,@outtime", new { @date = entry.Date, @id = entry.EmployeeId, @intime = entry.InTime, @outtime = entry.OutTime });

               

            }
        }
        public void SetBreak(Break brk, string id, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var entryId = connection.Query<Entry>("execute uspGetEntryByID_Date @Id,@Date", new { @Id = id, @Date = date}).FirstOrDefault(x => x.EmployeeId == id);

                connection.Query("execute uspSetFormBreak @EntryId,@BreakIn,@BreakOut", new { @EntryId = entryId.Id, @BreakIn = brk.BreakIn, @BreakOut = brk.BreakOut });
            }
        }
    }
}
