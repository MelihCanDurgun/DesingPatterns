using DesingPattern.ChainofResponsibilty.DAL;
using DesingPattern.ChainofResponsibilty.Models;

namespace DesingPattern.ChainofResponsibilty.ChainOfResponsibility
{
    public class ManagerAsistant : Employee
    {
        public override void ProsessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if(req.Amount<=150000)
            {
                CustomerProsses customerProsses = new CustomerProsses();
                customerProsses.Amount = req.Amount.ToString();
                customerProsses.Name = req.Name;
                customerProsses.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                customerProsses.Description = "Para Çekme İşlemi Onaylandı, Müşteriye Talep Ettiği Tutar Ödendi";
                context.CustomerProsesses.Add(customerProsses);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProsses customerProsses = new CustomerProsses();
                customerProsses.Amount = req.Amount.ToString();
                customerProsses.Name = req.Name;
                customerProsses.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                customerProsses.Description = "Para Çekme Tutarı Şube Müdür Yardımcısının Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Şube Müdürüne Yönlendirildii";
                context.CustomerProsesses.Add(customerProsses);
                context.SaveChanges();
                NextApprover.ProsessRequest(req);
            }   
        }
    }
}
