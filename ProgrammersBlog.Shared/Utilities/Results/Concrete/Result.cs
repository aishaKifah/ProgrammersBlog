using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexType;
using System;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            this.resultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, String msg)
        {
            this.resultStatus = resultStatus;
            this.msg = msg;
        }
        public Result(ResultStatus resultStatus, String msg, Exception exception)
        {
            this.resultStatus = resultStatus;
            this.msg = msg;
            this.exception = exception;
        }

        public ResultStatus resultStatus { get; }
        public string msg { get; }
        public Exception exception { get; }
    }
}
