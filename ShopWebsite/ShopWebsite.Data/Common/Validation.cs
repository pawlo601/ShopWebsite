using ShopWebsite.Model.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopWebsite.Data.Common
{
    public static class Validation
    {
        public static void TransformValidationResultsToTransactionalInformation(List<ValidationResult> results, out TransactionalInformation transaction)
        {
            if (results == null)
            {
                // ReSharper disable once RedundantAssignment
                transaction = new TransactionalInformation { ReturnMessage = new List<string> { "Something wrong with transactioanlInformation" } };
            }
            if (results.Capacity == 0)
            {
                transaction = new TransactionalInformation(true, new List<string> { "All is good" }, new Hashtable(), 0, 0, 0, false, "",
                    "", "", 0);
            }
            else
            {
                // ReSharper disable once UseObjectOrCollectionInitializer
                transaction = new TransactionalInformation();
                transaction.ReturnStatus = false;
                transaction.ReturnMessage = new List<string> {"Error in validation."};
                Hashtable err = new Hashtable();
                foreach (ValidationResult result in results)
                {
                    err.Add(result.MemberNames, result.ErrorMessage);
                }
                transaction.ValidationErrors = err;
            }
        }

        public static void BuildTransactionalInformationFromException(Exception exc, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation
            {
                ReturnStatus = false,
                ReturnMessage = new List<string>
                {
                    exc.Message + "\n\nSource:\n\n" + exc.Source + "\n\nStack trace:\n\n" + exc.StackTrace
                }
            };
        }
    }
}
