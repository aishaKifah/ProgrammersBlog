using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexType;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<int>> CountAsync()

        {
            var commentsCount = await _unitOfWork.Comments.CountAsync();
            if (commentsCount > -1)
            {
                return new ResultData<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new ResultData<int>(ResultStatus.Error, -1, "unknown Error ! ");
            }
        }

        public async Task<IDataResult<int>> CountByNoneDeletedAsync()
        {
            var commentsCount = await _unitOfWork.Comments.CountAsync(c=>!c.isDeleted);
            if (commentsCount > -1)
            {
                return new ResultData<int>(ResultStatus.Success, commentsCount);
            }
            else
            {
                return new ResultData<int>(ResultStatus.Error, -1, "unknown Error ! ");
            }
        }
    }
}
