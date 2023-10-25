using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _14E_TP2_A23.Data
{
    public class DAL
    {
        public MongoClient mongoDBClient;
        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
        }

        public List<Client> GetClients()
        {
            var Clients = new List<Client>();

            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                Clients = db.GetCollection<Client>("Clients").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return Clients;
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }

    }
}
