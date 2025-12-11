using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebsiteGym.Web.Controllers
{
    public class BaseController : Controller
    {
        protected SessionWrapper Session
        {
            get { return new SessionWrapper(HttpContext.Session); }
        }
    }

    public class SessionWrapper
    {
        private readonly ISession _session;

        public SessionWrapper(ISession session)
        {
            _session = session;
        }

        public object this[string key]
        {
            get { return _session.GetString(key); }
            set { _session.SetString(key, value?.ToString() ?? ""); }
        }

        public void Clear()
        {
            _session.Clear();
        }

        public void Abandon()
        {
            _session.Clear();
        }
    }
}
