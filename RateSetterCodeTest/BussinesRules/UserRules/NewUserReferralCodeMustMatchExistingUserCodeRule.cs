﻿using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.BussinesRules.UserRules
{
    public class NewUserReferralCodeMustMatchExistingUserCodeRule
    {
        public static bool IsTrue(string referralCode1, string referralCode2)
        {
            var array1 = referralCode1.ToArray();
            var array2 = referralCode2.ToArray();

            for (int i = 0; i < array1.Length - 2; i++)
            {
                var swappedArray1 = SwapIndex(array1, i, i + 2);
                var result = CompareTwoArray(swappedArray1, array2);
                if (result) return true;
            }

            return false;
        }

        private static bool CompareTwoArray(char[] arr1, char[] arr2)
        {
            if (arr1 == null || arr2 == null || arr1.Length != arr2.Length)
            {
                return false;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }

            return true;
        }

        private static char[] SwapIndex(char[] array, int index1, int index2)
        {
            if (array.Length <= index1 || array.Length <= index2) throw new InvalidDataException("Index of referral code is over the data length.");

            var newArray = new char[array.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = array[i];
            }

            char temp = newArray[index1];
            newArray[index1] = newArray[index2];
            newArray[index2] = temp;

            return newArray;
        }
    }
}
