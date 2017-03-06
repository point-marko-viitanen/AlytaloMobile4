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
            Hallinta NewEntry = new Database.Hallinta();
            NewEntry.Huone = inputData.Huone;
            try
            {            
              

                    entities.Hallintas.Add(NewEntry);
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



        // Dropdownlista

      // [HttpPost]
        public ActionResult Dropdownlist()
        {
            AlytaloMobile2Entities Entity = new AlytaloMobile2Entities();
            var GetRoomsList = Entity.Hallintas.ToList();
            SelectList list = new SelectList(GetRoomsList, "ID", "Huone");
            ViewBag.Roomlist = list;

            
                return View();
        }



        /*     public JsonResult Dropdownlist()
        {
            AlytaloMobile2Entities Entity = new AlytaloMobile2Entities();
            List<Hallinta> model = Entity.Hallintas.ToList();
            Entity.Dispose();
            return Json(model, JsonRequestBehavior.AllowGet);
            
        }
*/

        // Lights

        [HttpPost]
        public JsonResult Lights()
        {
            string json = Request.InputStream.ReadToEnd();
            AdjustLightsModel inputData =
               JsonConvert.DeserializeObject<AdjustLightsModel>(json);

            bool success = false;
            string error = "";

            AlytaloMobile2Entities entities = new AlytaloMobile2Entities();
            Hallinta NewEntry = new Database.Hallinta();
            NewEntry.Huone = inputData.Lights;
            try
            {


                entities.Hallintas.Add(NewEntry);
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
