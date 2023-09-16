using System;
using System.ComponentModel.DataAnnotations;

namespace WEP_API.DataAccessLayer
{
	public class Employee
	{
		[Key]
		public int EmployeeID { get; set; }
        public string Name { get; set; }
    }
}

