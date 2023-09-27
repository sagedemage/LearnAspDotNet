﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearnAspDotNet.Data;
using LearnAspDotNet.Models;
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Web;
using System.Collections.Specialized;

namespace LearnAspDotNet.Controllers
{
    public class WeathersController : Controller
    {
        private readonly WeatherContext _context;

        public WeathersController(WeatherContext context)
        {
            _context = context;
        }

        // GET: Weathers
        [Route("Weathers")]
        public async Task<IActionResult> Index()
        {
              return _context.Weather != null ? 
                          View(await _context.Weather.ToListAsync()) :
                          Problem("Entity set 'WeatherContext.Weather'  is null.");
        }

        // GET: Weathers/Details/5
        [Route("Weathers/Details/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Weather == null)
            {
                return NotFound();
            }

            var weather = await _context.Weather
                .FirstOrDefaultAsync(m => m.id == id);
            if (weather == null)
            {
                return NotFound();
            }

            return View(weather);
        }

        // GET: Weathers/Create
        [HttpGet]
        [Route("Weathers/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weathers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Weathers/Create1")]
        [Consumes("application/json")]
        public async Task<IActionResult> Create1([FromBody] Weather weather)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weather);
                await _context.SaveChangesAsync();
                var body = new { status = "Sucess", msg = "Created weather entry!" };
                return new JsonResult(body);
            }
            return View(weather);
        }

        // application/x-www-form-urlencoded
        [HttpPost]
        [Route("Weathers/Create")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> CreateForm()
        {
            IFormCollection form = Request.Form;
            string? status = form["status"];
            string? message = form["message"];

            if (status == null || message == null)
            {
                return NotFound();
            }

            Weather weather = new Weather();
            weather.Status = status;
            weather.Message = message;

            _context.Add(weather);
            await _context.SaveChangesAsync();

            return Redirect("/Weathers");
        }

        [HttpGet]
        [Route("Weathers/Fetch")]
        public async Task<IActionResult> Fetch([FromQuery(Name = "id")] int? id)
        {
            if (id == null || _context.Weather == null)
            {
                var body = new { msg = "The ID is null" };

                return new JsonResult(body);
            }

            var weather = await _context.Weather.FindAsync(id);
            if (weather == null)
            {
                var body = new { msg = "Weather does not exist" };

                return new JsonResult(body);
            }

            return new JsonResult(weather);
        }

        // GET: Weathers/Edit/5
        [HttpGet]
        [Route("Weathers/Edit")]
        public async Task<IActionResult> Edit([FromQuery(Name = "id")] int? id)
        {
            if (id == null || _context.Weather == null)
            {
                return NotFound();
            }

            var weather = await _context.Weather.FindAsync(id);
            if (weather == null)
            {
                return NotFound();
            }
            return View(weather);
        }

        // PATCH: Weathers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPatch]
        [Route("Weathers/Update")]
        [Consumes("application/json")]
        public async Task<IActionResult> Update([FromBody] Weather weather)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weather);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherExists(weather.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var body = new { status = "Sucess", msg = "Updated the weather entry!" };
                return new JsonResult(body);
            }
            return View(weather);
        }

        // GET: Weathers/Delete/5
        [Route("Weathers/Delete")]
        public async Task<IActionResult> Delete([FromQuery(Name = "id")] int? id)
        {
            if (id == null || _context.Weather == null)
            {
                return NotFound();
            }

            var weather = await _context.Weather
                .FirstOrDefaultAsync(m => m.id == id);
            if (weather == null)
            {
                return NotFound();
            }

            return View(weather);
        }

        // POST: Weathers/Delete/5
        [HttpDelete]
        [Route("Weathers/Delete")]
        public async Task<IActionResult> DeleteConfirmed([FromQuery(Name = "id")] int? id)
        {
            if (_context.Weather == null)
            {
                return Problem("Entity set 'WeatherContext.Weather'  is null.");
            }
            var weather = await _context.Weather.FindAsync(id);
            if (weather != null)
            {
                _context.Weather.Remove(weather);
            }
            
            await _context.SaveChangesAsync();

            var body = new { status = "Success", msg = "Deleted the weather entry!" };

            return new JsonResult(body);
        }

        private bool WeatherExists(int id)
        {
          return (_context.Weather?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
