public static void Validate<TObject, TValidator>(this TObject instance)
            where TObject : class
            where TValidator : AbstractValidator<TObject>, new()
        {
            var validator = new TValidator();
            var validationResult = validator.Validate(instance);
            if (!validationResult.IsValid)
                throw validationResult.Errors.CustomException(HttpStatusCode.BadRequest);
        }