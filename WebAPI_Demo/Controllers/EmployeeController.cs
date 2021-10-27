using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Demo_DBContext _context;

        public EmployeeController(Demo_DBContext context)
        {
            _context = context;
        }

        [HttpGet("{recordCount}")]
        public IActionResult Get(int recordCount)
        {
            var empList = _context.Employees.OrderBy(x => x.EmployeeName).Skip(recordCount).Take(50).ToList();
            return Ok(empList);
        }

        [HttpGet("{filter}/{value}")]
        public IActionResult Get(string filter, string value)
        {
            if (value == "~")
            {
                return Ok(_context.Employees.OrderBy(x => x.EmployeeName).Skip(0).Take(50).ToList());
            }
            switch (filter)
            {
                case "EmployeeName":
                    return Ok(_context.Employees.Where(x => x.EmployeeName.StartsWith(value)).ToList());
                case "Department":
                    return Ok(_context.Employees.Where(x => x.Department.StartsWith(value)).ToList());
                case "EmployeeLocation":
                    return Ok(_context.Employees.Where(x => x.EmployeeLocation.StartsWith(value)).ToList());
                default:
                    break;
            }
            return null;
        }

        [HttpGet("sortData/{direction}/{columnName}")]
        public IActionResult GetSortedData(string direction, string columnName)
        {
            switch (columnName)
            {
                case "EmployeeName":
                    if (direction == "asc")
                    {
                        return Ok(_context.Employees.OrderBy(x => x.EmployeeName).ToList());
                    }
                    return Ok(_context.Employees.OrderByDescending(x => x.EmployeeName).ToList());
                case "Department":
                    if (direction == "asc")
                    {
                        return Ok(_context.Employees.OrderBy(x => x.Department).ToList());
                    }
                    return Ok(_context.Employees.OrderByDescending(x => x.Department).ToList());
                case "EmployeeLocation":
                    if (direction == "asc")
                    {
                        return Ok(_context.Employees.OrderBy(x => x.EmployeeLocation).ToList());
                    }
                    return Ok(_context.Employees.OrderByDescending(x => x.EmployeeLocation).ToList());
                default:
                    break;
            }
            return null;
        }

        [HttpGet("filterData/{value}")]
        public IActionResult FilterData(string value)
        {
            if (value != "")
            {
                string searchValue = value;
                if (searchValue == "~")
                {
                    return Ok(_context.Employees.OrderBy(x => x.EmployeeName).Skip(0).Take(50).ToList());
                }

                List<Models.Employee> employees = new List<Models.Employee>();
                var list = _context.Employees.ToList();
                var empNamelst = list.Where(x => x.EmployeeName.Contains(searchValue.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
                var empLocationlst = list.Where(x => x.EmployeeLocation.Contains(searchValue.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
                var empDeptlst = list.Where(x => x.Department.Contains(searchValue.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
                if (empNamelst.Count > 0)
                    employees.AddRange(empNamelst);
                if (empLocationlst.Count > 0)
                    employees.AddRange(empLocationlst);
                if (empDeptlst.Count > 0)
                    employees.AddRange(empDeptlst);
                return Ok(employees);
            }
            return null;
        }
    }
}
