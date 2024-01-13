namespace WebAPICSharpEVProject.Models.Respositories
{
    public class Repository
    {
        private static List<SugarCookies> scookies = new List<SugarCookies>()
 {
 new SugarCookies {Id = 1, Flavour ="Vanilla", CType = "Decorated", Size = 6, Price = 20},
 new SugarCookies {Id = 2, Flavour ="Chocolate", CType = "Plain", Size = 12, Price = 30},
 new SugarCookies {Id = 3, Flavour ="Caramel", CType = "Decorated", Size = 6, Price = 20},
 new SugarCookies {Id = 4, Flavour ="Vanilla", CType = "Plain", Size = 12, Price = 30},
 new SugarCookies {Id = 5, Flavour ="Spice", CType = "Decorated", Size = 12, Price = 40}

 };
        
        public static List<SugarCookies> GetSCookies()
        {
            return scookies;
        }
        public static bool SCookieExists(int id)
        {
            return scookies.Any(x => x.Id == id);
        }
        public static SugarCookies? GetSCookieById(int id)
        {
            return scookies.FirstOrDefault(x => x.Id == id);
        }
        public static SugarCookies? GetSCookieByProperties(int id, string? flavour, string? CType, int? size, float? price)
        {
            return scookies.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(flavour) &&
            !string.IsNullOrWhiteSpace(x.Flavour) &&
            x.Flavour.Equals(flavour, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(CType) &&
            !string.IsNullOrWhiteSpace(x.CType) &&
            x.CType.Equals(CType, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue &&
            size.Value == x.Size.Value &&
            price.HasValue &&
            x.Price.HasValue &&
            price.Value == x.Price.Value
            );
        }
        public static void AddSCookie(SugarCookies scookie)
        {
            int maxId = scookies.Count > 0 ? scookies.Max(x => x.Id) : 0;
            scookie.Id = maxId + 1;
            scookies.Add(scookie);
        }

        public static void UpdateSCookie(SugarCookies scookie)
        {
            var scookieToUpdate = scookies.FirstOrDefault(x => x.Id == scookie.Id);
            scookieToUpdate.Flavour = scookie.Flavour;
            scookieToUpdate.CType = scookie.CType;
            scookieToUpdate.Size = scookie.Size;
            scookieToUpdate.Price = scookie.Price;

        }

        public static void DeleteSCookie(int id)
        {
            var scookieToDelete = GetSCookieById(id);

            if (scookieToDelete != null)
            {
                scookies.Remove(scookieToDelete);
            }
        }

        internal static object GetSCookieByProperties(string? flavour, string? cType, int? size, float? price)
        {
            //throw new NotImplementedException();
            return "Nope";
        }
    }
}