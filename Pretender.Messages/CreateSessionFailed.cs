using System;
namespace Pretender.Messages
{
    public class CreateSession
    {
        public Int32 PlayerId { get; set; }
        public String AuthToken { get; set; }
    }

    public class CreateSessionFailed
    {
    }

    public class SessionCreated
    {
        public String ConnectionId { get; set; }
        public Int32 SessionId { get; set; }
    }
}
