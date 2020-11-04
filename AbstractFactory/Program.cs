using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher<VideoFacebookPublishFactory> fbpublisher = new Publisher<VideoFacebookPublishFactory>("Bir Video");

            Publisher<BlogTwitterPublishFactoy> twitterPublisher = new Publisher<BlogTwitterPublishFactoy>("Bir blog");

            Console.ReadLine();
        }
    }

    public interface IContent
    {
        void CreateContent();
        string Title { get; set; }
    }

    public interface IPublisherSetting
    {
        string Address { get; set; }

        void Release(IContent content);
    }

    public interface IPublisherFactory
    {
        IContent Content(string title);
        IPublisherSetting PublisherSetting();
    }

    public class BlogContent : IContent
    {
        public string Title { get; set; }

        public void CreateContent()
        {
            Console.WriteLine("Created Blog Content");
        }
    }

    public class VideoContent : IContent
    {
        public string Title { get; set; }

        public void CreateContent()
        {
            Console.WriteLine("Created Video Content");
        }
    }

    public class FacebookPublisher : IPublisherSetting
    {
        public string Address { get; set; }

        public void Release(IContent content)
        {
            Console.WriteLine(string.Format("Shared on Facebook using address {0}",Address));
        }
    }

    public class TwitterPublisher : IPublisherSetting
    {
        public string Address { get; set; }

        public void Release(IContent content)
        {
            Console.WriteLine(string.Format("Shared on Twitter using address {0}", Address));
        }
    }

    public class BlogTwitterPublishFactoy : IPublisherFactory
    {
        public IContent Content(string title)
        {
            BlogContent blogContent = new BlogContent();
            blogContent.Title = title;
            blogContent.CreateContent();
            return blogContent;
        }

        public IPublisherSetting PublisherSetting()
        {
            TwitterPublisher twitterPublisher = new TwitterPublisher();
            twitterPublisher.Address = "http://www.twitter.com";
            return twitterPublisher;
        }
    }

    public class VideoFacebookPublishFactory : IPublisherFactory
    {
        public IContent Content(string title)
        {
            VideoContent videoContent = new VideoContent();
            videoContent.Title = title;
            videoContent.CreateContent();
            return videoContent;
        }

        public IPublisherSetting PublisherSetting()
        {
            FacebookPublisher facebookPublisher = new FacebookPublisher();
            facebookPublisher.Address = "http://facebook.com";
            return facebookPublisher;
        }
    }

    public class Publisher<T> where T: IPublisherFactory, new()
    {
        private IContent _content;
        private IPublisherSetting _publisherSetting;
        private T _factory;

        public Publisher(string title)
        {
            _factory = new T();
            _content = _factory.Content(title);
            _publisherSetting = _factory.PublisherSetting();
        }

        public void Release()
        {
            _publisherSetting.Release(_content);
        }
    }
}
