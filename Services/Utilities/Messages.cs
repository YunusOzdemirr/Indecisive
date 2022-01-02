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
            public static string IsExistArgument()
            {
                return "Bu nesne zaten mevcut";
            }
            public static string NotFoundArgument()
            {
                return "Böyle bir nesne bulunamadı";
            }
        }
    }
}

