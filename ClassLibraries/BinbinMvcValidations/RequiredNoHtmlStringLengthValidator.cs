using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Binbin.CommonService;
using Binbin.ComponentModel.DataAnnotations;

namespace Binbin.MVC.Validations
{
    public static class RequiredNoHtmlStringLengthValidator
    {
        public static ValidationResult Validate(string value)
        {
            if (value.NoHtmlTextLength() > 7)
                return ValidationResult.Success;

            return new ValidationResult("除表情外，内容必须大于8个文字！");
        }
    }
}