using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterdisciplinarLTP6.Domain.Commands.Handlers;
using InterdisciplinarLTP6.Domain.Commands.Inputs;
using InterdisciplinarLTP6.Domain.Commands.Results;
using InterdisciplinarLTP6.Domain.Queries;
using InterdisciplinarLTP6.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InterdisciplinarLTP6.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeCommandHandler EmployeeHandler;
        private readonly EmployeeQuery EmployeeQuery;

        public EmployeeController(EmployeeCommandHandler employeeHandler, EmployeeQuery employQuery)
        {
            EmployeeHandler = employeeHandler;
            EmployeeQuery = employQuery;
        }

        public async Task<IActionResult> Index()
        {
            var employees = EmployeeQuery.GetEmployees().GetAwaiter().GetResult();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand employee)
        {
            var result = (CreateEmployeeCommandResult)EmployeeHandler.Handle(employee).GetAwaiter().GetResult();
            if (!result.Validation)
            {
                ViewBag.Validation = EmployeeHandler.Notifications.Select(x => x.Message);
                return View(employee);
            }
            return RedirectToAction("Index");
        }
    }
}