using ProgrammersBlog.Shared.Utilities.Results.ComplexType;
using System;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus resultStatus { get; }
        public string msg { get; }
        public Exception exception { get; }
    }
}
