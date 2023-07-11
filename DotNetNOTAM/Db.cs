namespace NotamStore.DB; 

public record Notam 
{
    public int Id {get; init;} 
    public string ? Description { get; set; }
    public string ? ICAO { get; set; }
}

public class NotamDB
{
    private static List<Notam> _notams = new List<Notam>()
    {
        new Notam{ Id=1, ICAO = "KGEG", Description = "GEG 05/001 GEG OBST TOWER LGT (ASR 1021214) 474738.00N1173212.00W (4.5NM ENE GEG) 2319.9FT (319.9FT AGL) OUT OF SERVICE 2105010000-2105150000"},
        new Notam{ Id=2, ICAO = "KLAX", Description = "LAX 05/001 LAX OBST CRANE (ASN UNKNOWN) 340119N1182123W (0.5NM WSW LAX) 105FT (100FT AGL) FLAGGED AND LGTD 2105010000-2105150000"},
        new Notam{ Id=3, ICAO = "KSFO", Description = "SFO 05/001 SFO OBST CRANE (ASN UNKNOWN) 375953N1222312W (0.5NM WNW SFO) 100FT (90FT AGL) FLAGGED AND LGTD 2105010000-2105150000"}, 
    };

    public static List<Notam> GetNotams() 
    {
        return _notams;
    } 

    public static Notam ? GetNotams(int id) 
    {
        return _notams.SingleOrDefault(notam => notam.Id == id);
    }

    public static Notam CreateNotam(Notam notam) 
    {
        _notams.Add(notam);
        return notam;
    }

    public static Notam UpdateNotam(Notam update) 
    {
        _notams = _notams.Select(notam =>
        {
            if (notam.Id == update.Id)
            {
                notam.Description = update.Description;
                notam.ICAO = update.ICAO;
            }
            return notam;
        }).ToList();
        return update;
    }

    public static void RemoveNotam(int id)
    {
        _notams = _notams.FindAll(notam => notam.Id != id).ToList();
    }
}