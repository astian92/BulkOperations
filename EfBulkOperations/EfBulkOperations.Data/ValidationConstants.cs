using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfBulkOperations.Data
{
    public class ValidationConstants
    {
        public const string EVENT_NOT_PUBLISHED_ERROR_MESSAGE = "An error occured when trying to publish a message to the message bus.";
        public const string EVENT_NOT_PUBLISHED_WITH_REQUEST_ID_ERROR_MESSAGE = "An error occured when trying to publish a message to the message bus; RequestId: {0}";
        public const string MESSAGE_BUILD_FAILED_ERROR_MESSAGE = @"An error occured when trying to build a message. Type: ""{0}""; Details: {1}.";

        public const string INVALID_EXTERNAL_SYSTEM_ID_MESSAGE = "The provided external system's organization identifier cannot be null, empty or whitespace.";
        public const string INVALID_CUSTOMER_ID_MESSAGE = "The provided customer's organization identifier cannot be null, empty or whitespace.";

        /*
            DTO specifics
        */
        public const string IVALID_ADDRESS_COUNTRY = "The Address_Country field should be 3 characters long according to ISO 3166-1 alpha-3 international country code standardization.";

        /*
            Common string constants that can be reused.
        */
        public const int CANONICAL_ID_MAX_LENGTH = 50;
        public const int CONNECTION_STRING_MAX_LENGTH = 50;
        public const int STANDART_STRING_FIELD_MAX_LENGTH = 128;
        public const int LOCATION_CODE_MAX_LENGTH = 11;
        public const int STANDART_NAME_MAX_LENGTH = 255;

        /*
            Specific string constants.
        */
        public const int IDENTIFIER_MAX_LENGTH = 45;
        public const int EMPLOYEE_ID_MAX_LENGTH = 68;
        public const int ASSIGNMENT_SHIFT_TYPE_MAX_LENGTH = 24;
    }
}
