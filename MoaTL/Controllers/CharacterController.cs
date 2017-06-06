using Microsoft.AspNet.Identity;
using MoaTL.Models;
using System.Linq;
using System.Web.Mvc;

namespace MoaTL.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var player = User.Identity.GetUserId();
            var characters = _context.Characters.Where(c => c.Player.Id == player).ToList();
            return View(characters);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Character character)
        {
            try
            {
                character.PlayerId = User.Identity.GetUserId();
                character.PlayerName = _context.Users.Single(u => u.Id == character.PlayerId).Name;

                _context.Characters.Add(character);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var character = _context.Characters.Single(c => c.Id == id);

            return View(character);
        }

        [HttpPost]
        public ActionResult Edit(int id, Character character)
        {
            try
            {
                var existingCharacter = _context.Characters.Single(c => c.Id == id);

                existingCharacter.Name = character.Name;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(character);
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id, Character character)
        {
            try
            {
                _context.Characters.Remove(character);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}