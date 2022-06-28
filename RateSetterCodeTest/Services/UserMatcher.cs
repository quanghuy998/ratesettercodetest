using RateSetterCodeTest.BussinesRules;
using RateSetterCodeTest.BussinesRules.UserRules;
using RateSetterCodeTest.Interface;
using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.Services
{
    public class UserMatcher : IUserMatcher
    {
        public bool IsMatch(User newUser, User existingUser)
        {
            bool distanceRule = NewUserDoesNotLiveNearExistingUserRule.IsTrue(newUser.Address, existingUser.Address);
            if (distanceRule is false) return false;

            bool isMatchAddress = NewUserAddressDoesNotMatchExistingUserAddressRule.IsTrue(newUser.Address, existingUser.Address);
            if (newUser.Name == existingUser.Name && isMatchAddress is false) return false;

            bool isMatchReferralCode = NewUserReferralCodeMustMatchExistingUserCodeRule.IsTrue(newUser.ReferralCode, existingUser.ReferralCode);
            if(isMatchReferralCode is false) return false;

            return true;
        }
    }

}
