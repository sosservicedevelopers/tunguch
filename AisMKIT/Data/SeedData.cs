using AisMKIT.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.DictRegion.Any())
            {
                context.DictRegion.Add(new DictRegion() {NameRus="Чуй",NameKyrg= "Чуй" });
                context.DictRegion.Add(new DictRegion() { NameRus = "Иссык-Куль", NameKyrg = "Иссык-Куль" });
                context.DictRegion.Add(new DictRegion() { NameRus = "Ош", NameKyrg = "Ош" });
                context.DictRegion.Add(new DictRegion() { NameRus = "Джалал-Абад", NameKyrg = "Джалал-Абад" });
                context.DictRegion.Add(new DictRegion() { NameRus = "Талас", NameKyrg = "Талас" });
                context.DictRegion.Add(new DictRegion() { NameRus = "Нарын", NameKyrg = "Нарын" });
                context.DictRegion.Add(new DictRegion() { NameRus = "Баткен", NameKyrg = "Баткен" });
                context.DictRegion.Add(new DictRegion() { NameRus = "г. Бишкек", NameKyrg = "г. Бишкек" });
                context.DictRegion.Add(new DictRegion() { NameRus = "г. Ош", NameKyrg = "г. Ош" });
            }
            if (!context.DictDistrict.Any())
            {
                context.DictDistrict.Add(new DictDistrict() {NameKyrg="Аламедин", NameRus="Аламедин", City="", DictRegionId=1 });
                context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Сокулук", NameRus = "Сокулук", City = "", DictRegionId = 1 });
                context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Тон", NameRus = "Тон", City = "", DictRegionId = 2 });
                context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Иссыккульский", NameRus = "Иссыккульский", City = "", DictRegionId = 2 });
                context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Кара-Суйский", NameRus = "Кара-Суйский", City = "", DictRegionId = 3 });
                context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Узгенский", NameRus = "Узгенский", City = "", DictRegionId = 3 });
                context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Сузакский", NameRus = "Сузакский", City = "", DictRegionId = 4 });
                context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Чаткальский", NameRus = "Чаткальский", City = "", DictRegionId = 4 });
                //context.DictDistrict.Add(new DictDistrict() { NameKyrg = "", NameRus = "", City = "", DictRegionId = 1 });
                //context.DictDistrict.Add(new DictDistrict() { NameKyrg = "", NameRus = "", City = "", DictRegionId = 1 });
                //context.DictDistrict.Add(new DictDistrict() { NameKyrg = "", NameRus = "", City = "", DictRegionId = 1 });
            }
            if (!context.DictFinSource.Any())
            {
                context.DictFinSource.Add(new DictFinSource() { NameRus="Государственное", NameKyrg= "Государственное", CreateDate=DateTime.Now, DictStatusId=1});
                context.DictFinSource.Add(new DictFinSource() { NameRus = "Коммерческое", NameKyrg = "Коммерческое", CreateDate = DateTime.Now, DictStatusId = 1 });
                context.DictFinSource.Add(new DictFinSource() { NameRus = "Муниципиальное", NameKyrg = "Муниципиальное", CreateDate = DateTime.Now, DictStatusId = 1 });

            }
            if (!context.DictMediaLangType.Any())
            {
                context.DictMediaLangType.Add(new DictMediaLangType() {NameRus="Кыргызское", NameKyrg= "Кыргызское", DictStatusId=1, CreateDate=DateTime.Now});
                context.DictMediaLangType.Add(new DictMediaLangType() { NameRus = "Русское", NameKyrg = "Русское", DictStatusId = 1, CreateDate = DateTime.Now });
                context.DictMediaLangType.Add(new DictMediaLangType() { NameRus = "Смешанное", NameKyrg = "Смешанное", DictStatusId = 1, CreateDate = DateTime.Now });
            }
            if (!context.DictMediaControlResult.Any())
            {
                context.DictMediaControlResult.Add(new DictMediaControlResult() {NameKyrg= "Без нарушений", NameRus= "Без нарушений", DictStatusId=1, CreateDate=DateTime.Now});
                context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "Вынесено предупреждение", NameRus = "Вынесено предупреждение", DictStatusId = 1, CreateDate = DateTime.Now });
                context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "Наложен штраф", NameRus = "Наложен штраф", DictStatusId = 1, CreateDate = DateTime.Now });
                context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "Отзыв разрешения", NameRus = "Отзыв разрешения", DictStatusId = 1, CreateDate = DateTime.Now });
            }
            if (!context.DictMediaControlResult.Any())
            {
                context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "", NameRus = "", DictStatusId = 1, CreateDate = DateTime.Now });
                context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "", NameRus = "", DictStatusId = 1, CreateDate = DateTime.Now });
            }
            if (!context.DictMediaControlResult.Any())
            {
                context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "", NameRus = "", DictStatusId = 1, CreateDate = DateTime.Now });
                context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "", NameRus = "", DictStatusId = 1, CreateDate = DateTime.Now });
            }

            if (!context.DictStatus.Any())
            {
                context.DictStatus.Add(new DictStatus() { Name = "Активное" });
                context.DictStatus.Add(new DictStatus() { Name = "Неактивное" });
            }

            if (!context.DictLegalForm.Any())
            {
                context.DictLegalForm.Add(new DictLegalForm() {NameRus="Государственное",NameKyrg= "Государственное", DictStatusId=1, CreateDate=DateTime.Now});
                context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Частное", NameKyrg = "Частное", DictStatusId = 1, CreateDate = DateTime.Now });
            }

            if (!context.DictMediaType.Any())
            {
                context.DictMediaType.Add(new DictMediaType() {NameKyrg= "Печатное периодическое издание", NameRus= "Печатное периодическое издание", CreateDate=DateTime.Now, DictStatusId=1});
                context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Печатное разовое издание", NameRus = "Печатное разовое издание", CreateDate = DateTime.Now, DictStatusId = 1 });
                context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Телеканал", NameRus = "Телеканал", CreateDate = DateTime.Now, DictStatusId = 1 });
                context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Оператор телевещания", NameRus = "Оператор телевещания", CreateDate = DateTime.Now, DictStatusId = 1 });
                context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Радиоканал", NameRus = "Радиоканал", CreateDate = DateTime.Now, DictStatusId = 1 });
                context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Оператор радиовещания", NameRus = "Оператор радиовещания", CreateDate = DateTime.Now, DictStatusId = 1 });
                context.SaveChanges();
            }
        }
    }
}
