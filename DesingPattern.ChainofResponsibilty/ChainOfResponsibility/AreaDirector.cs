using DesingPattern.ChainofResponsibilty.DAL;
using DesingPattern.ChainofResponsibilty.Models;

namespace DesingPattern.ChainofResponsibilty.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        public override void ProsessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 400000)
            {
                CustomerProsses customerProsses = new CustomerProsses();
                customerProsses.Amount = req.Amount.ToString();
                customerProsses.Name = req.Name;
                customerProsses.EmployeeName = "Bölge Direktörü - Zeynep Yılamz";
                customerProsses.Description = "Para Çekme İşlemi Onaylandı, Müşteriye Talep Ettiği Tutar Ödendi";
                context.CustomerProsesses.Add(customerProsses);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProsses customerProsses = new CustomerProsses();
                customerProsses.Amount = req.Amount.ToString();
                customerProsses.Name = req.Name;
                customerProsses.EmployeeName = "Bölge Direktörü - Zeynep Yılamz";
                customerProsses.Description = "Para Çekme Tutarı Bölge Direktörünün Günlük Ödeyebileceği Limiti Aştığı İçin İşlem Gerçekleştirilemedi , Müşterirnin Günlük Maksimum Çekebileceği Tutar 400.000 TL olup daha fazla için birden fazla şubeye gelmesi gerekli...";
                context.CustomerProsesses.Add(customerProsses);
                context.SaveChanges();
                NextApprover.ProsessRequest(req);
            }
        }
    }
}
