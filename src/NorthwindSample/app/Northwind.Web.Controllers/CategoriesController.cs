using System.Linq;
using System.Web.Mvc;
using Northwind.Core;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Core.DomainModel;
using System.Collections.Generic;
using SharpArch.Data.NHibernate;
using SharpArch.Web.NHibernate;
using System;
using SharpArch.Core;
using NHibernate.Linq;

namespace Northwind.Web.Controllers
{
    [HandleError]
    public class CategoriesController : Controller
    {

        /// <summary>
        /// The transaction on this action is optional, but recommended for performance reasons
        /// </summary>
        [Transaction]
        public ActionResult Index()
        {
            IList<Category> categories = 
                NHibernateSession.Current.Linq<Category>().ToList();
            return View(categories);
        }

        /// <summary>
        /// The transaction on this action is optional, but recommended for performance reasons
        /// </summary>
        [Transaction]
        public ActionResult Show(int id)
        {
            Category category =
                NHibernateSession.Current.Linq<Category>()
                    .First(x => x.Id == id);
            return View(category);
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            Category category =
                NHibernateSession.Current.Linq<Category>()
                    .First(x => x.Id == id);
            NHibernateSession.Current.Delete(category);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// An example of creating an object with an auto incrementing ID.
        /// 
        /// Because this uses a declarative transaction, everything within this method is wrapped
        /// within a single transaction.
        /// </summary>
        [Transaction]
        [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]
        public ActionResult Create(string categoryName) {
            var category = new Category(categoryName);
            NHibernateSession.Current.SaveOrUpdate(category);
            return View(category);
        }
    }
}
