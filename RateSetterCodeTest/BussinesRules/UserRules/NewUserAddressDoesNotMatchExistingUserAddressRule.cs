﻿using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.BussinesRules.UserRules
{
    public class NewUserAddressDoesNotMatchExistingUserAddressRule
    {
        public static bool IsTrue(Address newUserAddress, Address existingUserAddress)
        {
            string address1 = RemoveCharacter(newUserAddress.GetAddress());
            string address2 = RemoveCharacter(existingUserAddress.GetAddress());
            
            if (address1 != address2) return true;
            else return false;
        }

        private static string RemoveCharacter(string str)
        {
            string[] unsualCharacters = new string[] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "?" };
            string[] spaceCharacters = new string[] { "_", "-" };

            foreach (var character in unsualCharacters)
            {
                str = str.Replace(character, string.Empty);
            }

            foreach (var character in spaceCharacters)
            {
                str = str.Replace(character, " ");
            }

            return str;
        }
    }
}
