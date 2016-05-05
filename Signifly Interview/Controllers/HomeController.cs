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

        #region Team

        public ActionResult Teams()
        {
            var viewModel = new TeamsViewModel { Teams = TeamStorage.GetTeams() };
            viewModel.AddTeamViewModel = new AddTeamViewModel();
            viewModel.AddTeamViewModel.Skills = TeamStorage.GetAvailableSkills().Select(
                s => new AddTeamSkill {Id = s.Id, Amt = 0, Name = s.Name}
            ).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddTeam(TeamsViewModel viewModel)
        {
            var id = TeamStorage.AddTeam(viewModel.AddTeamViewModel.ToTeam());

            foreach (var skill in viewModel.AddTeamViewModel.Skills)
            {
                TeamMemberStorage.AddMemberToTeamFromSkill(id, skill.Id, skill.Amt);   
            }

            return RedirectToAction("ShowTeam", "Home", new { id });
        }

        public ActionResult ShowTeam(int id)
        {
            var team = TeamStorage.GetTeam(id);
            if (team == null)
            {
                return HttpNotFound("No team found");
            }
            var viewModel = new ShowTeamViewModel {Team = team};

            return View(viewModel);
        }

        #endregion

        #region TeamMember

        public ActionResult TeamMember()
        {
            var viewModel = new TeamMemberViewModel {TeamMembers = TeamMemberStorage.GetTeamMembers()};

            return View(viewModel);
        }

        #endregion
    }
}