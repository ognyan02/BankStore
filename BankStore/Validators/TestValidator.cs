﻿using FluentValidation;
using BankStore.Controllers;

namespace BankStore.Validators
{
    public class TestValidator :AbstractValidator<TestRequest>
    {
        public TestValidator() {
            RuleFor(x => x.MagicNumber)
            .GreaterThan(0)
            .LessThan(10);
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(250);
            RuleFor(x => x.DateTime)
                .NotNull()
                .GreaterThan(DateTime.MaxValue);
        }
    }
}
