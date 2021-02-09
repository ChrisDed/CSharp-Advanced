using System;
using System.Collections.Generic;

namespace ExceptionHandling
{
    public class YoutubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                // Access YouTube web service
                // Read the data
                // Create a list of video objects
                throw new Exception("Some low level Youtube error.");
            }
            catch (Exception ex)
            {
                // log
                // throwing custom exception
                throw new YouTubeException("Could not fetch the videos from YouTube", ex);
            }

            return new List<Video>();
        }
    }
}
