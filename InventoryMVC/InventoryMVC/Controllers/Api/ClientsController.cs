using InventoryMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryMVC.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private MyDbContext _context;

        public ClientsController()
        {
            _context = new MyDbContext();
        }

        public IEnumerable<Clients> GetClients()
        {
            return _context.TableClients.ToList();
        }

        public Models.ViewModels.ClientViewModel GetClient(int id)
        {
            var client = _context.TableClients.SingleOrDefault(c => c.id == id);
            var clientOrders = _context.TableClientOrders.Where(c => c.ClientsId == id).Include(c => c.Items).ToList();
            var clientPayments = _context.TableClientPayments.Where(c => c.ClientsId == id).ToList();
            var viewModel = new Models.ViewModels.ClientViewModel
            {
                Client = client,
                ClientOrders = clientOrders,
                ClientPayments = clientPayments,
            };

            if (client == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            return viewModel;
        }

        [HttpPost]
        public Clients CreateClient(Clients clients)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.TableClients.Add(clients);
            _context.SaveChanges();
            return clients;
        }

        [HttpPut]
        public void UpdateClient(int id, Clients clients) {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var clientInDb = _context.TableClients.SingleOrDefault(c => c.id == id);
            if(clientInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            clientInDb.name = clients.name;
            clientInDb.address = clients.address;
            clientInDb.contact = clients.contact;
            clientInDb.balance = clients.balance;
            _context.SaveChanges();
        }
    }
}
