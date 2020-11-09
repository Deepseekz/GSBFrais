using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static gsbFrais.gsb_fraisDataSet;

namespace gsbFrais
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void visiteurBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.visiteurBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gsb_fraisDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'gsb_fraisDataSet.etat'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.etatTableAdapter.Fill(this.gsb_fraisDataSet.etat);
            // TODO: cette ligne de code charge les données dans la table 'gsb_fraisDataSet.fraisforfait'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.fraisforfaitTableAdapter.Fill(this.gsb_fraisDataSet.fraisforfait);
            // TODO: cette ligne de code charge les données dans la table 'gsb_fraisDataSet.lignefraishorsforfait'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.lignefraishorsforfaitTableAdapter.Fill(this.gsb_fraisDataSet.lignefraishorsforfait);
            // TODO: cette ligne de code charge les données dans la table 'gsb_fraisDataSet.lignefraisforfait'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.lignefraisforfaitTableAdapter.Fill(this.gsb_fraisDataSet.lignefraisforfait);
            // TODO: cette ligne de code charge les données dans la table 'gsb_fraisDataSet.fichefrais'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.fichefraisTableAdapter.Fill(this.gsb_fraisDataSet.fichefrais);
            // TODO: cette ligne de code charge les données dans la table 'gsb_fraisDataSet.visiteur'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.visiteurTableAdapter.Fill(this.gsb_fraisDataSet.visiteur);

            InitialiseEtat();
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            visiteurBindingSource.Filter = "nom LIKE '" + txtNom.Text +"%'";
        }

        private void tslTotalFrais_Click(object sender, EventArgs e)
        {
            DataRowView RowView = fichefraisBindingSource.Current as DataRowView;
            fichefraisRow fiche = RowView.Row as fichefraisRow;
            fiche.actualiserMontantValide();
        }

        private void InitialiseEtat()
        {
            foreach(DataRowView ligne in etatBindingSource.List)
            {
                etatRow etat = ligne.Row as etatRow;
                cbxFiltreEtat.Items.Add(etat);
            }
        }

        private void cbxFiltreEtat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtre = "";
            if (cbxFiltreEtat.SelectedItem != null)
            {
                etatRow etat = cbxFiltreEtat.SelectedItem as etatRow;
                filtre = "idEtat LIKE '" + etat.id + "'";
            }                  
            fichefraisBindingSource.Filter = filtre;
        }

    }
}
