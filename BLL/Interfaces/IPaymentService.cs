﻿using DLL.Dtos.PaymentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentRequestDto> TicketPayment(BasicPaymentInfoDto basicPaymentInfoDto);
    }
}
