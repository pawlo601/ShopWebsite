using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Data.Common
{
    public static class Validation
    {
        public static void TransformValidationResultsToTransactionalInformation(List<ValidationResult> results, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            transaction.ReturnStatus = results.Capacity == 0;
        }

        public static void BuildTransactionalInformationFromException(Exception exc, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            transaction.ReturnStatus = false;
        }
    }
}
