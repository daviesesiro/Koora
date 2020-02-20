using Koora.Models;
using Koora.Models.MyModels;
using Koora.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koora.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public AdminController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Admin/
        public ActionResult Index()
        {
            var feedbacks = db.Feedbacks.ToList();
            return View(feedbacks);
        }



        #region Events

        // GET: Admin/Event
        public ActionResult Event()
        {
            return View(db.Events.ToList());
        }

        // GET: Admin/Event/1
        [HttpGet]
        public ActionResult EditEvent(int? id)
        {
            if (id != null)
            {
                var _event = db.Events.Find(id);
                return Json(_event,JsonRequestBehavior.AllowGet);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult UpdateEvent(int id,string name, string description, bool isOngoing)
        {
            var _event = db.Events.Find(id);
            if(_event != null)
            {
                _event.name = name;
                _event.Description = description;
                _event.IsOngoing = isOngoing;

                if (!isOngoing)
                {
                    _event.endedTime = DateTime.Now;
                }
                else
                {
                    _event.endedTime = null;    
                }
                db.SaveChanges();
                return Json(new { Message = "Updated successful",CreatedTime=_event.createdTime.ToString(), EndedTime = _event.endedTime.ToString() }, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new {Message = "Unable to find to update event" });
        }

        [HttpPost]
        public ActionResult NewEvent(string name, string description, HttpPostedFileWrapper Image)
        {
            if (ModelState.IsValid)
            {
                var file = Image;

                var fileName = Path.GetFileName(file.FileName);
                var fileExt = Path.GetExtension(file.FileName);
                var fileWithoutExt = Path.GetFileNameWithoutExtension(file.FileName);

                string imgDirectory = "/Content/UploadedImages/Event/"+ file.FileName ;

                var _event = new Event
                {
                    name = name,
                    Description = description,
                    createdTime = DateTime.Now,
                    ImgDirectory = imgDirectory,
                    IsOngoing = true
                };

                db.Events.Add(_event);
                file.SaveAs(Server.MapPath(imgDirectory));
                db.SaveChanges();

                return Json(new { Message = "Add Successfully", Event = _event, CreatedTime=_event.createdTime.ToString() }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            if (ModelState.IsValid)
            {
                var _event = db.Events.Find(id);

                if (_event != null)
                {
                    db.Events.Remove(_event);
                    db.SaveChanges();
                    return Json(new { Message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { Message = "Event does not exist" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Nominee
        // GET: Admin/nominee
        public ActionResult Nominee()
        {
            return View(db.Nominees.Include(m=>m.position).Where(m=>m.position._event.IsOngoing).ToList());
        }

        [HttpPost]
        public ActionResult NewNominee(int PositionId, string NomineeName, HttpPostedFileWrapper Image)
        {
            if (ModelState.IsValid)
            {
                var file = Image;

                var fileName = Path.GetFileName(file.FileName);
                var fileExt = Path.GetExtension(file.FileName);
                var fileWithoutExt = Path.GetFileNameWithoutExtension(file.FileName);

                
                string imgDirectory = "/Content/UploadedImages/Nominee/" + file.FileName;
                var nominee = new Nominee
                {
                    name = NomineeName,
                    positionId = PositionId,
                    imageDirectory = imgDirectory
                };
                
                db.Nominees.Add(nominee);
                db.SaveChanges();
                file.SaveAs(Server.MapPath(imgDirectory));
                
                  
                

                return Json(new { Message = "Add Successfully" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteNominee(int id)
        {
            var nominee = db.Nominees.Find(id);
            if (nominee != null)
            {
                db.Nominees.Remove(nominee);
                db.SaveChanges();
                return Json(new { Message = "Deleted successfully" }, JsonRequestBehavior.AllowGet);
            }

           return Json(new { Message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Position
        // GET: Admin/position
        public ActionResult Position()
        {
            var viewModel = new AdminPositionViewModel
            {
                Events = db.Events.Where(m=>m.IsOngoing).ToList(),
                Positions = db.Positions.Include(m=>m._event).Where(m=>m._event.IsOngoing).ToList()
            };

            return View(viewModel);
        }

        //Post: Admin/Position/1
        [HttpPost]
        public ActionResult NewPosition(string name, int eventId)
        {
            if (ModelState.IsValid)
            {
                Position position = new Position
                {
                    name = name,
                    eventId = eventId
                };
                db.Positions.Add(position);                
                db.SaveChanges();

                return Json(new { Message = "Add Successfully", Position = position}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Position/1
        [HttpGet]
        public ActionResult EditPosition(int? id)
        {
            if (id != null)
            {
                var position = db.Positions.Find(id);
                return Json(position, JsonRequestBehavior.AllowGet);
            }

            return HttpNotFound();
        }

        // Post: Admin/Position/1?name=
        [HttpPost]
        public ActionResult UpdatePosition(int id, string name)
        {
            var position = db.Positions.Find(id);
            if (position != null)
            {
                position.name = name;
                db.SaveChanges();
                return Json(new { Message = "Updated successful",Position=position }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Message = "Unable to find to update position" });
        }

        [HttpGet]
        public ActionResult DeletePosition(int id)
        {
            if (ModelState.IsValid)
            {
                var position = db.Positions.Find(id);

                if (position != null)
                {
                    db.Positions.Remove(position);
                    db.SaveChanges();
                    return Json(new { Message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { Message = "Position does not exist" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
        }

        #endregion


        // GET: Admin/place
        public ActionResult Place()
        {
            return View(db.Places.ToList());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult feedback(string Name, string Subject, string Email, string Message)
        {
            if(!string.IsNullOrEmpty(Message) && !string.IsNullOrEmpty(Message))
            {
                var feedback = new Feedback() { Message = Message, Email=Email, Sender = Name, Subject = Subject };
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return Json(new { isOk = true }, JsonRequestBehavior.AllowGet);
            }           

            return Json(new { isOk = false }, JsonRequestBehavior.AllowGet);
            
        }

    }
}