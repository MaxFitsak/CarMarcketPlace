using FluentValidation;

public class CreateCarDtoValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarDtoValidator()
    {
        RuleFor(x => x.Make)
            .NotEmpty().WithMessage("Марка автомобіля обов'язкова.")
            .MaximumLength(50).WithMessage("Марка не повинна перевищувати 50 символів.");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Модель автомобіля обов'язкова.")
            .MaximumLength(50).WithMessage("Модель не повинна перевищувати 50 символів.");

        RuleFor(x => x.Year)
            .InclusiveBetween(1900, DateTime.UtcNow.Year + 1)
            .WithMessage($"Рік випуску має бути від 1900 до {DateTime.UtcNow.Year + 1}.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Ціна має бути більшою за 0.");

        RuleFor(x => x.Vin)
            .NotEmpty().WithMessage("VIN-код обов'язковий.")
            .Length(17).WithMessage("VIN-код повинен містити рівно 17 символів.")
            .Matches("^[A-HJ-NPR-Z0-9]+$").WithMessage("VIN містить неприпустимі символи.");
    }
}