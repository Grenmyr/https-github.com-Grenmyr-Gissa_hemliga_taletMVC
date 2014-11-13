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
        private NumberViewModel _numberViewModel;
     
        public GuessController()
        {
            _numberViewModel = new NumberViewModel(); 
        }
        public SecretNumber SecretNumberSession { get 
        {
          
            Session.Timeout = 1;
            return Session["secretNumber"] as SecretNumber ?? (SecretNumber)(Session["secretNumber"] = new SecretNumber());
        }
        }
     
    
        public ActionResult startover()
        {
            ModelState.AddModelError("errorMessage","Din session gick ut, spelet startades om");
            SecretNumberSession.Initialize();
            return RedirectToAction("Index");
        }
        //
        // GET: /Guess/
        public ActionResult Index()
        {
            _numberViewModel.SetSecretNumber = SecretNumberSession;
            return View(_numberViewModel);
        }

        [HttpPost]
        public ActionResult Index( NumberViewModel number)
        {
            if (Session.IsNewSession) 
            {
                ModelState.AddModelError("sessionerror", "SESSIONFEL Spelet startades om");
            }
            number.SetSecretNumber = SecretNumberSession;
            if (ModelState.IsValid)
            {
                try
                {
                    number.MakeGuess(number.Guess);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty,e.Message);
                }
                
            }
            return View(number);
        }
        
	}
}