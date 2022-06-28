using RateSetterCodeTest.Models;
using RateSetterCodeTest.Services;

namespace RateSetterCodeTest.UnitTest.BussinessRulesTest.ServiceTest
{
    public class UserMatcherTest
    {
        private readonly UserMatcher _matcher = new();

        [Fact]
        public void GivenNewUserAddress_WhenCheckingWithExistingUserAddressAndUserName_ThenItShouldReturnFalse()
        {
            var newUser = GivenSampleNewUserHaveSameAddressAndName();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserLocation_WhenCheckingWithExistingUserWhoLiveNearby_ThenItShouldReturnFalse()
        {
            var newUser = GivenSampleNewUserHaveLocationNearby();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingWithExistingUserReferralCodeThatNotMatch_ThenItShouldReturnFalse()
        {
            var newUser = GivenSampleNewUserHaveReferralCodeNotMatch();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.False(result);
        }

        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingWithExistingUser_ThenItShouldReturnTrue()
        {
            var newUser = GivenSampleNewUser();
            var existingUser = GivenSampleExistingUser();

            var result = _matcher.IsMatch(newUser, existingUser);

            Assert.True(result);
        }

        private User GivenSampleExistingUser()
        {
            var address = new Address("Level 3, 51 Pitt Street", "Sydney", "NSW 2000", 0, 0.2m);
            return new User(address, "Gullaume Musso", "ABC123");
        }

        private User GivenSampleNewUserHaveSameAddressAndName()
        {
            var address = new Address("Level 3, 51 Pitt Street", "Sydney", "NSW 2000", 0, 0.2m);
            return new User(address, "Gullaume Musso", "ABC321");
        }

        private User GivenSampleNewUserHaveLocationNearby()
        {
            var address = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW 2000", 0.001m, 0.201m);
            return new User(address, "Marc Levy", "ABC321");
        }

        private User GivenSampleNewUserHaveReferralCodeNotMatch()
        {
            var address = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW 2000", 1, 1);
            return new User(address, "Marc Levy", "ABC213");
        }

        private User GivenSampleNewUser()
        {
            var address = new Address("Level 1, 49 Pitt Street", "Sydney", "NSW 2000", 1, 1);
            return new User(address, "Marc Levy", "ABC321");
        }
    }
}
