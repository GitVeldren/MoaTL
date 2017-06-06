using Microsoft.AspNet.Identity;
using MoaTL.Models;
using MoaTL.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MoaTL.Controllers
{
    public class PartiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartiesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Parties
        public ActionResult Index()
        {
            var dm = User.Identity.GetUserId();
            var parties = _context.Parties.Where(c => c.DungeonMaster.Id == dm).ToList();
            return View(parties);
        }

        // GET: Parties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Party party)
        {
            if (ModelState.IsValid)
            {
                party.DungeonMasterId = User.Identity.GetUserId();

                _context.Parties.Add(party);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(party);
        }

        // GET: Parties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var party = new PartyViewModel
            {
                Party = _context.Parties.Single(p => p.Id == id),
                Characters = new List<Character>(_context.Characters.ToList())
            };

            return View(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Party party)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(party).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        // GET: Parties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var party = _context.Parties.Find(id);
            if (party == null)
            {
                return HttpNotFound();
            }
            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var party = _context.Parties.Find(id);
            _context.Parties.Remove(party);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
