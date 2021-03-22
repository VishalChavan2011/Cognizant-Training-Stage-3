using Adapter_HandsOn;
using NUnit.Framework;

namespace NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void whenConvertingMPHToKMPH_thenSuccessFullyConverted()
        {
            Movable bugattiVeyron = new BugattiVeyron();
            MovableAdaptor buggatiVeyronAdaptor = new MovableAdapterImpl(bugattiVeyron);
            Assert.AreEqual(buggatiVeyronAdaptor.getSpeed(),431.30312);
        }

        [Test]
        public void whenConvertingUSDToEuro_thenSuccessFullyConvertes()
        {
            Movable buggatiVeyron = new BugattiVeyron();
            MovableAdaptor buggatiVeyronAdaptor = new MovableAdapterImpl(buggatiVeyron);
            Assert.AreEqual(buggatiVeyronAdaptor.getPrice(), 168.0);
        }
    }
}