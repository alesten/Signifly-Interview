using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Signifly_Interview.ViewModels;

namespace Signifly_Interview.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teams()
        {
            var viewModel = new TeamsViewModel { Teams = TeamStorage.GetTeams() };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddTeam(TeamsViewModel viewModel)
        {
            TeamStorage.AddTeam(viewModel.AddTeamViewModel.ToTeam());

            return RedirectToAction("Teams");
        }
    }
}