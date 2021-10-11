using BussinessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly EntryBL _entryBL;
        private readonly AccountBL _accountBL;

        public TimeSheetController(EntryBL entryBL, AccountBL accountBL)
        {
            _entryBL = entryBL;
            _accountBL = accountBL;
        }
        
        public IActionResult Index()
        {
            TimeSheet entry = new TimeSheet();
            entry.BreakList.Add(new Break() { EntryId = 1 });

            ViewBag.User = _entryBL.GetUsers(User.Identity.Name);
            return View(entry);
        }
    }
}
