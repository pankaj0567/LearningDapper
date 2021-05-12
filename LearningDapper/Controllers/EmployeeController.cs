using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dapper.Core.Domain.Employee;
using Dapper.Data;

namespace LearningDapper.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDbContext dbContext;

        public EmployeeController(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            var employees = await dbContext.Employee.GetAllAsync<Employee>("spGetAllEmployee");
            return View(employees);
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = await GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Salary,Email,Gender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await dbContext.Employee.AddAsync("spInsertEmployee", employee);
                
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = await GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Salary,Email,Gender")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await dbContext.Employee.UpdateAsync("spUpdateEmployee", employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        
        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await dbContext.Employee.DeleteAsync("spDeleteEmployeeById", id);
            return RedirectToAction("Index");
        }

        private async Task<Employee> GetById(int? id) => await dbContext.Employee.GetByIdAsync<Employee>("spGetEmployeeById", id ?? 0);
    }

    
}
