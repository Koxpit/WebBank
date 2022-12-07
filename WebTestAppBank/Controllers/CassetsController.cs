using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTestAppBank.Data;
using WebTestAppBank.Models;

namespace WebTestAppBank.Controllers
{
    public class CassetsController : Controller
    {
        // GET: CasseetsController
        public ActionResult Index()
        {
            List<Casset> cassets = new List<Casset>();
            return View(cassets);
        }

        [HttpGet]
        public IActionResult Info(int cassetId)
        {
            Casset[] cassets = DatabaseBank.Cassets[1];

            return View(cassets[cassetId]);
        }

        [HttpGet]
        public IActionResult AddNominal(int cassetId)
        {
            ViewBag.Banknotes = DatabaseBank.Banknotes;
            Casset[] cassets = DatabaseBank.Cassets[1];
            Casset casset = cassets[cassetId];

            return View(casset);
        }

        [HttpPost]
        public IActionResult AddNominal(int cassetId, int banknote, int value)
        {
            bool nominalExist = DatabaseBank.Cassets[1][cassetId].Nominals.ContainsKey(banknote);

            if (nominalExist)
                DatabaseBank.Cassets[1][cassetId].Nominals[banknote] += value;
            else
                DatabaseBank.Cassets[1][cassetId].Nominals.Add(banknote, value);

            DatabaseBank.Cassets[1][cassetId].Sum += banknote * value;

            return RedirectToAction("Cassets", "ATM");
        }

        [HttpGet]
        public IActionResult ShowNominals(int cassetId)
        {
            string text = "";

            foreach (var nominal in DatabaseBank.Cassets[1][cassetId].Nominals)
                text += $"Banknote: { nominal.Key } - Value: { nominal.Value }; \n";

            ViewBag.Message = text;

            return PartialView(DatabaseBank.Cassets[1][cassetId]);
        }

        [HttpGet]
        public IActionResult SetActiveState(int cassetId)
        {
            if (DatabaseBank.Cassets[1][cassetId].IsActive)
                DatabaseBank.Cassets[1][cassetId].IsActive = false;
            else
                DatabaseBank.Cassets[1][cassetId].IsActive = true;

            return RedirectToAction("Cassets", "ATM");
        }
    }
}
