// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
using Newtonsoft.Json;
using System;

// Models for types defined by Schema.org
// http://schema.org

namespace OutlookPayments.Models
{
    // http://schema.org/Invoice
    public class Invoice
    {
        [JsonProperty(PropertyName = "@type")]
        public string Type { get { return "Invoice"; } }
        [JsonProperty(PropertyName = "@context")]
        public string Context { get { return "http://schema.org"; } }
        public string Identifier { get; set; }
        public string Url { get; set; }
        public LocalBusiness Broker { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string PaymentStatus { get; set; }
        public PriceSpecification TotalPaymentDue { get; set; }
        public string ConfirmationNumber { get; set; }
    }

    // http://schema.org/LocalBusiness
    public class LocalBusiness
    {
        [JsonProperty(PropertyName = "@type")]
        public string Type { get { return "LocalBusiness"; } }
        public string Name { get; set; }
    }

    // http://schema.org/PriceSpecification
    public class PriceSpecification
    {
        [JsonProperty(PropertyName = "@type")]
        public string Type { get { return "PriceSpecification"; } }
        public double Price { get; set; }
        public string PriceCurrency { get; set; }
    }
}