//-----------------------------------------------------------------------
// <copyright file="ConvertResult.cs" company="Lifeprojects.de">
//     Class: ConvertResult<TResult>
//     Copyright © Lifeprojects.de GmbH 2019
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>gerhard.ahrens@lifeprojects.de</email>
// <date>12.06.2019</date>
//
// <summary>
//      Result TryConvert
// </summary>
//-----------------------------------------------------------------------

namespace EasyPrototyping.Core
{
    using System;

    public class ConvertResult<TResult>
    {

        public DateTime ResultTime { get; set; }

        public bool? ResultState { get; set; }

        public bool Success { get; private set; }

        public TResult Result { get; private set; }

        public string NonSuccessMessage { get; private set; }

        public string SuccessMessage { get; private set; }

        public Exception Exception { get; private set; }

        public static ConvertResult<TResult> SuccessResult(TResult result, string successMessage, bool? resultState, DateTime resultTime)
        {
            return new ConvertResult<TResult>
            {
                ResultTime = resultTime,
                ResultState = resultState,
                Success = true,
                Result = result,
                SuccessMessage = successMessage
            };
        }

        public static ConvertResult<TResult> SuccessResult(TResult result, bool? resultState, DateTime resultTime)
        {
            return new ConvertResult<TResult>
            {
                ResultTime = resultTime,
                ResultState = resultState,
                Success = true,
                Result = result,
                SuccessMessage = string.Empty
            };
        }

        public static ConvertResult<TResult> SuccessResult(TResult result, DateTime resultTime)
        {
            return new ConvertResult<TResult>
            {
                ResultTime = resultTime,
                ResultState = null,
                Success = true,
                Result = result,
                SuccessMessage = string.Empty
            };
        }


        public static ConvertResult<TResult> SuccessResult(TResult result, bool? resultState)
        {
            return new ConvertResult<TResult>
            {
                ResultState = resultState,
                Success = true,
                Result = result,
                SuccessMessage = string.Empty
            };
        }

        public static ConvertResult<TResult> SuccessResult(TResult result)
        {
            return new ConvertResult<TResult>
            {
                ResultState = null,
                Success = true,
                Result = result,
                SuccessMessage = string.Empty
            };
        }

        public static ConvertResult<TResult> Failure(string nonSuccessMessage)
        {
            return new ConvertResult<TResult>
            {
                ResultState = null,
                Success = false,
                NonSuccessMessage = nonSuccessMessage
            };
        }

        public static ConvertResult<TResult> Failure(Exception ex)
        {
            return new ConvertResult<TResult>
            {
                ResultState = null,
                Success = false,
                NonSuccessMessage = $"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                Exception = ex
            };
        }

        public static ConvertResult<TResult> Failure(Exception ex, bool? resultState = null)
        {
            return new ConvertResult<TResult>
            {
                ResultState = resultState,
                Success = false,
                NonSuccessMessage = $"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                Exception = ex
            };
        }
    }
}
