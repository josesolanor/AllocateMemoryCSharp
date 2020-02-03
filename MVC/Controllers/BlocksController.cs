using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Context;
using Core.Entities;
using Core.Interfaces;
using Core.Models;

namespace MVC.Controllers
{
    public class BlocksController : Controller
    {
        private readonly IRepository _repository;

        public BlocksController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBlocks()
        {
            var result = await _repository.GetAllMemoryBlocks();
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProcess(ProcessDTO process, string algorithm)
        {

            var result = await _repository.AddProcessByAlgorithm(process, algorithm);

            if (result)
            {
                TempData["ApiMsg"] = "Added process";
                return RedirectToAction("Index");
            }
            TempData["ApiMsg"] = "No space available";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> FreeProcess(ProcessDTO process)
        {
            var result = await _repository.FreeProcess(process);

            if (result)
            {
                TempData["ApiMsg"] = "Released process";
                return RedirectToAction("Index");
            }
            TempData["ApiMsg"] = "Something went very wrong :c";
            return RedirectToAction("Index");
        }
    }
}
