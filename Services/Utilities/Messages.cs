using System;
namespace Services.Utilities
{
    public static class Messages
    {
        public static class General
        {
            public static string ValidationError()
            {
                return "Bir veya daha fazla validasyon hatası ile karşılaşıldı";
            }
            public static string IsExistArgument(string argumentName)
            {
                return $"Bu {argumentName} zaten mevcut";
            }
            public static string NotFoundArgument(string argumentName)
            {
                return $"Böyle bir {argumentName} bulunamadı";
            }
        }
    }
}

