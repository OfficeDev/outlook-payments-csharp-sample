// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
using System.Collections.Generic;

// Models for types defined in W3C Payment Request API spec
// http://www.w3.org/TR/payment-request

namespace OutlookPayments.Models
{
    // http://www.w3.org/TR/payment-request/#paymentmethoddata-dictionary
    public class PaymentMethodData
    {
        public string SupportedMethods { get; set; }
        public MethodDetails Data { get; set; }
    }

    // http://www.w3.org/TR/payment-request/#paymentoptions-dictionary
    public class PaymentOptions
    {
        public bool RequestPayerName { get; set; }
        public bool RequestPayerEmail { get; set; }
        public bool RequestPayerPhone { get; set; }
        public bool RequestShipping { get; set; }
        public string ShippingType { get; set; }
    }

    // http://www.w3.org/TR/payment-request/#paymentdetailsinit-dictionary
    public class PaymentDetailsInit
    {
        public string Id { get; set; }
        public PaymentItem Total { get; set; }
        public List<PaymentItem> DisplayItems { get; set; }
        public List<PaymentShippingOption> ShippingOptions { get; set; }
    }

    // http://www.w3.org/TR/payment-request/#paymentitem-dictionary
    public class PaymentItem
    {
        public string Label { get; set; }
        public PaymentCurrencyAmount Amount { get; set; }
        public bool Pending { get; set; }
    }

    // http://www.w3.org/TR/payment-request/#paymentshippingoption-dictionary
    public class PaymentShippingOption
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public PaymentCurrencyAmount Amount { get; set; }
        public bool Selected { get; set; }
    }

    // http://www.w3.org/TR/payment-request/#paymentcurrencyamount-dictionary
    public class PaymentCurrencyAmount
    {
        public string Currency { get; set; }
        public string Value { get; set; }
        public string CurrencySystem { get; set; }
    }

    // http://www.w3.org/TR/payment-request/#addressinit-dictionary
    public class AddressInit
    {
        public string Country { get; set; }
        public string[] AddressLine { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string DependentLocality { get; set; }
        public string PostalCode { get; set; }
        public string SortingCode { get; set; }
        public string LanguageCode { get; set; }
        public string Organization { get; set; }
        public string Recipient { get; set; }
        public string Phone { get; set; }
    }

    // http://www.w3.org/TR/payment-request/#paymentresponse-interface
    public class PaymentResponse
    {
        public string RequestId { get; set; }
        public string MethodName { get; set; }
        public PaymentDetails Details { get; set; }
        public AddressInit ShippingAddress { get; set; }
        public string ShippingOption { get; set; }
        public string PayerName { get; set; }
        public string PayerEmail { get; set; }
        public string PayerPhone { get; set; }
    }
}