using AlytaloMobile4.Database;
using AlytaloMobile4.Models;
using AlytaloMobile4.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AlytaloMobile4.Controllers


{
    public class HallintaController : Controller
    {
        // GET: Hallinta
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Käyttis()

        {
            return View();
        }

        // GET: Hallinta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hallinta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hallinta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // AddRooms
       
        [HttpPost]
        public JsonResult Addrooms()
        {
            string json = Request.InputStream.ReadToEnd();
            AddRoomsModel inputData =
                JsonConvert.DeserializeObject<AddRoomsModel>(json);

            bool success = false;
            string error = "";

            AlytaloMobile2Entities entities = new AlytaloMobile2Entities();
            try
            {

                int huone = (from h in entities.Hallintas
                                  where h.Huone == inputData.Huone
                                  select h.ID).FirstOrDefault();
                
               // Hallinta newEntry = new Hallinta();
                 //   newEntry.Huone = huone;
                   // newEntry.Pvm = DateTime.Now;

                //    entities.Hallintas.Add(newEntry);
                    entities.SaveChanges();

                    success = true;
                            }
            catch (Exception ex)
            {
                error = error.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }

            //Palautetaan JSON-muotoinen tulos kutsujalle
            var result = new { success = success, error = error };
            return Json(result);
        }
    




// GET: Hallinta/Edit/5
public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hallinta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hallinta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hallinta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
