using AisMKIT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Components
{
    public class BestPhone : ViewComponent// ViewComponent
    {
        IRepository repo;
        public BestPhone(IRepository r)
        {
            repo = r;
        }

        public IViewComponentResult Invoke(int maxPrice)
        {
            // var items = repo.Where(p => p.Value <= maxPrice).ToList();
            var items = repo.GetPhones();
            return View("Phones", items);
        }
        //public string Invoke()
        //{
        //    var item = repo.GetPhones().OrderByDescending(x => x.Price).Take(1).FirstOrDefault();

        //    return $"Самый дорогой телефон: {item.Title}  Цена: {item.Price}";
        //}
    }
}
