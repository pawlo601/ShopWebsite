using System.Collections;
using System.Collections.Generic;

namespace ShopWebsite.Model.Entities
{
    public class TransactionalInformation
    {
        public bool ReturnStatus { get; set; }
        public List<string> ReturnMessage { get; set; }
        public Hashtable ValidationErrors { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
        public int PageSize { get; set; }
        public bool IsAuthenicated { get; set; }
        public string SortExpression { get; set; }
        public string SortDirection { get; set; }
        public string Filter { get; set; }
        public int CurrentPageNumber { get; set; }

        public TransactionalInformation()
            : this(false, new List<string>(), new Hashtable(), 0, 0, 0, false, "", "", "", 0)
        {
        }

        public TransactionalInformation(bool returnStatus, List<string> returnMessage, Hashtable validationErrors,
            int totalPages, int totalRows, int pageSize, bool isAuthenicated, string sortExpression,
            string sortDirection, string filter, int currentPageNumber)
        {
            ReturnStatus = returnStatus;
            ReturnMessage = returnMessage;
            ValidationErrors = validationErrors;
            TotalPages = totalPages;
            TotalRows = totalRows;
            PageSize = pageSize;
            IsAuthenicated = isAuthenicated;
            SortExpression = sortExpression;
            SortDirection = sortDirection;
            Filter = filter;
            CurrentPageNumber = currentPageNumber;
        }

        public static TransactionalInformation CreateTransactionInforamtionHowManyResults(int howManyResults)
        {
            return new TransactionalInformation
            {
                TotalRows = howManyResults,
                ReturnStatus = true,
                ReturnMessage =
                    new List<string>
                    {
                        howManyResults != 0 ? "Znaleziono." : "Nie znaleziono, ale wyszukiwanie przebiegło pomyślnie."
                    }
            };
        }
    }
}
