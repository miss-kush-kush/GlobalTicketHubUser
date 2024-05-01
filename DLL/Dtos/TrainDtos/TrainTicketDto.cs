using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class TrainTicketDto
    {
        public int Id { get; set; }

        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }

    }
}
