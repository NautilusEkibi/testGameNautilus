using TMPro;
using UnityEngine;

public class UniteKoridorYoneticisi : MonoBehaviour
{
    public GameObject sinif6Kapilari;
    public GameObject sinif7Kapilari;
    public GameObject sinif8Kapilari;
    public GameObject sinif5Kapilari;
    public GameObject matematik5Gorselleri;
    public GameObject matematik6Gorselleri;
    public GameObject matematik7Gorselleri;
    public GameObject matematik8Gorselleri;
    public GameObject turkce5Gorselleri;
    public GameObject turkce6Gorselleri;
    public GameObject turkce7Gorselleri;
    public GameObject turkce8Gorselleri;

    public static int seciliUnite => DersSecimVerisi.SeciliUnite;

    private void OnEnable()
    {
        GorselleriGuncelle();
    }

    private void Start()
    {
        GorselleriGuncelle();
    }

    public void GorselleriGuncelle()
    {
        GorselGoster(sinif5Kapilari, DersSecimVerisi.Fen, 5);
        GorselGoster(sinif6Kapilari, DersSecimVerisi.Fen, 6);
        GorselGoster(sinif7Kapilari, DersSecimVerisi.Fen, 7);
        GorselGoster(sinif8Kapilari, DersSecimVerisi.Fen, 8);
        GorselGoster(matematik5Gorselleri, DersSecimVerisi.Matematik, 5);
        GorselGoster(matematik6Gorselleri, DersSecimVerisi.Matematik, 6);
        GorselGoster(matematik7Gorselleri, DersSecimVerisi.Matematik, 7);
        GorselGoster(matematik8Gorselleri, DersSecimVerisi.Matematik, 8);
        GorselGoster(turkce5Gorselleri, DersSecimVerisi.Turkce, 5);
        GorselGoster(turkce6Gorselleri, DersSecimVerisi.Turkce, 6);
        GorselGoster(turkce7Gorselleri, DersSecimVerisi.Turkce, 7);
        GorselGoster(turkce8Gorselleri, DersSecimVerisi.Turkce, 8);
    }

    private static void GorselGoster(GameObject gorseller, int ders, int sinif)
    {
        if (gorseller == null) return;

        bool secili = DersSecimVerisi.OrtaokulMu &&
                      DersSecimVerisi.SeciliDers == ders &&
                      DersSecimVerisi.SeciliSinif == sinif;
        gorseller.SetActive(secili);
        if (secili)
            KapilariGuncelle(gorseller, ders, sinif);
    }

    private static void KapilariGuncelle(GameObject grup, int ders, int sinif)
    {
        string[] altKonular = DersSecimVerisi.AltKonuEkraniAcik
            ? DersIcerikKatalogu.AltKonuBasliklari(ders, sinif, DersSecimVerisi.SeciliUnite)
            : null;

        for (int kapiNo = 1; kapiNo <= 7; kapiNo++)
        {
            Transform kapiMetni = grup.transform.Find("Unite " + kapiNo + " Metni");
            if (kapiMetni == null) continue;

            TMP_Text metin = kapiMetni.GetComponent<TMP_Text>();
            if (metin == null) continue;

            if (DersSecimVerisi.AltKonuEkraniAcik)
            {
                metin.text = kapiNo <= altKonular.Length ? altKonular[kapiNo - 1] : "X";
            }
            else
            {
                string uniteBasligi = DersIcerikKatalogu.UniteBasligi(ders, sinif, kapiNo);
                metin.text = string.IsNullOrEmpty(uniteBasligi)
                    ? string.Empty
                    : "<size=90%><b>" + kapiNo + ".Ünite</b></size>\n" + uniteBasligi;
            }
        }
    }
}
