using Microsoft.AspNetCore.Http; //namespace gives access to ISession
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBoardApp.Extensions
{
    public static class SessionExtensions
    {
        //Extension methods to get and set objects from/in the session
        public static void SetObjectAsJson<T>(this ISession session, string key, T value)
        {
            //set as a string in JSON form
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            //retrieve object from JSON
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
