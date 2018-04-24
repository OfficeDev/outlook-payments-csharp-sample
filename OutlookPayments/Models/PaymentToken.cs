// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace OutlookPayments.Models
{
    public class PaymentToken
    {
        public string Format { get; private set; }
        public string Payload { get; private set; }
        public bool IsTestToken { get; private set; }

        public PaymentToken(string encodedToken)
        {
            // Payment tokens are encoded like
            // base64Header.base64token.base64Signature
            string[] parts = encodedToken.Split('.');

            // Decode header and check if in test mode
            JObject header = JObject.Parse(Base64UrlDecode(parts[0]));
            if (header.Value<bool>("TestMode"))
            {
                IsTestToken = true;
                // Since we're in test mode, we can skip any validation
                Format = header.Value<string>("Format");
                Payload = Base64UrlDecode(parts[1]);
            }
            else
            {
                // TODO: Should validate the signature on the encoded token
                // Then process the token for actual payment
                IsTestToken = false;
                Format = string.Empty;
                Payload = string.Empty;
            }
        }

        private string Base64UrlDecode(string encoded)
        {
            string padded = encoded.PadRight(encoded.Length + (4 - encoded.Length % 4) % 4, '=');
            padded = padded.Replace('-', '+').Replace('_', '/');
            var decodedBytes = Convert.FromBase64String(padded);
            return Encoding.UTF8.GetString(decodedBytes);
        }
    }
}