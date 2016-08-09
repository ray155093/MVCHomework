using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCHomework.Models.ViewModels
{
    public class AddBalanceViewModel
    {
        /// <summary>
        ///  收支類型
        /// </summary>
        public enum EBalanceType : int
        {
            支出 = 1,
            收入 = 2
        }
        /// <summary>
        /// 收支類型
        /// </summary>
        [DisplayName("收支類型")]
        public EBalanceType BalanceType { get; set; }
        /// <summary>
        /// 紀錄金額
        /// </summary>
        [DisplayName("紀錄金額")]
        public int BalanceMoney { get; set; }
        /// <summary>
        /// 紀錄時間
        /// </summary>
        [DisplayName("紀錄時間")]
        public DateTime BalacneDateTime { get; set; }
        /// <summary>
        /// 紀錄備註
        /// </summary>
        [DisplayName("紀錄備註")]
        public string BalanceMemo { get; set; }
        /// <summary>
        /// 資料物件
        /// </summary>
        private static List<AddBalanceViewModel> oLists = new List<AddBalanceViewModel>();
       
        /// <summary>
        /// 建立測試資料
        /// </summary>
        public static void CreateDemoList()
        {
            AddBalanceViewModel a = new AddBalanceViewModel();
            a.BalanceType = EBalanceType.支出;
            a.BalanceMoney = 2000;
            a.BalacneDateTime = Convert.ToDateTime("2016/7/12");
            a.BalanceMemo = "買了電動遊戲";
            oLists.Add(a);
            AddBalanceViewModel b = new AddBalanceViewModel();
            b.BalanceType = EBalanceType.收入;
            b.BalanceMoney = 200;
            b.BalacneDateTime = Convert.ToDateTime("2016/7/25");
            b.BalanceMemo = "發票中獎";
            oLists.Add(b);

        }
        /// <summary>
        /// 取得資料
        /// </summary>
        /// <returns></returns>
        public static List<AddBalanceViewModel> GetDemoList()
        {
            if(oLists.Count==0)
            {
                CreateDemoList();
            }
            return oLists;
        }

        /// <summary>
        /// 增加資料
        /// </summary>
        /// <param name="oBalance"></param>
        public static void AddBalance(AddBalanceViewModel oBalance)
        {
            oLists.Add(oBalance);

        }

    }
}