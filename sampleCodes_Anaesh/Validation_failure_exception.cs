public static class ValidationFailureExtensions
    {
        public static HttpResponseException CustomException(this List<ValidationFailure> validationFailures, HttpStatusCode statusCode)
        {
            return validationFailures.ToDisprzErrors().CustomException(statusCode);
        }

        public static HttpResponseException CustomException(this ValidationFailure validationFailure, HttpStatusCode statusCode)
        {
            return validationFailure.ToDisprzError().CustomException(statusCode);
        }

        public static List<DisprzError> ToDisprzErrors(this List<ValidationFailure> validationFailures)
        {
            return validationFailures.Select(s => s.ToDisprzError()).ToList();
        }

        public static DisprzError ToDisprzError(this ValidationFailure validationFailure)
        {
            return new DisprzError(errorCode: validationFailure.ErrorCode, message: validationFailure.ErrorMessage, languageCode: "en");
        }
    }