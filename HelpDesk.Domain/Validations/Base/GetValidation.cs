using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Domain.Validations.Base
{
    public static class GetValidation
    {
        public static Response GetErros(this ValidationResult result)
        {
            var response = new Response();

            if (!result.IsValid)
            {
                foreach(var error in result.Errors)
                {
                    response.Report.Add(new Report()
                    {
                        Code = error.ErrorCode,
                        Message = error.ErrorMessage
                    });
                }

                return response;
            }

            return response;
        }
    }
}
