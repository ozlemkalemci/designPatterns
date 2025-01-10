using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Manager:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.Description = "Para Çekme İşlemi Onaylandı. Müşteriye Talep Ettiği Tutar Ödendi.";
                customerProcess.EmployeeName = "Şube Müdürü - Hatice Sarı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.Description = "Para Çekme Tutarı Şube Müdürünün Günlük Çekme Limitini Aştığı İçin İşlem Bölge Müdürüne Yönlendirildi.";
                customerProcess.EmployeeName = "Şube Müdürü - Hatice Sarı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
