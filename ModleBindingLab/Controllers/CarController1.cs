using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModleBindingLab.Models;

namespace ModleBindingLab.Controllers
{
    public class CarController1 : Controller
    {
        // GET: CarController1
        public ActionResult Index()
        {
            List<Car> lstcar = Car.GetAllCars();
            return View(lstcar);
        }

        // GET: CarController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController1/Edit/5
        public ActionResult Edit(int id)
        {
            Car obj = Car.GetSingleCar(id);
            return View(obj);
        }

        // POST: CarController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car cr, IFormCollection collection)
        {
            try
            {
                Car.Update(cr);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController1/Delete/5
        public ActionResult Delete(int id)
        {
            Car obj = Car.GetSingleCar(id);
            return View(obj);
        }

        // POST: CarController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car obj)
        {
            try
            {
                Car.DeleteCar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
