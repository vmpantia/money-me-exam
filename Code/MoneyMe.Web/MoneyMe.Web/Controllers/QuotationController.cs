using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.Net.Http;
using System.Net;
using System.Text;
using System;
using MoneyMe.Web.Models.Requests;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using MoneyMe.Web.Models.Views;

namespace MoneyMe.Web.Controllers
{
    public class QuotationController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new QuotationViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> QuoteCal(Guid quotationID)
        {
            try
            {
                var httpClient = new HttpClient();
                var httpResponse = await httpClient.GetAsync("https://localhost:7176/Quotation/GetQuotationByID?quotationID=" + quotationID.ToString());

                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return View("Error", new ErrorViewModel
                    {
                        RequestId = await httpResponse.Content.ReadAsStringAsync()
                    });
                }

                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveQuotation(QuotationViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            try
            {
                var data = new StringContent(JsonConvert.SerializeObject(new SaveQuotationRequest
                {
                    AmountRequired = model.Amount,
                    Term = model.Term,
                    Title = model.Title,
                    FirstName = model.FirstName,
                    LastName = model.LastName, 
                    DateOfBirth = model.DateOfBirth,
                    Mobile = model.Mobile,
                    Email = model.Email
                }), Encoding.UTF8, "application/json");

                var httpClient = new HttpClient();
                var httpResponse = await httpClient.PostAsync("https://localhost:7176/Quotation/SaveQuotation", data);

                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return View("Error", new ErrorViewModel
                    {
                        RequestId = await httpResponse.Content.ReadAsStringAsync()
                    });
                }

                var result = await httpResponse.Content.ReadAsStringAsync();
                var url = "https://localhost:7176/Quotation" + result;
                return Redirect(url);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ComputeQuotation(QuotationViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            try
            {
                var data = new StringContent(JsonConvert.SerializeObject(new SaveQuotationRequest
                {
                    AmountRequired = model.Amount,
                    Term = model.Term,
                    Title = model.Title,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Mobile = model.Mobile,
                    Email = model.Email
                }), Encoding.UTF8, "application/json");

                var httpClient = new HttpClient();
                var httpResponse = await httpClient.PostAsync("https://localhost:7176/Quotation/SaveQuotation", data);

                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    return View("Error", new ErrorViewModel
                    {
                        RequestId = await httpResponse.Content.ReadAsStringAsync()
                    });
                }

                var result = await httpResponse.Content.ReadAsStringAsync();
                var url = "https://localhost:7176/Quotation" + result;
                return Redirect(url);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = ex.Message
                });
            }
        }
    }
}
