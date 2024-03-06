using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session05.Models.DataModels;
using System.Text.RegularExpressions;

namespace Session05.Controllers
{
    public class MemberManualController : Controller
    {
        public static readonly List<Member> members = new List<Member>();
        // GET: MemberManualController
        public ActionResult Index()
        {
            return View(members);
        }

        // GET: MemberManualController/Details/5
        public ActionResult Details(string id)
        {
            return View(members);
        }
       
        // GET: MemberManualController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: MemberManualController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            string msg = null;
            bool validate = true;
            if (member.Username.Length < 3 || member.Username.Length > 20)
            {
                msg = "<li>Tên đăng nhập phải có ký tự từ 3 đến 20 ký tự</li>";
                validate = false;
            }
            string patternemail = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
            if (!Regex.IsMatch(member.Email, patternemail))
            {
                msg += "<li>Email không đúng định dạng</li>";
                validate = false;
            }
            if (member.Birthday.AddYears(18) > DateTime.Now)
            {
                msg += "<li>Bạn chưa đủ 18 tuổi</li>";
                validate = false;
            }
            string patternphone = @"^[0-9]*$";
            if (!Regex.IsMatch(member.Phone, patternphone))
            {
                msg += "<li>Số điện thoại không hợp lệ</li>";
                validate = false;
            }
            if (validate == true)
            {
                member.MemberId = Guid.NewGuid().ToString();
                members.Add(member);
                return RedirectToAction("Index");
            }
            else 
            {
                msg += "<div class='alert alert-danger'>" + msg + "</div>";
                
            }
            ViewBag.msg = msg;
            return View(member);


        }

        // GET: MemberManualController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberManualController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MemberManualController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberManualController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
