using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Calliope.Validation;

namespace Calliope.Validators
{
    /// <summary>
    /// String validator that applies a regex check against the input.
    /// </summary>
    public abstract class RegexValidation : Validator<string>
    {
        protected readonly Regex Regex;
        protected RegexValidation(string regexPattern)
        {
            Regex = new Regex(regexPattern);
        }
        
        public override IEnumerable<(Func<string, bool> rule, string error)> Rules() => 
            new (Func<string, bool> rule, string error)[]
            {
                (string.IsNullOrEmpty, $"{Placeholder.TypeName} cannot be null or empty."),
                (DoesNotMatchRegex, $"{Placeholder.TypeName} does not match expected format.")
            };

        private bool DoesNotMatchRegex(string input) => !Regex.IsMatch(input);
    }
}