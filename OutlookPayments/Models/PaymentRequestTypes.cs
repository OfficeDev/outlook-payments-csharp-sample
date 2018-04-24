// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OutlookPayments.Models
{
    // Our implementation of details
    // in a PaymentResponse
    public class PaymentDetails
    {
        public InvoiceContext ProductContext { get; set; }
        public string PaymentToken { get; set; }
        public PaymentCurrencyAmount Amount { get; set; }
    }

    public class PaymentCompleteResponse
    {
        public string RequestId { get; set; }
        public string Result { get; set; }
        public string Details { get; set; }
        public PaymentCompleteError Error { get; set; }
        public Invoice Entity { get; set; }
    }

    public class PaymentCompleteError
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
        public List<PaymentCompleteErrorDetails> Details { get; set; }
        [JsonProperty(PropertyName = "innererror")]
        public PaymentCompleteError InnerError { get; set; }
    }

    public class PaymentCompleteErrorDetails
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}