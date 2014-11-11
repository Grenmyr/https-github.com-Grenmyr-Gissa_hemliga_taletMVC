using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GuessController : Controller
    {
        private NumberViewModel _nvm;

        public GuessController()
        {
             _nvm = new NumberViewModel();
             
        }
        //
        // GET: /Guess/
        public ActionResult Index()
        {

            return View(_nvm);
        }
        [HttpPost]
        public ActionResult Index(int Guess)
        {
            _nvm.MakeGuess(Guess);
            return View(_nvm);
        }
        [HttpPost]
        public ActionResult Create(int Guess)
        {
            
            return View();
        }
	}
}