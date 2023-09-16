using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEP_API.DataAccessLayer;
using WEP_API.DataAccessLayer.Concrete;

namespace WEP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            c.Add(employee);
            c.SaveChanges();


            return Ok();
        }
        [HttpGet("{id}")]

        public IActionResult GetEmployee(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if(employee==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }

        }
        [HttpGet("{id}")]

        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var employee = c.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(id);
                c.SaveChanges();
                return Ok(employee);
            }

        }
        [HttpPut]

        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var emp = c.Find<Employee>(employee.EmployeeID);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employee.Name;
                c.Update(emp);
                c.SaveChanges();
                return Ok();
            }

        }
    }
}

