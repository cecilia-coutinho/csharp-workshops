using EnkelSidan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnkelSidan.Controllers
{
    public class MembersController : Controller
    {
        // GET: MembersController
        public ActionResult Index()
        {
            var members = SeedData.Members;
            return View(members);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(int id)
        {
            var members = SeedData.GetMemberById(id);
            return View(members);
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View(new Member());
        }


        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member newMember)
        {
            try
            {
                SeedData.AddMember(newMember);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(newMember);
            }
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(int id)
        {
            var existingMember = SeedData.GetMemberById(id);

            try
            {
                return View(existingMember);
            }
            catch
            {
                return NotFound();

            }
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member editedMember)
        {
            if (!ModelState.IsValid)
            {
                return View(editedMember);
            }

            var existingMember = SeedData.Members.FirstOrDefault(m => m.Id == editedMember.Id);

            if (existingMember == null)
            {
                return NotFound();
            }

            existingMember.Name = editedMember.Name;
            existingMember.Role = editedMember.Role;

            return RedirectToAction("Details", new { id = editedMember.Id });
        }

        // GET: MembersController/Delete/5
        public ActionResult Delete(int id)
        {
            var member = SeedData.GetMemberById(id);
            try
            {
                return View(member);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var member = SeedData.GetMemberById(id);
            try
            {
                SeedData.Members.Remove(member);
                return RedirectToAction("Index");
            }
            catch
            {
                var members = SeedData.Members;
                return View(members);
            }
        }
    }
}
