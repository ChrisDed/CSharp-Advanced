using System;

namespace ExceptionHandling
{
    public class YouTubeException : Exception
    {
        // Custom exceptions only need to call base keyword
        // to pass the message and inner exception to the derived
        // Exception class.
        public YouTubeException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}
