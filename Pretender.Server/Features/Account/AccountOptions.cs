using System;

namespace Pretender.Features.Account
{
    public class AccountOptions
    {
        public Int32 MinimumPasswordLength { get; set; } = 10;
        public Int32 MaximumPasswordLength { get; set; } = 128;
    }
}