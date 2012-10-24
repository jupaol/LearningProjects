using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Msts.Mvc.CustomHelpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TEnum>> expression)
        {
            return EnumDropDownListFor(helper, expression, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var enumType = GetNonNullableModelType(modelMetadata);
            var enumValues = Enum.GetValues(enumType).Cast<TEnum>();
            var emptyListItems = new[] { new SelectListItem { Text = string.Empty, Value = string.Empty } };
            var listItems = enumValues.Select(x => new SelectListItem
                {
                    Text = GetEnumDescription(x),
                    Value = x.ToString(),
                    Selected = x.Equals(modelMetadata.Model)
                });

            if (modelMetadata.IsNullableValueType)
            {
                emptyListItems.Concat(listItems);
            }

            return helper.DropDownListFor(expression, listItems, htmlAttributes);
        }

        private static string GetEnumDescription<TEnum>(TEnum enumValue)
        {
            var descriptionString = enumValue.ToString();
            var field = enumValue.GetType().GetField(descriptionString);
            var descriptions = field.GetCustomAttributes(typeof(DescriptionAttribute), false).OfType<DescriptionAttribute>();
            var firstDescription = descriptions.FirstOrDefault();

            if (firstDescription != null)
            {
                descriptionString = firstDescription.Description;
            }

            return descriptionString;
        }

        private static Type GetNonNullableModelType(ModelMetadata metadata)
        {
            var realType = metadata.ModelType;
            var underlyingType = Nullable.GetUnderlyingType(realType);

            if (underlyingType != null)
            {
                realType = underlyingType;
            }

            return realType;
        }
    }
}