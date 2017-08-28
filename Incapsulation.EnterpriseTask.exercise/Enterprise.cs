using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.EnterpriseTask
{
    public class Enterprise
    {
        Guid guid;

        public Guid getGuid() { return guid; }

        public Enterprise(Guid guid)
        {
            this.guid = guid;
        }

        string name;

        public string getName() { return name; }

        public void setName(string name) { this.name = name; }

        string inn;

        public string getINN() { return inn; }

        public void setINN(string inn)
        {
            if (inn.Length != 10 || !inn.All(z => char.IsDigit(z)))
                throw new ArgumentException();
            this.inn = inn;
        }

        DateTime establishDate;

        public DateTime getEstablishDate()
        {
            return establishDate;
        }

        public void setEstablishDate(DateTime establishDate)
        {
            this.establishDate = establishDate;
        }

        public TimeSpan getActiveTimeSpan()
        {
            return DateTime.Now - establishDate;
        }

        public double getTotalTransactionsAmount()
        {
            DataBase.OpenConnection();
            var amount = 0.0;
            foreach (Transaction t in DataBase.Transactions().Where(z => z.EnterpriseGuid == guid))
                amount += t.Amount;
            return amount;
        }
    }
}
