using System.Web.Mvc;
using Signifly_Interview.Database.Storage;

namespace Signifly_Interview.Controllers
{
    public class BaseController : Controller
    {
        protected TeamStorage TeamStorage = TeamStorage.Instance;
    }
}