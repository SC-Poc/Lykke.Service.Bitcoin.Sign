using System;

namespace Lykke.Service.Bitcoin.Sign.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string text, ErrorCode code)
            : base(text)
        {
            Code = code;
            Text = text;
        }

        public ErrorCode Code { get; }
        public string Text { get; }
    }
}
