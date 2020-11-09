using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsbFrais
{
    public partial class FormConnexion : Form
    {
        public FormConnexion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// vérification identifiant / mot de passe sur base de données MySQL
        /// </summary>
        /// <returns>string : { message erreur | vide }</returns>
        private string erreurConnexion()
        {
            Dictionary<int, string> err_msgs = new Dictionary<int, string> {
            { 1042, "Serveur non disponible" },
            { 1044, "Accès non autorisé" },
            { 1045, "Utilisateur ou mot de passe erroné" },
    };
            string cs = Properties.Settings.Default.gsb_fraisConnectionString;
            cs += String.Format(";user id={0};password={1}", txtIdentifiant.Text, txtMotDePasse.Text);
            MySqlConnection msc = new MySqlConnection(cs);
            try
            {
                msc.Open();
                Properties.Settings.Default["gsb_fraisConnectionString"] = cs;
                return string.Empty;
            }
            catch (MySqlException ex)
            {
                // https://stackoverflow.com/questions/24899020/c-sharp-mysql-connector-number-always-0
                int err_no = ex.Number;
                if (err_no == 0 && (ex = ex.InnerException as MySqlException) != null)
                {
                    err_no = ex.Number;
                }
                if (err_msgs.ContainsKey(err_no))
                {
                    return err_msgs[err_no];
                }
                else
                {
                    return string.Format("erreur inconnue n°{0} !", err_no);
                }
            }
        }

        public void Connexion()
        {
            toolStripStatusLabel1.Text = erreurConnexion();
            if (erreurConnexion() == string.Empty)
            {
                Form1 monFormulaire = new Form1();
                monFormulaire.Show();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Connexion();
        }
    }
}
