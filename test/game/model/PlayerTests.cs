using NUnit.Framework;
using model;

namespace ModelTests
{
    public class PlayerTests
    {
        [Test]
        public void ShouldCreatePlayer()
        {
            var player = new Player("Name");

            Assert.That(player == null, Is.False);
        }
    }
}