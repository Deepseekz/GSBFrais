using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gsbFraisTests
{
    [TestClass()]
    class ficheFraisRowTests
    {
        gsb_fraisDataSet Ds = new gsb_fraisDataSet();
        outils_bd.BdMySQL Bd;
        [TestMethod()]
        public void ActualiserMontantValideTest()
        {
            Bd = new BdMysSql(Ds, "server=localhost;user id=gsb_frais;password=root;database=gsb_frais");
            Bd.getData("fichefrais", "idVisiteurs='a131' and mois='202001'");
            fichefraisRow fiche = Ds.fichefrais[0];
            fiche.actualiserMontantValide();
            Assert.AreEqual(13601.44m, fiche.montantValide);
        }
    }
}
