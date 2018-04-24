// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
namespace OutlookPayments.Models
{
    // Used in the event field in MethodDetails
    public static class PayEvent
    {
        public static string LoadEntity = "loadentity";
        public static string ShippingAddressChange = "shippingaddresschange";
        public static string ShippingOptionChange = "shippingoptionchange";
    }

    // Used by the shippingType field in PaymentOptions
    public static class ShippingType
    {
        public static string Shipping = "shipping";
        public static string Delivery = "delivery";
        public static string Pickup = "pickup";
    }

    // Used by the id field in PaymentShippingOption
    public static class Shipping
    {
        public static string NoRush = "norush";
        public static string Priority = "priority";
    }

    // Used by the paymentStatus field in Invoice
    public static class PaymentStatus
    {
        public static string PaymentAutomaticallyApplied = "PaymentAutomaticallyApplied";
        public static string PaymentComplete = "PaymentComplete";
        public static string PaymentDeclined = "PaymentDeclined";
        public static string PaymentDue = "PaymentDue";
        public static string PaymentPastDue = "PaymentPastDue";
    }

    public static class PaymentResult
    {
        public static string Success = "success";
        public static string Fail = "fail";
    }
}