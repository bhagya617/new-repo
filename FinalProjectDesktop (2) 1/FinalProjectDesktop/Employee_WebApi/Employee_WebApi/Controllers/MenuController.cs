using System;

using System.Collections.Generic;

using System.Linq;

using System.Net;

using System.Net.Http;

using System.Web.Http;

using Employee_WebApi.Models;

namespace Employee_WebApi.Controllers

{

    public class MenuController : ApiController

    {

        Employee_Travel_Booking_SystemDB1Entities mv = new Employee_Travel_Booking_SystemDB1Entities();

        [HttpPost]

        public List<Menu> create([FromBody] Menu m)

        {
            try
            {

                mv.Menus.Add(new Menu()

                {

                    EmployeeId = m.EmployeeId,

                    EmployeeName = m.EmployeeName,

                    CompanyName = m.CompanyName,

                    Age = m.Age,

                });

                mv.SaveChanges();

                List<Menu> emp = mv.Menus.ToList();

                return emp;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured : "+ex.Message);
                return new List<Menu>();
            }

        }

    }

}
