using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traversal.BusinessLayer.Abstract
{
    public interface IMailService
    {
        Task TSendReservationMail(string ToMail, string nameSurname, string tourTitle, int reservationCode, int personCount, decimal totalPrice);
    }
}
