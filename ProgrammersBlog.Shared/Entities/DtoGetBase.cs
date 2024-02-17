using ProgrammersBlog.Shared.Utilities.Results.ComplexType;

namespace ProgrammersBlog.Shared.Entities
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Massege { get; set; }
    }
}
