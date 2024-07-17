using DesingPattern.ChainofResponsibilty.DAL;
using DesingPattern.ChainofResponsibilty.Models;

namespace DesingPattern.ChainofResponsibilty.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProsessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 250000)
            {
                CustomerProsses customerProsses = new CustomerProsses();
                customerProsses.Amount = req.Amount.ToString();
                customerProsses.Name = req.Name;
                customerProsses.EmployeeName = "Şube Müdürü - Hatice Sarı";
                customerProsses.Description = "Para Çekme İşlemi Onaylandı, Müşteriye Talep Ettiği Tutar Ödendi";
                context.CustomerProsesses.Add(customerProsses);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProsses customerProsses = new CustomerProsses();
                customerProsses.Amount = req.Amount.ToString();
                customerProsses.Name = req.Name;
                customerProsses.EmployeeName = "Şube Müdürü - Hatice Sarı";
                customerProsses.Description = "Para Çekme Tutarı Şube Müdürünün Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Bölge Müdürüne Yönlendirildii";
                context.CustomerProsesses.Add(customerProsses);
                context.SaveChanges();
                NextApprover.ProsessRequest(req);
            }
        }
    }
}
