namespace Tests
{
    using Moq;
    using NUnit.Framework;
    using UnitTestingExercise.Twitter;

    public class TweetTests
    {
        [Test]
        public void ReceiveMessage_WritesToConsole()
        {
            Mock<IClient> client = new Mock<IClient>();
            Tweet tweet = new Tweet(client.Object);

            tweet.ReceiveMessage("msg");

            client.Verify(c => c.WriteToConsole("msg"), Times.Once);
        }

        [Test]
        public void ReceiveMessage_SendsToServer()
        {
            Mock<IClient> client = new Mock<IClient>();
            Tweet tweet = new Tweet(client.Object);

            tweet.ReceiveMessage("msg");

            client.Verify(c => c.SendToServer("msg"), Times.Once);
        }



    }
}
