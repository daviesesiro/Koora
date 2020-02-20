using Koora.Models;
using Koora.Models.MyModels;
using Koora.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koora.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public EventController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Event
        [AllowAnonymous]
        public ActionResult Index()
        {
            var events = db.Events.OrderByDescending(x => x.id).ToList();
            return View(events);
        }

        //GET: Event/1
        [HttpGet]
        public ActionResult Position(int? id)
       {
            if (id != null)
            {
                var _event = db.Events.Find(id);

                if (_event != null)
                {
                    if (_event.IsOngoing)
                    {
                        var positions = db.Positions.Where(p => p.eventId == id);
                        ViewBag.PreviousUrl = "/event/index";
                        return View("Position", positions);
                    }
                    return Redirect("/event/result/" + _event.id);
                }

                return HttpNotFound();
            }
            return HttpNotFound();           
        }


        //GET: Event/Nominee
        [HttpGet]
        [Route("Event/Vote/{id}")]
        public ActionResult Nominees(int? id)
        {
            if (id != null)
            {
                var _event = db.Positions.Include("_event").Where(p => p.id == id).First()._event;

                if (_event != null)
                {
                    if (_event.IsOngoing)
                    {
                        var nominees = db.Nominees.Include("Position").Where(n => n.positionId == id);
                        var position = db.Positions.Find(id);
                        var viewModel = new VotePageViewModel { name = position.name, nominees = nominees };

                        if (nominees != null)
                        {
                            ViewBag.PreviousUrl = "/event/position/" + _event.id;
                            return View("VotePage", viewModel);
                        }
                    }
                    return Redirect("/event/result" + _event.id);
                }
                return HttpNotFound();
            }

            return HttpNotFound();
            
        }

        //Vote nominee
        [HttpPost]     
        [ValidateAntiForgeryToken]
        public ActionResult Vote(VotePageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int nomineeId = viewModel.nomineeId;
                Nominee nominee = db.Nominees.Find(nomineeId);
                var positionId = nominee.positionId;
                var userId = User.Identity.GetUserId();
                var noVote = 0;

                //Checking if that user has voted for the category before in the castVote table
                bool hasNotVotedInCategory = db.CastVotes.Where(x => x.positionId == positionId & x.userId == userId).Count() == 0;

                if (hasNotVotedInCategory)
                {
                    //creating a new record in the table of casted votes
                    var castRecord = new CastVote { nomineeId = nomineeId, positionId = positionId, userId = userId };
                    db.CastVotes.Add(castRecord);

                    //increment the nominee's vote
                    noVote = nominee.votes + 1;
                    nominee.votes = noVote;

                    db.SaveChanges();

                    var result = new { Message = true, vCount = noVote.ToString() };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Message = false, vCount = nominee.votes.ToString() }, JsonRequestBehavior.AllowGet);
                }
            }
            return RedirectToAction("index", "Home");


        }


        public ActionResult Result(int? id)
        {
            if (id != null)
            {
                ViewBag.PreviousUrl = "/event/index";
                var _event = db.Events.Find(id);

                if (_event != null)
                {
                    if (!_event.IsOngoing)
                    {
                        var nom = db.Nominees.Include("Position").Where(m => m.position.eventId == id).ToList();
                        if (nom != null)
                        {
                            var eventName = _event.name;
                            var ViewModel = new ResultViewModel() { EventName = eventName, Nominees = nom };
                            return View(ViewModel);
                        }
                    }
                    return Redirect("/event/position/" + id);
                }

                return HttpNotFound();
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
    