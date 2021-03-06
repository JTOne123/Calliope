using System;
using System.Collections.Generic;
using Calliope.Validation;

namespace Calliope.Validators
{
    /// <summary>
    /// String validator that will ensure a string is not null or empty and optionally bounded to a minimum and maximum value.
    /// </summary>
    public class NotEmptyStringValidator : Validator<string>
    {
        private readonly Option<int> _minimumLength;
        private readonly Option<int> _maximumLength;

        public NotEmptyStringValidator(Option<int> minimumLength, Option<int> maximumLength)
        {
            _minimumLength = minimumLength;
            _maximumLength = maximumLength;
        }

        public override IEnumerable<(Func<string, bool> rule, string error)> Rules() => 
            new (Func<string, bool> rule, string error)[]
            {
                (string.IsNullOrEmpty, $"{Placeholder.TypeName} cannot be null or empty"),
                (IsLessToMinimumLength, $"{Placeholder.TypeName} is less than the minimum length"),
                (IsMoreThanMaximumLength, $"{Placeholder.TypeName} is more than maximum length")
            };

        private bool IsLessToMinimumLength(string input) =>
            _minimumLength.IsSome() && input?.Length < _minimumLength.Unwrap();

        private bool IsMoreThanMaximumLength(string input) =>
            _maximumLength.IsSome() && input?.Length > _maximumLength.Unwrap();
    }
}