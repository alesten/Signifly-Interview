using System.Configuration;

namespace Signifly_Interview.Database.Storage
{
    public class BaseStorage
    {
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
    }
}
