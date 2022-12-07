using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebTestAppBank.Data;
using WebTestAppBank.Models;

namespace WebTestAppBank.Controllers
{
    public class ATMController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cassets(int valCassets)
        {
            Casset[] cassets = new Casset[valCassets];

            for (int i = 0; i < valCassets; i++)
                cassets[i] = new Casset()
                {
                    ID = i
                };

            if (DatabaseBank.Cassets.Count == 0)
                DatabaseBank.Cassets.Add(1, cassets);
            else
            {
                DatabaseBank.Cassets.Clear();
                DatabaseBank.Cassets.Add(1, cassets);
            }

            return View(cassets);
        }

        [HttpGet]
        public IActionResult Cassets()
        {
            if (DatabaseBank.Cassets.Count != 0)
                return View(DatabaseBank.Cassets[1]);

            return View("Index");
        }

        [HttpGet]
        public IActionResult Withdrawal()
        {
            if (DatabaseBank.Cassets.Count != 0)
                return View();

            return View("Index");
        }

        [HttpGet]
        public IActionResult NeedNominals(Int32 amount)
        {
            RewriteBackupCassets();
            bool withdrawalIsValid = true;
            long time = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Dictionary<int, int> needNominals = GetNeedNominals(amount);

            stopwatch.Stop();

            if (needNominals.Count == 0)
                return RedirectToAction("NotFoundBanknotesError", "Errors");

            withdrawalIsValid = CheckWithdrawal(ref needNominals, amount);
            if (withdrawalIsValid == false)
            {
                UploadBackupCassets();

                return RedirectToAction("WithdrawalError", "Errors");
            }

            RewriteBackupCassets();

            time = stopwatch.ElapsedMilliseconds;
            ViewBag.CalcTime = time;

            return View(needNominals);
        }

        private void RewriteBackupCassets()
        {
            string jsonCassetsBackup = JsonConvert.SerializeObject(DatabaseBank.Cassets[1], Formatting.Indented);
            System.IO.File.WriteAllText("CassetsBackup.json", jsonCassetsBackup);
        }

        private void UploadBackupCassets()
        {
            string jsonCassetsBackup = System.IO.File.ReadAllText("CassetsBackup.json");
            DatabaseBank.Cassets[1] = JsonConvert.DeserializeObject<Casset[]>(jsonCassetsBackup);
        }

        private Dictionary<int, int> GetNeedNominals(Int32 amount)
        {
            Dictionary<int, int> needNominals = new Dictionary<int, int>();
            Int32 availableBank = GetAvailableBank(DatabaseBank.Cassets[1]);

            if (availableBank >= amount)
                Withdrawal(ref needNominals, ref availableBank, amount);

            return needNominals;
        }

        public void Withdrawal(ref Dictionary<int, int> needNominals, ref Int32 availableBank, Int32 amount)
        {
            Int32 needMoney = amount;
            bool resultFindBanknote = true;

            while (needMoney != 0 && availableBank != 0 && resultFindBanknote != false)
                resultFindBanknote = FindBanknote(ref needNominals, ref availableBank, ref needMoney);
        }

        public bool FindBanknote(ref Dictionary<int, int> needNominals, ref Int32 availableBank, ref Int32 searchedValue)
        {
            int maxBanknote = 0, numOfCasset = 0, banknote = 0;
            int i, n;
            bool result = false;
            Dictionary<int, int> nominals;


            for (i = 0; i < DatabaseBank.Cassets[1].Length; i++)
            {
                if (DatabaseBank.Cassets[1][i].IsActive)
                {
                    nominals = DatabaseBank.Cassets[1][i].Nominals;

                    for (n = 0; n <= DatabaseBank.Banknotes.Length - 1; n++)
                    {
                        banknote = DatabaseBank.Banknotes[n];

                        if (nominals.ContainsKey(banknote) && nominals[banknote] > 0)
                        {
                            if (banknote > maxBanknote && banknote <= searchedValue)
                            {
                                numOfCasset = i;
                                maxBanknote = banknote;
                                result = true;
                            }
                            else if (banknote == maxBanknote && banknote <= searchedValue)
                            {
                                numOfCasset = i;
                                result = true;
                            }
                        }
                    }
                }
            }

            if (BanknoteIsFound(ref maxBanknote))
            {
                DeleteBanknoteInCasset(ref numOfCasset, ref maxBanknote);
                AddNeedBanknote(ref needNominals, ref maxBanknote);

                availableBank -= maxBanknote;
                searchedValue -= maxBanknote;
            }

            return result;
        }

        private bool BanknoteIsFound(ref int maxBanknote)
        {
            if (maxBanknote != 0)
                return true;
            else
                return false;
        }

        private void DeleteBanknoteInCasset(ref int numOfCasset, ref int maxBanknote)
        {
            DatabaseBank.Cassets[1][numOfCasset].Nominals[maxBanknote] -= 1;
            DatabaseBank.Cassets[1][numOfCasset].Sum -= maxBanknote;
        }

        private void AddNeedBanknote(ref Dictionary<int, int> needNominals, ref int maxBanknote)
        {
            if (needNominals.ContainsKey(maxBanknote))
                needNominals[maxBanknote] += 1;
            else
                needNominals.Add(maxBanknote, 1);
        }

        public Int32 GetTotalBank(Casset[] cassetsInATM)
        {
            Int32 bank = 0;

            for (int i = 0; i < cassetsInATM.Length; i++)
                bank += cassetsInATM[i].Sum;

            return bank;
        }

        public Int32 GetAvailableBank(Casset[] cassetsInATM)
        {
            Int32 bank = 0;

            for (int i = 0; i < cassetsInATM.Length; i++)
                if (cassetsInATM[i].IsActive)
                    bank += cassetsInATM[i].Sum;

            return bank;
        }

        private bool CheckWithdrawal(ref Dictionary<int, int> needNominals, Int32 amount)
        {
            Int32 sum = 0, _amount = amount;

            foreach (var item in needNominals)
                sum += item.Key * item.Value;

            if (sum < _amount)
                return false;

            return true;
        }
    }
}
