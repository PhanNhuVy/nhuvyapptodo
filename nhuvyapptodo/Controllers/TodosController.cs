﻿using nhuvyapptodo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace nhuvyapptodo.Controllers
{
    public class TodosController : Controller
    {
        // GET: Todos
        public ActionResult Index()
        {
            List<Todo> todos = new List<Todo>()
            {
                new Todo(){Id = 1, Description = "Kill Bill", DueDate =  new DateTime(2008, 12, 20)},
                new Todo(){Id = 2, Description = "Kill Bill 2", DueDate =  new DateTime(2012, 1, 22)},
                new Todo(){Id = 3, Description = "John Wick", DueDate =  new DateTime(2020, 01, 22)}

            };
            return View(todos);
        }
    }
}