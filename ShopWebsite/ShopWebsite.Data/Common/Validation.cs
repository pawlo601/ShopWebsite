using ShopWebsite.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebsite.Data.Common
{
    public static class Validation
    {
        public static void TransformValidationResultsToTransactionalInformation(List<ValidationResult> results, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            if (results.Capacity == 0)
                transaction.ReturnStatus = true;
            else
                transaction.ReturnStatus = false;
        }
        public static void BuildTransactionalInformationFromException(Exception exc, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            transaction.ReturnStatus = false;
        }
    }
}
