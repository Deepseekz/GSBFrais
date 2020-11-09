using System;

namespace gsbFrais
{


    partial class gsb_fraisDataSet
    {
        public partial class fichefraisRow
        {
            public void actualiserMontantValide()
            {
                decimal cumul = 0;
                foreach (lignefraisforfaitRow lffr in this.GetChildRows("lignefraisforfait_ibfk_1"))
                {
                    cumul += lffr.fraisforfaitRow.montant * lffr.quantite;
                }
                foreach (lignefraishorsforfaitRow lfhfr in this.GetChildRows("lignefraishorsforfait_ibfk_1"))
                {
                    cumul += lfhfr.montant;
                }
                this.montantValide = cumul;
                this.dateModif = DateTime.Today;
                this.idEtat = "CL";
            }
        }
    }
}
