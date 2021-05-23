using System;

namespace Games.Service.Validation
{
    public static class Validations
    { 
        public static void IsTrue(this bool value, string msg)
        {
            if (!value) throw new Exception(msg);
        }
        public static void IsNotTrue(this bool value, string msg)
        {
            if (value) throw new Exception(msg);
        }
        public static void IsNotNull(this object value, string msg)
        {
            if (value == null) throw new Exception(msg);
        }        
    }
}
