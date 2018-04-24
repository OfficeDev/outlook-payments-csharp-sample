// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
namespace OutlookPayments.Models
{
    // The format for payloads to and from the Invoices endpoint
    public class InvoicePayload
    {
        public PaymentMethodData[] MethodData { get; set; }
        public PaymentOptions Options { get; set; }
        public PaymentDetailsInit Details { get; set; }
        public AddressInit ShippingAddress { get; set; }
        public string ShippingOption { get; set; }
    }

    // Our implementation of the data member
    // in the methodDetails of a payment request
    public class MethodDetails
    {
        public string Event { get; set; }
        public InvoiceContext ProductContext { get; set; }
        public string[] SupportedNetworks { get; set; }
        public string[] SupportedTypes { get; set; }
        public Invoice Entity { get; set; }
        public string Mode { get; set; }
    }

    // Our implementation of productContext
    // Only has one member, the invoice ID
    public class InvoiceContext
    {
        public string InvoiceId { get; set; }
    }
}