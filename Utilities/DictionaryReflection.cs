using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Data.Users;

namespace OODProj.Utilities
{
    public class DictionaryReflection
    {
        public static Dictionary<string, Dictionary<string, Func<IPrimaryKeyed, string>>> Getter
           => new()
           {
               {
                   "CargoPlane",
                   new()
                    {
                        { "ID", plane => ((CargoPlane)plane).ID.ToString() },
                        { "Serial", plane => ((CargoPlane)plane).Serial },
                        { "Country", plane => ((CargoPlane)plane).Country },
                        { "Model", plane => ((CargoPlane)plane).Model },
                        { "MaxLoad", plane => ((CargoPlane)plane).MaxLoad.ToString()}
                    }
               },
               {
                   "PassengerPlane",
                   new()
                    {
                        { "ID", plane => ((PassengerPlane)plane).ID.ToString() },
                        { "Serial",plane => ((PassengerPlane)plane).Serial },
                        { "Country", plane => ((PassengerPlane)plane).Country },
                        { "Model", plane => ((PassengerPlane)plane).Model },
                        { "FirstClassSize", plane => ((PassengerPlane)plane).FirstClassSize.ToString() },
                        { "BusinessClassSize", plane => ((PassengerPlane)plane).BusinessClassSize.ToString() },
                        { "EconomyClassSize", plane => ((PassengerPlane)plane).EconomyClassSize.ToString() }
                    }
               },
               {
                   "Crew",
                   new()
                    {
                         { "ID", crew => ((Crew)crew).ID.ToString() },
                         { "Name", crew => ((Crew)crew).Name },
                         { "Age", crew => ((Crew)crew).Age.ToString() },
                         { "Phone", crew => ((Crew)crew).Phone },
                         { "Email", crew => ((Crew)crew).Email },
                         { "Practice", crew => ((Crew)crew).Practice.ToString() },
                         { "Role", crew => ((Crew)crew).Role }
                    }
               },
               {
                   "Passenger",
                   new()
                    {
                        { "ID", p => ((Passenger)p).ID.ToString() },
                        { "Name", p => ((Passenger)p).Name },
                        { "Age", p => ((Passenger)p).Age.ToString() },
                        { "Phone", p => ((Passenger)p).Phone },
                        { "Email", p => ((Passenger)p).Email },
                        { "Class", p => ((Passenger)p).Class },
                        { "Miles", p => ((Passenger)p).Miles.ToString() }
                    }
               },
               {
                   "Airport",
                   new()
                    {
                        {"ID", (x) => ((Airport)x).ID.ToString()},
                        {"Name", (x) => ((Airport)x).Name},
                        { "Code", (x) => ((Airport)x).Code},
                        { "Longitude", (x) => ((Airport)x).Longitude.ToString()},
                        { "Latitude", (x) => ((Airport)x).Latitude.ToString()},
                        { "AMSL", (x) => ((Airport)x).AMSL.ToString()},
                        { "Country", (x) => ((Airport)x).Country}
                    }
               },
               {
                   "Cargo",
                   new()
                    {
                        { "ID", (x) => ((Cargo)x).ID.ToString() },
                        { "Weight", (x) => ((Cargo)x).Weight.ToString() },
                        { "Code", (x) => ((Cargo)x).Code },
                        { "Description", (x) => ((Cargo)x).Description}
                    }
               },
               {
                   "Flight",
                   new()
                    {
                        { "ID", (x) => ((Flight)x).ID.ToString() },
                        { "IDOrigin", (x) => ((Flight)x).IDOrigin.ToString() },
                        { "IDTarget", (x) => ((Flight)x).IDTarget.ToString() },
                        { "TakeoffTime", (x) => ((Flight)x).TakeoffTime.ToString() },
                        { "LandingTime", (x) => ((Flight)x).LandingTime.ToString() },
                        { "WorldPosition.Long", (x) => ((Flight)x).Longitude.ToString() },
                        { "WorldPosition.Lat", (x) => ((Flight)x).Latitude.ToString() },
                        { "AMSL", (x) => ((Flight)x).AMSL.ToString() },
                        { "IDPlane", (x) => ((Flight)x).IDPlane.ToString() }
                    }
               }
           };

        public static Dictionary<string, Dictionary<string, Action<IPrimaryKeyed, string>>> Setter
             => new()
             {
                {
                   "CargoPlane",
                   new()
                    {
                        { "ID", (plane, value) => ((CargoPlane)plane).ID = ulong.Parse(value) },
                        { "Serial", (plane, value) => ((CargoPlane)plane).Serial = value },
                        { "Country", (plane, value) =>((CargoPlane) plane).Country = value },
                        { "Model", (plane, value) =>((CargoPlane) plane).Model = value },
                        { "MaxLoad", (plane, value) =>((CargoPlane) plane).MaxLoad = float.Parse(value)}
                    }
               },
               {
                   "PassengerPlane",
                   new()
                    {
                        { "ID", (plane, value) =>((PassengerPlane) plane).ID = ulong.Parse(value) },
                        { "Serial",(plane, value) =>((PassengerPlane) plane).Serial = value  },
                        { "Country", (plane, value) =>((PassengerPlane) plane).Country = value },
                        { "Model", (plane, value) =>((PassengerPlane) plane).Model = value },
                        { "FirstClassSize", (plane, value) =>((PassengerPlane) plane).FirstClassSize = ushort.Parse(value) },
                        { "BusinessClassSize", (plane, value) =>((PassengerPlane) plane).BusinessClassSize = ushort.Parse(value) },
                        { "EconomyClassSize", (plane, value) =>((PassengerPlane) plane).EconomyClassSize = ushort.Parse(value) }
                    }
               },
               {
                   "Crew",
                   new()
                    {
                         { "ID", (crew, value) =>((Crew) crew).ID = ulong.Parse(value) },
                         { "Name", (crew, value) =>((Crew) crew).Name = value },
                         { "Age", (crew, value) =>((Crew) crew).Age = ulong.Parse(value) },
                         { "Phone", (crew, value) =>((Crew) crew).Phone = value },
                         { "Email", (crew, value) =>((Crew) crew).Email = value },
                         { "Practice", (crew, value) =>((Crew) crew).Practice = ushort.Parse(value) },
                         { "Role", (crew, value) =>((Crew) crew).Role = value }
                    }
               },
               {
                   "Passenger",
                   new()
                    {
                        { "ID", (p, value) =>((Passenger) p).ID = ulong.Parse(value) },
                        { "Name", (p, value) =>((Passenger) p).Name = value },
                        { "Age", (p, value) =>((Passenger) p).Age = ulong.Parse(value) },
                        { "Phone", (p, value) =>((Passenger) p).Phone = value },
                        { "Email", (p, value) =>((Passenger) p).Email = value },
                        { "Class", (p, value) =>((Passenger) p).Class = value },
                        { "Miles", (p, value) =>((Passenger) p).Miles = ulong.Parse(value) }
                    }
               },
               {
                   "Airport",
                   new()
                    {
                        {"ID", (x, value) => ((Airport)x).ID = ulong.Parse(value)},
                        {"Name", (x, value) => ((Airport)x).Name = value},
                        { "Code", (x, value) => ((Airport)x).Code = value},
                        { "Longitude", (x, value) => ((Airport)x).Longitude = float.Parse(value)},
                        { "Latitude", (x, value) => ((Airport)x).Latitude = float.Parse(value)},
                        { "AMSL", (x, value) => ((Airport) x).AMSL = float.Parse(value)},
                        { "Country", (x, value) =>{var air = x as Airport; ArgumentNullException.ThrowIfNull(air); air.Country = value; } }
                    }
               },
               {
                   "Cargo",
                   new()
                    {
                        { "ID", (x, value) => ((Cargo)x).ID = ulong.Parse(value) },
                        { "Weight", (x, value) => ((Cargo)x).Weight = float.Parse(value) },
                        { "Code", (x, value) => ((Cargo)x).Code = value },
                        { "Description", (x, value) =>((Cargo) x).Description = value}
                    }
               },
               {
                   "Flight",
                   new()
                    {
                        { "ID", (x, value) => ((Flight)x).ID = ulong.Parse(value) },
                        { "IDOrigin", (x, value) => ((Flight)x).IDOrigin = ulong.Parse(value) },
                        { "IDTarget", (x, value) => ((Flight) x).IDTarget = ulong.Parse(value) },
                        { "TakeoffTime", (x, value) => ((Flight)x).TakeoffTime = TimeOnly.Parse(value) },
                        { "LandingTime", (x, value) => ((Flight)x).LandingTime = TimeOnly.Parse(value) },
                        { "WorldPosition.Long", (x, value) => ((Flight) x).Longitude = float.Parse(value) },
                        { "WorldPosition.Lat", (x, value) => ((Flight) x).Latitude = float.Parse(value) },
                        { "AMSL", (x, value) => ((Flight) x).AMSL = float.Parse(value) },
                        { "IDPlane", (x, value) => ((Flight) x).IDPlane = ulong.Parse(value) }
                    }
               }
       };

        public static Dictionary<string, Func<IPrimaryKeyed, string, string, string, bool>> Comparer
            => new()
                {
                   { ">=",  GreaterThan },
                   { "<=", LessThan },
                   { "=",  Equal },
                   { "!=",  NotEqual }
                };

        public static Dictionary<string, Func<bool, bool, bool>> LogicOperator
            => new()
                {
                   { "or", (left, right) => left || right  },
                   { "and", (left, right) => left && right }
                };

        private static bool GreaterThan(IPrimaryKeyed obj, string nameClass, string property, string constant)
        {
            string propertyValue = Getter[nameClass][property](obj);

            if (float.TryParse(propertyValue, out float flValue) && float.TryParse(constant, out float flConstant))
                return flValue >= flConstant;

            if (long.TryParse(propertyValue, out long lValue) && long.TryParse(constant, out long lConstant))
                return lValue >= lConstant;

            return string.Compare(propertyValue, constant) < 0;
        }

        private static bool LessThan(IPrimaryKeyed obj, string nameClass, string property, string constant)
        {
            string propertyValue = Getter[nameClass][property](obj);

            if (float.TryParse(propertyValue, out float flValue) && float.TryParse(constant, out float flConstant))
                return flValue <= flConstant;

            if (long.TryParse(propertyValue, out long lValue) && long.TryParse(constant, out long lConstant))
                return lValue <= lConstant;

            return string.Compare(propertyValue, constant) > 0;
        }

        private static bool Equal(IPrimaryKeyed obj, string nameClass, string property, string constant)
        {
            string propertyValue = Getter[nameClass][property](obj);

            if (float.TryParse(propertyValue, out float flValue) && float.TryParse(constant, out float flConstant))
                return flValue == flConstant;

            if (long.TryParse(propertyValue, out long lValue) && long.TryParse(constant, out long lConstant))
                return lValue == lConstant;

            return string.Compare(propertyValue, constant) == 0;
        }

        private static bool NotEqual(IPrimaryKeyed obj, string nameClass, string property, string constant)
        {
            string propertyValue = Getter[nameClass][property](obj);

            if (float.TryParse(propertyValue, out float flValue) && float.TryParse(constant, out float flConstant))
                return flValue != flConstant;

            if (long.TryParse(propertyValue, out long lValue) && long.TryParse(constant, out long lConstant))
                return lValue != lConstant;

            return !(string.Compare(propertyValue, constant) == 0);
        }

        //Unfortunately, It is not allowed to use the following code on Stage 6 OOD:__((((

        //public static Dictionary<string, Func<List<string>, LambdaExpression>> Comparer
        //    => new()
        //        {
        //           { ">=", CreateGreaterThanExpression },
        //           { "<=", CreateLessThanExpression },
        //           { "=",  CreateEqualExpression },
        //           { "!=",  CreateNotEqualExpression }
        //        };

        //public static Dictionary<string, Func<LambdaExpression, LambdaExpression, LambdaExpression>> LogicOperator
        //    => new()
        //        {
        //           { "or", CreateOrExpression },
        //           { "and", CreateAndExpression }
        //        };

        //private static LambdaExpression CreateLessThanExpression (List<string> stringExpression)
        //{
        //    ParameterExpression propertyParameter = Expression.Parameter(typeof(ulong), stringExpression[0]);
        //    ParameterExpression constantParameter = Expression.Parameter(typeof(ulong), stringExpression[1]);
        //    return Expression.Lambda(Expression.LessThanOrEqual(propertyParameter, constantParameter), propertyParameter, constantParameter);
        //}

        //private static LambdaExpression CreateGreaterThanExpression(List<string> stringExpression)
        //{
        //    ParameterExpression propertyParameter = Expression.Parameter(typeof(ulong), stringExpression[0]);
        //    ParameterExpression constantParameter = Expression.Parameter(typeof(ulong), stringExpression[1]);
        //    return Expression.Lambda(Expression.LessThanOrEqual(propertyParameter, constantParameter), propertyParameter, constantParameter);
        //}

        //private static LambdaExpression CreateEqualExpression(List<string> stringExpression)
        //{
        //    ParameterExpression propertyParameter = Expression.Parameter(typeof(ulong), stringExpression[0]);
        //    ParameterExpression constantParameter = Expression.Parameter(typeof(ulong), stringExpression[1]);
        //    return Expression.Lambda(Expression.Equal(propertyParameter, constantParameter), propertyParameter, constantParameter);
        //}

        //private static LambdaExpression CreateNotEqualExpression(List<string> stringExpression)
        //{
        //    ParameterExpression propertyParameter = Expression.Parameter(typeof(ulong), stringExpression[0]);
        //    ParameterExpression constantParameter = Expression.Parameter(typeof(ulong), stringExpression[1]);
        //    return Expression.Lambda(Expression.NotEqual(propertyParameter, constantParameter), propertyParameter, constantParameter);
        //}

        //private static LambdaExpression CreateOrExpression(LambdaExpression left, LambdaExpression right)
        //{
        //    return Expression.Lambda(Expression.OrElse(left, right));
        //}

        //private static LambdaExpression CreateAndExpression(LambdaExpression left, LambdaExpression right)
        //{
        //    return Expression.Lambda(Expression.AndAlso(left, right));
        //}

    }

}
