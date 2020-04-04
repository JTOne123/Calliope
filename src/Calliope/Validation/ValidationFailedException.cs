using System;
using System.Collections.Generic;
using Calliope.Validators;

namespace Calliope.Validation
{
    public class ValidationFailedException : Exception
    {
        public IReadOnlyList<string> Messages { get; }
        public ValidationFailedException(string typeName, ValidationFailed failed)
        {
            var messages = new List<string>();

            foreach (var failure in failed.ValidationMessages)
            {
                messages.Add(failure.Replace(Placeholder.TypeName, typeName));
            }
            
            Messages = messages;
        }
    }
}