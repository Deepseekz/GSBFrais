using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace outils_bd
{
    /// <summary>
    /// communication avec une base de données MySQL
    /// </summary>
    public class BdMySQL
    {
        /// <summary>
        /// le dataset à charger
        /// </summary>
        public DataSet dataset { get; }

        /// <summary>
        /// la connexion à la base de données
        /// </summary>
        private MySqlConnection _connexion { get; }

        /// <summary>
        /// crée le dataset et ouvre la connexion à la base de données
        /// </summary>
        /// <param name="unDataset"></param>
        /// <param name="uneChaineConnexion"></param>
        public BdMySQL(DataSet unDataset, string uneChaineConnexion)
        {
            _connexion = new MySqlConnection(uneChaineConnexion);
            _connexion.Open();
            dataset = unDataset;
        }

        /// <summary>
        /// récupère les données d'une table de la BD (MySQL) et les place dans le DataSet
        /// </summary>
        /// <see>
        /// https://support.microsoft.com/en-us/help/314145/how-to-populate-a-dataset-object-from-a-database-by-using-visual-c--ne
        /// </see>
        /// <param name="uneTable">la table désirée</param>
        /// <param name="unSqlWhere">la clause WHERE à utiliser</param>
        /// <returns>objet DataAdapter correspondant à la table demandée</returns>
        public MySqlDataAdapter getData(string uneTable, string unSqlWhere = "true")
        {
            string sql = string.Format("select * from {0} where {1}", uneTable, unSqlWhere);
            MySqlDataAdapter da = new MySqlDataAdapter(sql, _connexion);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.FillSchema(dataset, SchemaType.Source, uneTable);
            da.Fill(dataset, uneTable);
            return da;
        }
    }
}
