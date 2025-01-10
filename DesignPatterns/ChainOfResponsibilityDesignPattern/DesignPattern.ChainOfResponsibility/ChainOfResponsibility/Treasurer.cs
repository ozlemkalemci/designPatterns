using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if(req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount=req.Amount.ToString();
                customerProcess.Name=req.Name;
                customerProcess.Description="Para Çekme İşlemi Onaylandı. Müşteriye Talep Ettiği Tutar Ödendi.";
                customerProcess.EmployeeName = "Veznedar - Ayşe Çınar";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover !=  null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.Description = "Para Çekme Tutarı Veznedarın Günlük Çekme Limitini Aştığı İçin İşlem Şube Müdür Yardımcısına Yönlendirildi.";
                customerProcess.EmployeeName = "Veznedar - Ayşe Çınar";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
