using BeautyLand.Application.Services.Administrator.Discounts.GetDiscount;
using BeautyLand.Domain.Users;
using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLand.AdministratorEndPoint.ModelBinders.DiscountModelBinder
{
    public class DiscountModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            string model = bindingContext.FieldName;
            DiscountDto discount;

            bool.TryParse(bindingContext.ValueProvider
              .GetValue($"{model}.{nameof(discount.UseCouponCode)}").FirstValue, out bool useCouponCode);

            bool.TryParse(bindingContext.ValueProvider
                .GetValue($"{model}.{nameof(discount.UseAmount)}").FirstValue, out bool useAmount);

            bool.TryParse(bindingContext.ValueProvider
                .GetValue($"{model}.{nameof(discount.UsePercentage)}").FirstValue, out bool usePercentage);

            discount = new DiscountDto
            {
                UseCouponCode = useCouponCode,

                DiscountAmount = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.DiscountAmount)}").FirstValue),

                DiscountLimitationTypeId = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.DiscountLimitationTypeId)}").FirstValue),

                UseAmount = useAmount,

                DiscountPercentage = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.DiscountPercentage)}").FirstValue),

                DiscountTypeId = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.DiscountTypeId)}").FirstValue),

                LimitationTime = int.Parse(bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.LimitationTime)}").FirstValue),
                UsePercentage = usePercentage,

                Name = bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.Name)}").FirstValue,

                DiscountCode = bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.DiscountCode)}").FirstValue,

                EndDate = PersianDateTime.Parse(bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.EndDate)}").FirstValue),

                StartDate = PersianDateTime.Parse(bindingContext.ValueProvider
                    .GetValue($"{model}.{nameof(discount.StartDate)}").FirstValue),

                

            };
            //var users = bindingContext.ValueProvider.GetValue($"{model}.{nameof(discount.Users)}");

            //if (!string.IsNullOrEmpty(users.Values))
            //{
            //    discount.Users =
            //    bindingContext.ValueProvider
            //    .GetValue($"{model}.{nameof(discount.Users)}")
            //    .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();

            //}

            //var brands = bindingContext.ValueProvider.GetValue("Model.Brand");

            //if (!string.IsNullOrEmpty(brands.Values))
            //{
            //    discount.Brands =
            //    bindingContext.ValueProvider
            //    .GetValue($"{model}.{nameof(discount.Brands)}")
            //    .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            //}

            //var types = bindingContext.ValueProvider.GetValue("Model.Tpes");

            //if (!string.IsNullOrEmpty(types.Values))
            //{
            //    discount.Items =
            //    bindingContext.ValueProvider
            //    .GetValue($"{model}.{nameof(discount.Types)}")
            //    .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            //}

            var items = bindingContext.ValueProvider.GetValue("Model.Items");

            if (!string.IsNullOrEmpty(items.Values))
            {
                discount.Items =
                bindingContext.ValueProvider
                .GetValue($"{model}.{nameof(discount.Items)}")
                .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            }



            bindingContext.Result = ModelBindingResult.Success(discount);
            return Task.CompletedTask;
        }
    }
}
