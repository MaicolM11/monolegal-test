using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using backend.Models;
using backend.Models.ModelView;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class BillController : Controller {

        private static string mailOrigin = "monolegaltest@gmail.com";
        private static string password = "monolegal123";

        private IBillCollection collection = new BillCollection ();

        [HttpGet]
        public async Task<IActionResult> getAll () {
            return Ok (await getReplace());
        }

        private async Task<List<BillView>> getReplace () {
            List<Bill> l1 = await collection.GetAllBills ();

            List<BillView> l2 = new List<BillView> ();

            foreach (Bill i in l1) {
                Client c = await ClientController.collection.GetClientById (i.Client);
                l2.Add (new BillView (){ Id = i.Id.ToString (), Location = i.Location, Total = i.Total, Subtotal= i.Subtotal, Iva = i.Iva, Retention = i.Retention, 
                                       CreateAt = i.CreateAt, State = i.State.ToString (),IsPaid= i.IsPaid, PaymentDate = i.PaymentDate, NameClient= c.Name, Nit = c.Nit
                                      }
                        );
            }
            return l2;
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> getById (string id) {
            return Ok (await collection.GetBillById (id));
        }

        [HttpPost]
        public async Task<IActionResult> createBill ([FromBody] Bill bill) {
            await collection.InsertBill (bill);
            return Created ("Created", true);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> updateBill (string id) {
            Bill b = await collection.GetBillById (id);

            if (b.State != TypeState.desactivado) {
                b.State++;
                sendEmail (b.CreateAt, b.State - 1, b.State, ClientController.collection.GetClientById (b.Client).Result); //avisar al corrreo del cliente
                await collection.UpdateBill (b);
                return Created ("Update", true);
            }

            return Created ("Update", false);
        }

        private void sendEmail (DateTime createAt, TypeState stateI, TypeState stateF, Client client) {

            string mssg = String.Format ("Hola <b>{0}</b>. <br><br> Se le informa que la factura realizada el {1} a las {2} ha cambiado de estado <b>{3}</b> a <b>{4}</b>. <br><br>Gracias. <br><br>Monolegal SAS.",
                client.Name, createAt.ToString ("d"), createAt.ToString ("hh:mm tt"), stateI.ToString (), stateF.ToString ());
            MailMessage mail = new MailMessage (mailOrigin, client.Email, "Cambio estado de factura", mssg);
            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient ("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential (mailOrigin, password);
            smtpClient.Send (mail);
            smtpClient.Dispose ();

        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> deleteBill (string id) {
            await collection.DeleteBill (id);
            return NoContent (); // success
        }

    }
}