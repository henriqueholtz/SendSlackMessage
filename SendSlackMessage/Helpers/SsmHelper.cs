using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SendSlackMessage.Helpers
{
    static class SsmHelper
    {
        internal static KeyValuePair<bool, string> ValidateStrings(IEnumerable<KeyValuePair<string, string>> strings)
        {
            if (strings == null || !strings.Any()) return new KeyValuePair<bool, string>(false, "Don't have properties to validate");
            foreach (var item in strings)
            {
                if (String.IsNullOrWhiteSpace(item.Value))
                {
                    return new KeyValuePair<bool, string>(false, $"[{item.Key}] is null or white space.");
                }
            }
            return new KeyValuePair<bool, string>(true, null);
        }

        #region NotImplemented
        internal static IRuleBuilderOptions<IEnumerable<string>, bool> ValidateStringsToFluentValidation(IEnumerable<string> strings)
        {
            throw new NotImplementedException();
        }
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            //https://docs.fluentvalidation.net/en/latest/custom-validators.html
            return ruleBuilder.Must((rootObject, list, context) => {
                context.MessageFormatter.AppendArgument("MaxElements", num);
                return list.Count < num;
            })
            .WithMessage("{PropertyName} must contain fewer than {MaxElements} items.");
            throw new NotImplementedException();
        }
        #endregion
    }

    #region NotImplemented
    internal class NotAnyStringEmptyOrNull<T, TProperty> : PropertyValidator<T, TProperty>
    {
        public override string Name => "NotAnyStringEmptyOrNull";

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            //https://docs.fluentvalidation.net/en/latest/custom-validators.html
            throw new NotImplementedException();
        }
    }
    #endregion
}
