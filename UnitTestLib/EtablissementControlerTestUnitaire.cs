using DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelAfpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAfpa2021.Controllers;

namespace UnitTestLib
{
    [TestClass]
    public class EtablissementControlerTestUnitaire
    {
        //[TestMethod]
        public void TestIndex()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AFPA_2020;Integrated Security=True;");

            DefaultContext dbContext = new DefaultContext(optionsBuilder.Options);
            EtablissementController controller = new EtablissementController(dbContext);

            var result = controller.Index();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = result as ViewResult;

            Assert.IsInstanceOfType(viewResult.Model, typeof(IEnumerable<Etablissement>));
            Assert.IsNotNull(viewResult.Model);
        }
        //[TestMethod]
        public void TestEtablissementController()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AFPA_2020;Integrated Security=True;");

            DefaultContext dbContext = new DefaultContext(optionsBuilder.Options);
            EtablissementController controller = new EtablissementController(dbContext);

            var result = controller.Edit("19011");
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = result as ViewResult;

            Assert.IsInstanceOfType(viewResult.Model, typeof(Etablissement));
            Etablissement query = dbContext.etablissements.Find("19011");
            Assert.IsNotNull(viewResult.Model);
            Assert.AreEqual(query, viewResult.Model as Etablissement);

            var result2 = controller.Edit(string.Empty);
            Assert.IsInstanceOfType(result2, typeof(ViewResult));
            ViewResult viewResult2 = result2 as ViewResult;

            Assert.IsNotInstanceOfType(viewResult2.Model, typeof(Etablissement));
            Assert.IsNull(viewResult2.Model);

            //Task<ViewResult> viewResult3 = result3 as Task<ViewResult>; 
            

        }

        [TestMethod]
        public void TestMethodeAsync ()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AFPA_2020;Integrated Security=True;");

            DefaultContext dbContext = new DefaultContext(optionsBuilder.Options);
            EtablissementController controller = new EtablissementController(dbContext);

            Etablissement etab = new Etablissement()
            {
                IdEtablissement = "82100",
                DesignationEtablissement = "Centre Afpa de Castelsarrasin",
                NumeroNomVoieEtablissement = "24 rue de Topiniaire",
                CodePostalEtablissement = "82100",
                VilleEtablissement = "Castelsarrasin",
                IdEtablissementRattachement = "82000"
            };

            var result3 = controller.Create(etab);
            Assert.IsInstanceOfType(result3, typeof(ViewResult));
            ViewResult viewResult = result3 as ViewResult;

            Assert.IsInstanceOfType(viewResult.Model, typeof(Etablissement));
            Assert.IsNotNull(viewResult.Model);
            Assert.AreEqual<Etablissement>(etab, viewResult.Model as Etablissement);
        }
    }
}
