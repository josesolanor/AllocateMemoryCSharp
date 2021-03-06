﻿using System;
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
using Core.Core;

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
            List<SelectListItem> listAlgorithms = new List<SelectListItem>
            {
                new SelectListItem { Value = AlgorithmsType.FirstFit, Text = AlgorithmsType.FirstFit },
                new SelectListItem { Value = AlgorithmsType.BestFit, Text = AlgorithmsType.BestFit },
                new SelectListItem { Value = AlgorithmsType.WorstFit, Text = AlgorithmsType.WorstFit },
                new SelectListItem { Value = AlgorithmsType.NextFit, Text = AlgorithmsType.NextFit }
            };
            ViewData["AlgorithmType"] = new SelectList(listAlgorithms, "Value", "Text");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBlocks()
        {
            var result = await _repository.GetAllMemoryBlocks();
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProcess(ProcessDTO process)
        {
            if (process.Size <= 0)
            {
                TempData["Msg"] = "Only positive number allowed";
                return RedirectToAction("Index");
            }

            var result = await _repository.AddProcessByAlgorithm(process);

            if (result)
            {
                TempData["Msg"] = "Added process";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "No space available";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> FreeProcess(ProcessDTO process)
        {
            var result = await _repository.FreeProcess(process);

            if (result)
            {
                TempData["Msg"] = "Released process";
                return RedirectToAction("Index");
            }
            TempData["Msg"] = "Something went very wrong :c";
            return RedirectToAction("Index");
        }
    }
}
