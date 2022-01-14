using System;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;

namespace Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, object data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public Result(ResultStatus resultStatus, object data, string message)
        {
            ResultStatus = resultStatus;
            Data = data;
            Message = message;
        }
        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(object data)
        {
            Data = data;
        }

        public ResultStatus ResultStatus { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}

