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
            if (distanceRule is false) return true;

            bool addressRule = NewUserAddressDoesNotMatchExistingUserAddressRule.IsTrue(newUser.Address, existingUser.Address);
            if (newUser.Name == existingUser.Name && addressRule is false) return true;

            bool referralCodeRule = NewUserReferralCodeMustMatchExistingUserCodeRule.IsTrue(newUser.ReferralCode, existingUser.ReferralCode);
            if (referralCodeRule is false) return true;
            else return false;
        }
    }

}
