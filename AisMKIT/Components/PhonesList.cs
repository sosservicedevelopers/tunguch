using AisMKIT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Components
{
    public class PhonesList : ViewComponent
    {
        IRepository repo;
        public PhonesList(IRepository r)
        {
            repo = r;
        }
        public string Invoke(int maxPrice, int minPrice = 0)
        {
            int count = repo.GetPhones().Count(x => x.Price < maxPrice && x.Price > minPrice);

            return $"В диапазоне от {minPrice} до {maxPrice} найдено {count} модели(ей)";
        }
    }
}
