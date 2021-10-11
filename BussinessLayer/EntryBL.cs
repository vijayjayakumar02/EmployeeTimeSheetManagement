using DataAccessLayer.Access;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class EntryBL
    {
        
        private readonly IDapper dapper;
        private readonly EntryDAL _entryDAL;

        public EntryBL(IDapper dapper,EntryDAL entryDAL)
        {
            this.dapper = dapper;
            this._entryDAL = entryDAL;
        }
        public List<Entry> GetEntry(string id)
        {
            var entries = dapper.GetEntry(id);

            return entries;
        }
        public async Task<AspNetUser> GetUsers(string name)
        {
            AspNetUser user = await _entryDAL.GetUser(name);

            return user;
        }
        public void CreateEntry(TimeSheet model)
        {
            if(model.TimeIn != null)
            {
                Entry entry = new Entry
                {
                    EmployeeId = model.EmployeeId,
                    Date = model.Date,
                    InTime = model.TimeIn,
                    OutTime = model.TimeOut,
                };
                dapper.SetEntry(entry);
            }
            else if(model.BreakIn != null)
            {
                Break breakentry = new Break
                {
                    BreakIn = model.BreakIn,
                    BreakOut = model.BreakOut
                };
                dapper.SetBreak(breakentry, model.EmployeeId, model.Date);
            }
        } 
    }
}
