using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Mission09_toapita.Infrastructure
{
    //We were told to just copy paste this section so I'm not 100% on what it does
    //My best guess is that we are creating a static class with static methods. One of which
    //Turns objects into JSON strings and one of which takes JSON strings and converts it back to an object of a
    //certain type
    public static class SessionsExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
