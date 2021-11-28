using System;
using Shared.Utilities.Results.ComplexTypes;

namespace Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public object Data { get; set; }
    }
}

