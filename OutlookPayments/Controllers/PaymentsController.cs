// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
using OutlookPayments.Helpers;
using OutlookPayments.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace OutlookPayments.Controllers
{
    public class PaymentsController : ApiController
    {
        // POST /api/payments
        public async Task<PaymentCompleteResponse> Post([FromBody] PaymentResponse payment)
        {
            // Validate the bearer token
            string actionPerformer = await TokenValidator.ValidateAuthorizationHeader(Request.Headers.Authorization);

            if (string.IsNullOrEmpty(actionPerformer))
            {
                throw new UnauthorizedAccessException();
            }

            // TODO: A real payment processor should validate that the action performer
            // matches the email address that the invoice was sent to

            // Parse the token
            PaymentToken parsedToken = new PaymentToken(payment.Details.PaymentToken);

            // The sample only supports test tokens
            if (!parsedToken.IsTestToken)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            // Check the format
            switch (parsedToken.Format.ToLower())
            {
                case "stripe":
                    return CreateMockStripePaymentResponse(parsedToken, payment);
                default:
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        private PaymentCompleteResponse CreateMockStripePaymentResponse(PaymentToken token, PaymentResponse payment)
        {
            // Returns a mock response
            // Typically you would use the Stripe API here to submit the payment
            // token for processing, then build your response based on the Stripe
            // API response.

            // Since we only handle test tokens, we can do simple
            // string compares for the values specified in
            // https://stripe.com/docs/testing#cards
            if (token.Payload == "tok_chargeDeclined")
            {
                return CreateMockCardDeclinedResponse(
                    payment.RequestId, payment.Details.ProductContext.InvoiceId,
                    payment.Details.Amount);
            }

            if (token.Payload == "tok_visa" ||
                token.Payload == "tok_mastercard" ||
                token.Payload == "tok_amex")
            {
                return new PaymentCompleteResponse()
                {
                    RequestId = payment.RequestId,
                    Details = "Thank you for paying your bill!",
                    Entity = new Invoice()
                    {
                        Identifier = payment.Details.ProductContext.InvoiceId,
                        Url = "https://contoso.com/invoice",
                        Broker = new LocalBusiness()
                        {
                            Name = "Contoso"
                        },
                        PaymentDueDate = new DateTime(2019, 1, 31),
                        PaymentStatus = PaymentStatus.PaymentComplete,
                        TotalPaymentDue = new PriceSpecification()
                        {
                            // Bill is paid so amount due is set to 0
                            Price = 0.00,
                            PriceCurrency = "USD"
                        },
                        ConfirmationNumber = "98765"
                    },
                    Result = PaymentResult.Success
                };
            }

            // Not one of the TEST mode cards, return invalid number error
            return new PaymentCompleteResponse()
            {
                RequestId = payment.RequestId,
                Details = "We were unable to charge your credit card.",
                Result = PaymentResult.Fail,
                Error = new PaymentCompleteError()
                {
                    Code = "card_error",
                    Message = "Card cannot be processed.",
                    Target = "stripeToken",
                    InnerError = new PaymentCompleteError()
                    {
                        Code = PaymentErrorCodes.InvalidNumber,
                        Message = "Sample expects test tokens only."
                    }
                }
            };
        }

        private PaymentCompleteResponse CreateMockCardDeclinedResponse(string requestId, string invoiceId, PaymentCurrencyAmount amount)
        {
            return new PaymentCompleteResponse()
            {
                RequestId = requestId,
                Details = "We were unable to charge your credit card.",
                Result = PaymentResult.Fail,
                Error = new PaymentCompleteError()
                {
                    Code = "card_error",
                    Message = "Card cannot be processed.",
                    Target = "stripeToken",
                    InnerError = new PaymentCompleteError()
                    {
                        Code = PaymentErrorCodes.CardDeclined,
                        Message = "Your credit card was declined."
                    }
                }
            };
        }
    }
}
