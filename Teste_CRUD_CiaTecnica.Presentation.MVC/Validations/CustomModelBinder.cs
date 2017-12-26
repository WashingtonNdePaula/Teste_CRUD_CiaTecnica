using System;
using System.Globalization;
using System.Web.Mvc;


/// <summary>
/// Customizar Double
/// </summary>
public class DoubleModelBinder : DefaultModelBinder
{
    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (result != null)
        {
            if (bindingContext.ModelType == typeof(double) || bindingContext.ModelType == typeof(double?))
            {
                double temp;
                var attempted = result.AttemptedValue.Replace(".", "").Replace(",", ".");
                if (attempted == "")
                {
                    attempted = "0";
                }
                if (double.TryParse(
                    attempted,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out temp)
                )
                {
                    return temp;
                }
            }
        }
        return base.BindModel(controllerContext, bindingContext);
    }
}

/// <summary>
/// Customizar Decimal
/// </summary>

public class DecimalModelBinder : DefaultModelBinder
{
    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (result != null)
        {
            if (bindingContext.ModelType == typeof(decimal) || bindingContext.ModelType == typeof(decimal?))
            {
                decimal temp;
                var attempted = result.AttemptedValue.Replace(".", "").Replace(",", ".");
                if (attempted == "")
                {
                    attempted = "0";
                }
                if (decimal.TryParse(
                    attempted,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out temp)
                )
                {
                    return temp;
                }
            }
        }
        return base.BindModel(controllerContext, bindingContext);
    }
}

/// <summary>
/// Customizar Inteiros
/// </summary>

public class Int32ModelBinder : DefaultModelBinder
{
    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (result != null)
        {
            if (bindingContext.ModelType == typeof(Int32) || bindingContext.ModelType == typeof(Int32?))
            {
                Int32 temp;
                var attempted = result.AttemptedValue.Replace(".", "");
                if (attempted == "")
                {
                    attempted = "0";
                }
                if (Int32.TryParse(
                    attempted,
                    NumberStyles.Integer,
                    CultureInfo.InvariantCulture,
                    out temp)
                )
                {
                    return temp;
                }
            }
        }
        return base.BindModel(controllerContext, bindingContext);
    }
}