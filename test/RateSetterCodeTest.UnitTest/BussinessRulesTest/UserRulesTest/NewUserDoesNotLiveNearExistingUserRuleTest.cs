using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.UnitTest.BussinessRulesTest.UserRulesTest
{
    public class NewUserDoesNotLiveNearExistingUserRuleTest
    {
        [Fact]
        public void GivenNewUserLocation_WhenCheckingRuleWithExistingUserWhoDoesNotLiveNearby_ThenItShouldReturnTrue()
        {
            var address1 = GivenSampleExistingAddress();
            var address2 = GivenSampleAddressNotNearby();

            var result = NewUserDoesNotLiveNearExistingUserRule.IsTrue(address1, address2);

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserLocation_WhenCheckingRuleWithExistingUserWhoLiveNearby_ThenItShouldReturnFalse()
        {
            var address1 = GivenSampleExistingAddress();
            var address2 = GivenSampleAddressNearby();

            var result = NewUserDoesNotLiveNearExistingUserRule.IsTrue(address1, address2);

            Assert.False(result);
        }

        private Address GivenSampleExistingAddress()
        {
            string streetAddress = "Level 3, 51 Pitt Street";
            string suburb = "Sydney";
            string state = "NSW 2000";
            decimal latitude = 0;
            decimal longitude = 0.2m;

            return new Address(streetAddress, suburb, state, latitude, longitude);
        }

        private Address GivenSampleAddressNearby()
        {
            string streetAddress = "Level 3, 51 Pitt Street";
            string suburb = "Sydney";
            string state = "NSW 2000";
            decimal latitude = 0.001m;
            decimal longitude = 0.201m;

            return new Address(streetAddress, suburb, state, latitude, longitude);
        }

        private Address GivenSampleAddressNotNearby()
        {
            string streetAddress = "Level 3, 51 Pitt Street";
            string suburb = "Sydney";
            string state = "NSW 2000";
            decimal latitude = 1;
            decimal longitude = 1;

            return new Address(streetAddress, suburb, state, latitude, longitude);
        }
    }
}
