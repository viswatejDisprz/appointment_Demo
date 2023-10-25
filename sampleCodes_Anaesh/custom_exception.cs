public static HttpResponseException CustomException(this DisprzError error, HttpStatusCode statusCode)
        {
            var response = new HttpResponseMessage
            {
                Content = new StringContent(error.ToJson(), Encoding.UTF8, "application/json"),
                StatusCode = statusCode
            };

            return new HttpResponseException(response);
        }