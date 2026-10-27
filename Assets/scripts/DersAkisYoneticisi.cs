using UnityEngine;
using UnityEngine.UI;

public class DersAkisYoneticisi : MonoBehaviour
{
    public GameObject asansor;
    public GameObject fenBilgisi;
    public GameObject girisBilgisi;
    public GameObject asansorPaneli;
    public GameObject katPaneli;
    public GameObject uniteKoridoru;
    public UniteKoridorYoneticisi uniteKoridorYoneticisi;
    public LevelGecisYoneticisi levelGecisYoneticisi;

    public Button ortaokulFenButonu;
    public Button ortaokulMatematikButonu;
    public Button ortaokulTurkceButonu;
    public Button liseFizikButonu;
    public Button liseKimyaButonu;
    public Button liseMatematikButonu;
    public Button liseBiyolojiButonu;
    public Button[] katButonlari;
    public Button[] liseKatButonlari;
    public Button[] uniteButonlari;

    // 0=belli değil, 1=ortaokul fen, 2=ortaokul matematik, 3=ortaokul Türkçe,
    // 4=lise fizik, 5=lise kimya, 6=lise matematik, 7=lise biyoloji.
    public static int seciliDers = 0;
    // 0=belli değil, 5, 6, 7 veya 8=sınıf.
    public static int seciliSinif = 0;
    public static bool ortaOkulMu = true;

    private void Start()
    {
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(false);
        if (uniteKoridoru != null) uniteKoridoru.SetActive(false);

        Bagla(ortaokulFenButonu, FenSec);
        Bagla(ortaokulMatematikButonu, OrtaokulMatematikSec);
        Bagla(ortaokulTurkceButonu, OrtaokulTurkceSec);
        Bagla(liseFizikButonu, LiseFizikSec);
        Bagla(liseKimyaButonu, LiseKimyaSec);
        Bagla(liseMatematikButonu, LiseMatematikSec);
        Bagla(liseBiyolojiButonu, LiseBiyolojiSec);

        for (int i = 0; katButonlari != null && i < katButonlari.Length; i++)
        {
            int sinif = i + 5;
            Bagla(katButonlari[i], () => KatSec(sinif));
        }

        for (int i = 0; liseKatButonlari != null && i < liseKatButonlari.Length; i++)
        {
            int sinif = i + 9;
            Bagla(liseKatButonlari[i], () => KatSec(sinif));
        }

        for (int i = 0; uniteButonlari != null && i < uniteButonlari.Length; i++)
        {
            int unite = i + 1;
            Bagla(uniteButonlari[i], () => UniteSec(unite));
        }
    }

    private void Bagla(Button buton, UnityEngine.Events.UnityAction islem)
    {
        if (buton != null) buton.onClick.AddListener(islem);
    }

    public void FenSec()
    {
        ortaOkulMu = true;
        seciliDers = 1;
        seciliSinif = 0;
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(true);
        if (fenBilgisi != null) fenBilgisi.SetActive(true);
        if (girisBilgisi != null) girisBilgisi.SetActive(false);
        uniteKoridorYoneticisi?.GorselleriGuncelle();
    }

    private void OrtaokulMatematikSec() { DersSec(2, true); }
    private void OrtaokulTurkceSec() { DersSec(3, true); }
    private void LiseFizikSec() { DersSec(4, false); }
    private void LiseKimyaSec() { DersSec(5, false); }
    private void LiseMatematikSec() { DersSec(6, false); }
    private void LiseBiyolojiSec() { DersSec(7, false); }

    private void DersSec(int ders, bool ortaOkul)
    {
        ortaOkulMu = ortaOkul;
        seciliDers = ders;
        seciliSinif = 0;
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(true);
        if (girisBilgisi != null) girisBilgisi.SetActive(false);
    }

    public void KatSec(int sinif)
    {
        if (seciliDers == 0 || sinif < 5) return;

        if (ortaOkulMu)
        {
            if (sinif > 8) return;
            seciliSinif = sinif;
            if (seciliDers == 1) FenOrtaokulKoridorunuAc();
            return;
        }

        if (seciliDers >= 4 && sinif >= 9 && sinif <= 12)
            seciliSinif = sinif;
    }

    private void FenOrtaokulKoridorunuAc()
    {
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(false);
        if (uniteKoridoru != null) uniteKoridoru.SetActive(true);
        uniteKoridorYoneticisi?.GorselleriGuncelle();
    }

    public void UniteSec(int unite)
    {
        if (seciliDers == 0 || seciliSinif == 0) return;
        UniteKoridorYoneticisi.seciliUnite = unite;
        if (levelGecisYoneticisi != null)
            levelGecisYoneticisi.SeviyeAc(ortaOkulMu, seciliDers, seciliSinif, unite);
    }
}
