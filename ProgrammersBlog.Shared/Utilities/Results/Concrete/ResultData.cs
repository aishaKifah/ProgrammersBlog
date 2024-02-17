using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexType;
using System;

namespace ProgrammersBlog.Shared.Utilities.Results.Concrete
{
    public class ResultData<T> : IDataResult<T>
    {
        public ResultData(ResultStatus resultStatus, T data)
        {
            this.resultStatus = resultStatus;
            this.data = data;
        }
        public ResultData(ResultStatus resultStatus, T data, String msg)
        {
            this.resultStatus = resultStatus;
            this.data = data;
            this.msg = msg;
        }
        public ResultData(ResultStatus resultStatus, T data, String msg, Exception exception)
        {
            this.resultStatus = resultStatus;
            this.data = data;
            this.msg = msg;
            this.exception = exception;
        }


        public T data { get; }

        public ResultStatus resultStatus { get; set; }
        public string msg { get; set; }
        public Exception exception { get; set; }
    }

}
