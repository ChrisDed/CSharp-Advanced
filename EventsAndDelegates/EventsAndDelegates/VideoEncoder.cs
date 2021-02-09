using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        // 1- Define a delegate
        // 2- Define an event based on that delegate
        // 3- Raise the event

        // holds a reference to a method with that signature
        // We want to send a reference to the video, so the subscriber
        // knows what video we encoded
        // to do that, instead of using EventArgs,
        // we need a custom class that derives from EventArgs,
        // and includes any additional data we want to send to our
        // subscribers
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        // Delegate type - EventHandler - 2 forms
        // EventHandler
        // EventHandler<TEventArgs>

        // instead of declaring a delegate and passing it into the event
        //public event VideoEncodedEventHandler VideoEncoded;

        // You can do this to make your code shorter and life easier
        public event EventHandler<VideoEventArgs> VideoEncoded;
        // this line is equivallent to this:
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);


        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video....");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        // .NET convention your event publisher methods should be
        // protected, virtual, and void - naming start with 'On'
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }
    }
}
