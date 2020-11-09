using Microsoft.VisualStudio.TestTools.UnitTesting;
using outils_bd;
using static gsbFrais.gsb_fraisDataSet;

namespace gsbFrais.Tests
{
    [TestClass()]
    public class fichefraisRowTests
    {
        gsb_fraisDataSet Ds = new gsb_fraisDataSet();
        BdMySQL bd;
        [TestMethod()]
        public void actualiserMontantValideTest()
        {
            bd = new BdMySQL(Ds, "server=localhost;user id=root;password=root;persistsecurityinfo=True;database=gsb_frais");
            bd.getData("fichefrais", "idVisiteur = 'a131' and mois = '202001'");
            bd.getData("lignefraisforfait", "idVisiteur = 'a131' and mois = '202001'");
            bd.getData("lignefraishorsforfait", "idVisiteur = 'a131' and mois = '202001'");
            bd.getData("fraisforfait");

            fichefraisRow fiche = Ds.fichefrais[0]; 

            Assert.AreEqual(3459.43m, fiche.montantValide);
        }
    }
}