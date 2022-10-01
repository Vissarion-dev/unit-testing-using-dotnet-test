using Moq;
using Prime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prime.Services.PriceCalculator;

namespace Prime.UnitTests.Calculator
{
    public class PriceCalculator_Tests
    {
        [Fact]
        public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
        {
            var priceCalculator = new PriceCalculator();
            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Monday);

            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub.Object);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
        {
            var priceCalculator = new PriceCalculator();
            var dateTimeProviderStub = new Mock<IDateTimeProvider>();
            dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Tuesday);

            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub.Object);

            Assert.Equal(1, actual);
        }
    }
}
