using GestionClient.Data;
using GestionClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GestionClient.Controllers
{
    public class ClientController : Controller
    {
        // Liste statique pour stocker les clients ajoutés
        private static List<Client> listClient = new List<Client>
        {
            new Client
            {
                Id = 1,
                Nom = "Qaroun",
                Prenom = "Mariame",
                Ville = "El jadida"
            }
        };
        private readonly ClientDbContext _dbClientContext;

         public ClientController(ClientDbContext dBClientContext)
        {
            _dbClientContext = dBClientContext;  
        }

        public IActionResult Index()
        {
            return View(_dbClientContext.Clients.ToList());
        }

        /*
           public IActionResult Index(int? id)
      {
          // Si un ID est fourni, on cherche le client correspondant pour l'édition
          if (id.HasValue)
          {
              var clientToEdit = listClient.FirstOrDefault(c => c.Id == id.Value);
              ViewBag.ClientToEdit = clientToEdit;
          }

          ViewBag.Clients = listClient;
          return View();
      }
         */

        [HttpPost]
        public IActionResult Save(Client client)
        {
            // Rechercher un client existant avec le même ID
            var existingClient = listClient.FirstOrDefault(c => c.Id == client.Id);

            if (existingClient != null)
            {
                // Mettre à jour les informations du client existant
                existingClient.Nom = client.Nom;
                existingClient.Prenom = client.Prenom;
                existingClient.Ville = client.Ville;
            }
            else
            {
                // Ajouter le nouveau client à la liste
                listClient.Add(client);
            }

            ViewBag.Clients = listClient;
            return View("Save", client);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var client = listClient.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                listClient.Remove(client);
            }

            return RedirectToAction("Index");
        }
    }
}
