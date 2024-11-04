using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Application.Services.Dtos.BaseDto
{
    public class BaseDto<TValue>
    {
        public BaseDto(TValue model, IEnumerable<string> messages, bool isSuccess)
        {
            Model = model;
            Messages = messages;
            IsSuccess = isSuccess;
        }
        public TValue Model { get; private set; }
        public IEnumerable<string> Messages { get; private set; }
        public bool IsSuccess { get; private set; }

    }

    public class BaseDto
    {
        public BaseDto(IEnumerable<string> messages, bool isSuccess)
        {
            Messages = messages;
            IsSuccess = isSuccess;
        }
        public IEnumerable<string> Messages { get; private set; }
        public bool IsSuccess { get; private set; }

    }
}
