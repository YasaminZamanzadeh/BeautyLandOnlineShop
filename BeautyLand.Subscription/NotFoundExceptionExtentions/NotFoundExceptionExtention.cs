using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Subscription.ExceptionExtentions
{
   public  class NotFoundExceptionExtention<TValue, TKey>: Exception
    {
        public TValue Value { get; set; }
        public TKey Key { get; set; }
        public NotFoundExceptionExtention(TValue value, TKey key)
            : base($"The desired entity {nameof(value)} with key {key} is not found ")
        {
            Value = value;
            Key = key;
        }

    }
}
