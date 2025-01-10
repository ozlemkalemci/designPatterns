using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class AreaDirector:Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 400000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.Description = "Para Çekme İşlemi Onaylandı. Müşteriye Talep Ettiği Tutar Ödendi.";
                customerProcess.EmployeeName = "Bölge Müdürü - Zeynep Yılmaz";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.Description = "Para Çekme Tutarı Bölge Müdürünün Günlük Çekme Limitini Aştığı İçin İşlem Gerçekleştirilemedi";
                customerProcess.EmployeeName = "Bölge Müdürü - Zeynep Yılmaz";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
