using MVCHomework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHomework.Controllers
{
    public class BalanceController : Controller
    {
        // GET: Balance
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 顯示收支清單
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult ShowDemoList()
        {
            List<AddBalanceViewModel> olists = AddBalanceViewModel.GetDemoList();
            return View(olists);
        }
        /// <summary>
        /// 新增收支資料
        /// </summary>
        /// <param name="oBalance"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBalance(AddBalanceViewModel oBalance)
        {
            AddBalanceViewModel.AddBalance(oBalance);
            List<AddBalanceViewModel> olists = AddBalanceViewModel.GetDemoList();
            return View(Create());
        }
    }
}