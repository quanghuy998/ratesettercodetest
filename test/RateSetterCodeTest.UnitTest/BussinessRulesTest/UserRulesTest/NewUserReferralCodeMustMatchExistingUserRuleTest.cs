using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.UnitTest.BussinessRulesTest.UserRulesTest
{
    public class NewUserReferralCodeMustMatchExistingUserRuleTest
    {
        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingRulMatchExistingUserReferralCode_ThenItShouldReturnTrue()
        {
            bool result = false;
            var existingUserReferralCode = GivenSampleExistingUserReferralCode();
            var newUserReferralCodes = GivenSomeSampleNewUserRefferralCodesMatch();

            foreach(var code in newUserReferralCodes)
            {
                result = NewUserReferralCodeMustMatchExistingUserCodeRule.IsTrue(existingUserReferralCode, code);
                if (result is false) break;
            }

            Assert.True(result);
        }

        [Fact]
        public void GivenNewUserReferralCode_WhenCheckingRulMatchExistingUserReferralCode_ThenItShouldReturnFalse()
        {
            var existingUserReferralCode = GivenSampleExistingUserReferralCode();
            var newUserReferralCode = GivenSampleNewUserRefferralCodeNotMatch();

            var result = NewUserReferralCodeMustMatchExistingUserCodeRule.IsTrue(existingUserReferralCode, newUserReferralCode);

            Assert.False(result);
        }

        private string GivenSampleExistingUserReferralCode()
        {
            return "ABC123";
        }

        private string[] GivenSomeSampleNewUserRefferralCodesMatch()
        {
            return new string[] { "CBA123", "A1CB23", "AB21C3", "ABC321" };
        }

        private string GivenSampleNewUserRefferralCodeNotMatch()
        {
            return "ABC312";
        }
    }
}
