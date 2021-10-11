using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDapper
    {
        void SetEntry(Entry entry);

        void SetBreak(Break brk, string id, DateTime date);

        List<Entry> GetEntry(string id);
        AspNetUser GetUser(string name);
    }
}
