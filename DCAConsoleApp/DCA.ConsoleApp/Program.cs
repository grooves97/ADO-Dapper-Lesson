using DCA.DataAcces;
using DCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCA.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var receiversRepository = new ReceiversRepository())
            {
                var receiver = new Receiver
                {
                    FullName = "Мади Брок",
                    Address = "Астана, улица Фурманова"
                };
                receiversRepository.Add(receiver);
                var result = receiversRepository.GetAll().ToList();

                var receiverUpdate = new Receiver
                {
                    Id=result[0].Id,
                    FullName = "Мадди Бой",
                    Address = "Нур-Султан, улица Бараева"
                };
                receiversRepository.Update(receiverUpdate);
            }
        }
    }
}
