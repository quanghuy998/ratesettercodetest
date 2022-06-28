using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.UnitTest.BussinessRulesTest.UserRulesTest
{
    public class NewUserAddressDoesNotMatchExistingUserRuleTest
    {
        [Fact]
        public void GivenNewUserAddress_WhenCheckingRuleWithExistingUserAddress_ThenItShouldReturnFalse()
        {
            var address1 = GivenSampleExistingAddress();
            var address2 = GivenSampleAddress1();

            var result = NewUserAddressDoesNotMatchExistingUserAddressRule.IsTrue(address1, address2);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserAddress_WhenCheckingRuleWithDoesNotExistingUserAddress_ThenItShouldReturnTrue()
        {
            var address1 = GivenSampleExistingAddress();
            var address2 = GivenSampleAddress2();

            var result = NewUserAddressDoesNotMatchExistingUserAddressRule.IsTrue(address1, address2);

            Assert.True(result);
        }

        private Address GivenSampleExistingAddress()
        {
            string streetAddress = "Level 3, 51 Pitt Street";
            string suburb = "Sydney";
            string state = "NSW 2000";
            decimal latitude = 0;
            decimal longitude = 0;
            return new Address(streetAddress, suburb, state, latitude, longitude);
        }

        private Address GivenSampleAddress1()
        {
            string streetAddress = "Level 3,! 51_Pitt Street";
            string suburb = "Sydney";
            string state = "NSW-2000";
            decimal latitude = 0;
            decimal longitude = 0;
            return new Address(streetAddress, suburb, state, latitude, longitude);
        }

        private Address GivenSampleAddress2()
        {
            string streetAddress = "Level 3,! 53_Pitt Street";
            string suburb = "Sydney";
            string state = "NSW-2000";
            decimal latitude = 0;
            decimal longitude = 0;
            return new Address(streetAddress, suburb, state, latitude, longitude);
        }
    }
}
