using BeautyLand.Application.Services.Site.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ZarinPal.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyLand.SiteEndPoint.Claims.UserClaim;
using Dto.Payment;
using RestSharp;
using MongoDB.Bson.IO;

namespace BeautyLand.SiteEndPoint.Controllers
{
    public class PayController : Controller
    {
        public readonly IConfiguration _configuration;
        private readonly IPaymentService _paymentService;
        public readonly string _merchantId;

        //کلاس های درگاه پرداخت زرین پال
        private readonly Payment _payment;
        public readonly Authority _authority;
        public readonly Transactions _transactions;
        public PayController(IConfiguration configuration, IPaymentService paymentService)
        {
            _configuration = configuration;
            _paymentService = paymentService;
            _merchantId = configuration["ZarinpalMerchantId"];

            //پیاده سازی کلاس های درگاه پرداخت زرین پال
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();

        }
        public async Task<IActionResult> Index(Guid paymentId)
        {
            var payment = _paymentService.CreateGetPaymentOrder(paymentId);
            if (payment == null)
            {
                return NotFound();
            }

            var userId = UserClaim.GetUserId(User);
            if (userId != payment.UserId)
            {
                return BadRequest();
            }
            var callBackUrl = Url.Action("Verify", "Pay", new { paymentId = payment.Id, userId = userId }, Request.Scheme);
            var zarinpalRequest = await _payment.Request(new DtoRequest
            {
                Amount = payment.Amount,
                CallbackUrl = callBackUrl,
                Description = payment.Description,
                Email = payment.Email,
                MerchantId = _merchantId,
                Mobile = payment.PhoneNumber
            }, Payment.Mode.sandbox);
            return Redirect($"https://zarinpal.com/pg/StartPay/{zarinpalRequest.Authority}");
        }

        public IActionResult Verify(Guid paymentId, string userId, string authority, string status)
        {
            if (status != "" && status.ToLower().ToString() == "ok" && authority != "")
            {
                var payment = _paymentService.CreateGetPaymentOrder(paymentId);
                if (payment == null)
                {
                    return NotFound();
                }
                //  مورد نطر ارسال نکرده   API   به درستی داده ره به  verification متد 
                //var paymentVerifiation = _payment.Verification(new DtoVerification
                //{
                //Amount = payment.Amount,
                //Authority = authority,
                //MerchantId = _merchendId
                //}, Payment.Mode.sandbox);
                // پس

                var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
                var request = new RestRequest("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", $"{{\"MerchantID\" :\"{_merchantId}\",\"Authority\":\"{authority}\",\"Amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
                var response = client.Execute(request);
                PaymentVerificationDto verification = Newtonsoft.Json.JsonConvert.DeserializeObject<PaymentVerificationDto>(response.Content);
                if (verification.Status == 100)
                {
                    TempData["message"] = "پرداخت انجام شد";
                    return RedirectToAction("SuccessedPayment", "UserOrder", new { area = "Customers", userId = userId  });
                }
                else
                {
                    TempData["message"] = "پرداخت انجام شد اما ثبت نشد";
                    return RedirectToAction("Checkout", "Basket", new { pay = paymentId });
                }
            }
            else
            {
                TempData["message"] = "پرداخت شما ناموفق بوده است .";
                return RedirectToAction("FailedPayment", "UserOrder", new { area = "Customers" , userId = userId });
            }
        }
    }
}

