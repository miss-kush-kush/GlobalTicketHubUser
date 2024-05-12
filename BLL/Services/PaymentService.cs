using BLL.Interfaces;
using DLL.Dtos.PaymentDtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private static string privateKey = "sandbox_SRz3HHrXQahe2UQDHNYsrZFzPYiiZfCM6qGrNHaD";

        private static string ComputeSignature(string data)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                string toHash = privateKey + data + privateKey;
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(toHash));
                return Convert.ToBase64String(hashBytes);
            }
        }

        private static int GenerateUniqueId()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            Random random = new Random();
            int randomComponent = random.Next(1000, 9999);

            string uniqueIdStr = $"{timestamp}{randomComponent}";
            return int.Parse(uniqueIdStr.Substring(0, 9));
        }

        public async Task<PaymentRequestDto> TicketPayment(BasicPaymentInfoDto basicPaymentInfoDto)
        {
            return await Task.Run(() =>
            {
                int orderId = GenerateUniqueId();

                PaymentDataDto paymentData = new PaymentDataDto
                {
                    Amount = basicPaymentInfoDto.Amount,
                    Description = basicPaymentInfoDto.Description,
                    Order_id = orderId
                };

                string jsonPaymentData = JsonConvert.SerializeObject(paymentData);
                string data = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonPaymentData));
                string signature = ComputeSignature(data);

                return new PaymentRequestDto
                {
                    Data = data,
                    Signature = signature,
                    Order_id = orderId
                };
            });
        }

    }
}
