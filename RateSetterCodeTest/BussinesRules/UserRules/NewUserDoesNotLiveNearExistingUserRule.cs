using RateSetterCodeTest.Models;

namespace RateSetterCodeTest.BussinesRules.UserRules
{
    public class NewUserDoesNotLiveNearExistingUserRule
    {
        private const double MINIMUM_DISTANCE_IN_KM = 0.5;

        public static bool IsTrue(Address newUserAddress, Address existingUserAddress)
        {
            const double RADIUS_OF_EARTH_IN_KM = 6371;
            double latitude1 = ConvertToRadians(newUserAddress.Latitude);
            double latitude2 = ConvertToRadians(existingUserAddress.Latitude);
            double longitude1 = ConvertToRadians(newUserAddress.Longitude);
            double longitude2 = ConvertToRadians(existingUserAddress.Longitude);

            double dlon = longitude2 - longitude1;
            double dlat = latitude2 - latitude1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(latitude1) * Math.Cos(latitude2) *
                        Math.Pow(Math.Sin(dlon / 2), 2);
            double distanceInKM = 2 * Math.Asin(Math.Sqrt(a)) * RADIUS_OF_EARTH_IN_KM;

            if (distanceInKM <= MINIMUM_DISTANCE_IN_KM) return false;
            else return true;
        }

        private static double ConvertToRadians(decimal value)
        {
            return (double)value * Math.PI / 180;
        }
    }
}
