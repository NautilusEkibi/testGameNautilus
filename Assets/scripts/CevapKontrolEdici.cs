using UnityEngine.SceneManagement;

public static class CevapKontrolEdici
{
    public static bool CevabiKontrolEt(string girilenCevap, out bool cevapVar)
    {
        cevapVar = false;
        if (!DersSecimVerisi.OrtaokulMu) return false;

        string beklenenCevap = BeklenenCevabiBul();
        if (string.IsNullOrEmpty(beklenenCevap)) return false;

        cevapVar = true;
        return CevaplariEsitMi(girilenCevap, beklenenCevap);
    }

    public static void AnaMenuyeDon()
    {
        DersSecimVerisi.AnaMenuyeDon();
        SceneManager.LoadScene("girisMenusu");
    }

    private static string BeklenenCevabiBul()
    {
        int ders = DersSecimVerisi.SeciliDers;
        int sinif = DersSecimVerisi.SeciliSinif;

        if (ders == DersSecimVerisi.Fen)
        {
            if (sinif == 5) return Fen5Cevaplari();
            if (sinif == 6) return Fen6Cevaplari();
            if (sinif == 7) return Fen7Cevaplari();
            if (sinif == 8) return Fen8Cevaplari();
        }

        if (ders == DersSecimVerisi.Matematik)
        {
            if (sinif == 5) return Matematik5Cevaplari();
            if (sinif == 6) return Matematik6Cevaplari();
            if (sinif == 7) return Matematik7Cevaplari();
            if (sinif == 8) return Matematik8Cevaplari();
        }

        if (ders == DersSecimVerisi.Turkce)
        {
            if (sinif == 5) return Turkce5Cevaplari();
            if (sinif == 6) return Turkce6Cevaplari();
            if (sinif == 7) return Turkce7Cevaplari();
            if (sinif == 8) return Turkce8Cevaplari();
        }

        return string.Empty;
    }

    private static string Fen5Cevaplari() { return string.Empty; }
    private static string Fen6Cevaplari() { return string.Empty; }
    private static string Fen7Cevaplari() { return string.Empty; }

    private static string Fen8Cevaplari()
    {
        if (DersSecimVerisi.SeciliUnite == 2 && DersSecimVerisi.SeciliAltKonu == 3)
            return "40 Pa";
        return string.Empty;
    }

    private static string Matematik5Cevaplari() { return string.Empty; }
    private static string Matematik6Cevaplari() { return string.Empty; }
    private static string Matematik7Cevaplari() { return string.Empty; }
    private static string Matematik8Cevaplari() { return string.Empty; }
    private static string Turkce5Cevaplari() { return string.Empty; }
    private static string Turkce6Cevaplari() { return string.Empty; }
    private static string Turkce7Cevaplari() { return string.Empty; }
    private static string Turkce8Cevaplari() { return string.Empty; }

    private static bool CevaplariEsitMi(string girilenCevap, string beklenenCevap)
    {
        return Duzenle(girilenCevap) == Duzenle(beklenenCevap);
    }

    private static string Duzenle(string cevap)
    {
        return (cevap ?? string.Empty).Trim().ToLowerInvariant()
            .Replace(" ", "").Replace("\u00a0", "").Replace(",", ".");
    }
}
