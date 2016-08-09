using MVCHomework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHomework.Models;
using static MVCHomework.Models.ViewModels.AddBalanceViewModel;

namespace MVCHomework.Controllers
{
    public class BalanceController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 新增收支資料
        /// </summary>
        /// <param name="oBalance"></param>
        /// <returns></returns>
        [HttpPost]
        // GET: Balance
        public ActionResult Create(AddBalanceViewModel oBalance)
        {
            AccountBook oaccountBook = new AccountBook();
            oaccountBook.Categoryyy = Convert.ToInt16(oBalance.BalanceType) - 1;
            oaccountBook.Dateee = oBalance.BalacneDateTime;
            oaccountBook.Amounttt = oBalance.BalanceMoney;
            oaccountBook.Remarkkk = oBalance.BalanceMemo;
            oaccountBook.Id = Guid.NewGuid();
            var db = new SkillTreeHomeworkEntities();
            db.AccountBook.Add(oaccountBook);
            db.SaveChanges();
            List<AddBalanceViewModel> accountBooks = db.AccountBook
                .OrderByDescending(s => s.Dateee)
                .Take(10).Select(s => new AddBalanceViewModel
                {
                    BalanceType = (EBalanceType)(s.Categoryyy + 1),
                    BalanceMoney = s.Amounttt,
                    BalacneDateTime = s.Dateee,
                    BalanceMemo = s.Remarkkk
                }).ToList();
            return View();
        }
        /// <summary>
        /// 顯示收支清單
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult ShowDemoList()
        {
            var db = new SkillTreeHomeworkEntities();
            List<AddBalanceViewModel> accountBooks = db.AccountBook
                .OrderByDescending(s => s.Dateee)
                .Take(10).Select(s => new AddBalanceViewModel
                {
                    BalanceType = (EBalanceType)(s.Categoryyy + 1),
                    BalanceMoney = s.Amounttt,
                    BalacneDateTime = s.Dateee,
                    BalanceMemo = s.Remarkkk
                }).ToList();
            return View(accountBooks);
        }



    }
}