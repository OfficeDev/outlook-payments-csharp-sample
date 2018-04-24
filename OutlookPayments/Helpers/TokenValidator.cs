// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
using Microsoft.O365.ActionableMessages.Utilities;
using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OutlookPayments.Helpers
{
    public static class TokenValidator
    {
        private static readonly string merchantId = ConfigurationManager.AppSettings["MerchantId"];

        public static async Task<string> ValidateAuthorizationHeader(AuthenticationHeaderValue authHeader)
        {
            // Validate that we have a bearer token
            if (authHeader == null ||
                !string.Equals(authHeader.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrEmpty(authHeader.Parameter))
            {
                return string.Empty;
            }

            // Validate the token
            ActionableMessageTokenValidator validator = new ActionableMessageTokenValidator();
            ActionableMessageTokenValidationResult result = await validator.ValidateTokenAsync(authHeader.Parameter, merchantId);
            if (!result.ValidationSucceeded)
            {
                return string.Empty;
            }

            // Token is valid, return the action performer, which is the email
            // address of the user that took the action. This should match
            // the email that you sent the invoice to
            return result.ActionPerformer;
        }
    }
}