// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
using OutlookPayments.Helpers;
using OutlookPayments.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace OutlookPayments.Controllers
{
    public class InvoicesController : ApiController
    {
        private string[] supportedNetworks = { "visa", "mastercard", "amex" };
        private string[] supportedTypes = { "credit" };
        // POST /api/invoices
        public async Task<InvoicePayload> Post([FromBody]InvoicePayload incomingPayload)
        {
            // Validate the bearer token
            string actionPerformer = await TokenValidator.ValidateAuthorizationHeader(Request.Headers.Authorization);

            if (string.IsNullOrEmpty(actionPerformer))
            {
                throw new UnauthorizedAccessException();
            }

            // TODO: A real payment processor should validate that the action performer
            // matches the email address that the invoice was sent to

            // Get the event type
            string eventType = incomingPayload.MethodData[0].Data.Event;

            if (eventType == PayEvent.LoadEntity)
            {
                return CreateMockLoadEntityResponse(incomingPayload);
            }

            if (eventType == PayEvent.ShippingAddressChange)
            {
                return CreateMockShippingAddressResponse(incomingPayload);
            }

            if (eventType == PayEvent.ShippingOptionChange)
            {
                return CreateMockShippingOptionResponse(incomingPayload);
            }

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        private InvoicePayload CreateMockLoadEntityResponse(InvoicePayload payload)
        {
            // Returns a mock response
            // Typically this would be where you would retrieve the invoice details
            // from a database and build the response.
            // For our sample, the invoice ID is in the ProductContext as InvoiceId

            // Turn on "test" mode
            payload.MethodData[0].Data.Mode = "TEST";

            // Specify supported credit card networks
            payload.MethodData[0].Data.SupportedNetworks = supportedNetworks;
            payload.MethodData[0].Data.SupportedTypes = supportedTypes;

            // Add the schema.org Invoice entity
            payload.MethodData[0].Data.Entity = new Invoice()
            {
                Identifier = payload.MethodData[0].Data.ProductContext.InvoiceId,
                Url = "https://contoso.com/invoice",
                Broker = new LocalBusiness()
                {
                    Name = "Contoso"
                },
                PaymentDueDate = new DateTime(2019, 1, 31),
                PaymentStatus = PaymentStatus.PaymentDue,
                TotalPaymentDue = new PriceSpecification()
                {
                    Price = 10.00,
                    PriceCurrency = "USD"
                }
            };

            // Set the options
            payload.Options = new PaymentOptions()
            {
                RequestPayerEmail = true,
                RequestPayerName = true,
                RequestPayerPhone = true,
                RequestShipping = true,
                ShippingType = ShippingType.Shipping
            };

            // Set the details on what gets displayed

            payload.Details = new PaymentDetailsInit()
            {
                Id = payload.MethodData[0].Data.ProductContext.InvoiceId,
                DisplayItems = new List<PaymentItem>()
                {
                    new PaymentItem()
                    {
                        Label = "Large Widget",
                        Amount = new PaymentCurrencyAmount()
                        {
                            Currency = "USD",
                            Value = "7.00"
                        }
                    },
                    new PaymentItem()
                    {
                        Label = "Small Widget",
                        Amount = new PaymentCurrencyAmount()
                        {
                            Currency = "USD",
                            Value = "3.00"
                        }
                    },
                    new PaymentItem()
                    {
                        Label = "Shipping",
                        Amount = new PaymentCurrencyAmount()
                        {
                            Currency = "USD",
                            Value = "0.00"
                        },
                        // Set the total as pending since
                        // we've set to 0 as the default
                        Pending = true
                    }
                },
                Total = new PaymentItem
                {
                    Label = "Total Due",
                    Amount = new PaymentCurrencyAmount()
                    {
                        Currency = "USD",
                        Value = "10.00"
                    },
                    // Set the total as pending since
                    // it is not final until shipping is added
                    Pending = true
                }
            };

            return payload;
        }

        private InvoicePayload CreateMockShippingAddressResponse(InvoicePayload payload)
        {
            // Returns a mock response
            // This method is typically used for scenarios where you are collecting a shipping
            // address from the user as part of the pay experience. Here you could
            // dynamically update what shipping options are available based on the address.
            // For example, maybe "rush" delivery is only available in certain areas.

            // The address is provided in the ShippingAddress property

            // Add static shipping options
            payload.Details.ShippingOptions = new List<PaymentShippingOption>()
            {
                new PaymentShippingOption()
                {
                    Id = Shipping.NoRush,
                    Label = "Regular Shipping",
                    Amount = new PaymentCurrencyAmount()
                    {
                        Currency = "USD",
                        Value = "0.00"
                    },
                    Selected = true
                },
                new PaymentShippingOption()
                {
                    Id = Shipping.Priority,
                    Label = "Priority Shipping",
                    Amount = new PaymentCurrencyAmount()
                    {
                        Currency = "USD",
                        Value = "3.00"
                    }
                }
            };

            return payload;
        }

        private InvoicePayload CreateMockShippingOptionResponse(InvoicePayload payload)
        {
            // Returns a mock response
            // This method is typically used for scenarios where you are updating the
            // invoice based on shipping. For example, priority shipping may incur an
            // additional cost.

            // The shipping option selected is provided in the ShippingOption property

            string shippingOption = payload.ShippingOption;

            if (shippingOption == Shipping.Priority)
            {
                // If shipping is already present, just update it
                var shippingItem = payload.Details.DisplayItems.Find(i => i.Label.Equals("Shipping"));
                if (shippingItem != null)
                {
                    shippingItem.Amount = new PaymentCurrencyAmount()
                    {
                        Currency = "USD",
                        Value = "3.00"
                    };
                }
                else
                {
                    // Add a new item
                    payload.Details.DisplayItems.Add(new PaymentItem()
                    {
                        Label = "Shipping",
                        Amount = new PaymentCurrencyAmount()
                        {
                            Currency = "USD",
                            Value = "3.00"
                        }
                    });
                }

                // Update the invoice total
                payload.Details.Total.Amount.Value = "13.00";

                // Update the total in the Invoice entity
                payload.MethodData[0].Data.Entity.TotalPaymentDue.Price = 13.00;
            }
            else
            {
                // Regular shipping, set shipping line item to 0 and reset total
                var shippingItem = payload.Details.DisplayItems.Find(i => i.Label.Equals("Shipping"));
                if (shippingItem != null)
                {
                    shippingItem.Amount.Value = "0.00";
                }

                // Update total
                payload.Details.Total.Amount.Value = "10.00";

                // Update the total in the Invoice entity
                payload.MethodData[0].Data.Entity.TotalPaymentDue.Price = 10.00;
            }

            return payload;
        }
    }
}
