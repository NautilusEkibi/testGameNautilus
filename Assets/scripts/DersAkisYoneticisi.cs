using UnityEngine;
using UnityEngine.UI;

public class DersAkisYoneticisi : MonoBehaviour
{
    public GameObject asansor;
    public GameObject fenBilgisi;
    public GameObject matematikBilgisi;
    public GameObject turkceBilgisi;
    public GameObject girisBilgisi;
    public GameObject asansorPaneli;
    public GameObject katPaneli;
    public GameObject uniteKoridoru;
    public UniteKoridorYoneticisi uniteKoridorYoneticisi;
    public SahneYonlendirici sahneYonlendirici;

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

    private void Start()
    {
        DersSecimVerisi.AnaMenuyeDon();
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(false);
        if (uniteKoridoru != null) uniteKoridoru.SetActive(false);
        DersBilgisiniGoster(0);

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
            if (uniteButonlari[i] != null)
                uniteButonlari[i].interactable = false;
        }
    }

    private void Bagla(Button buton, UnityEngine.Events.UnityAction islem)
    {
        if (buton != null) buton.onClick.AddListener(islem);
    }

    public void FenSec()
    {
        DersSec(DersSecimVerisi.Fen, true);
    }

    private void OrtaokulMatematikSec() { DersSec(DersSecimVerisi.Matematik, true); }
    private void OrtaokulTurkceSec() { DersSec(DersSecimVerisi.Turkce, true); }
    private void LiseFizikSec() { DersSec(DersSecimVerisi.LiseFizik, false); }
    private void LiseKimyaSec() { DersSec(DersSecimVerisi.LiseKimya, false); }
    private void LiseMatematikSec() { DersSec(DersSecimVerisi.LiseMatematik, false); }
    private void LiseBiyolojiSec() { DersSec(DersSecimVerisi.LiseBiyoloji, false); }

    private void DersSec(int ders, bool ortaOkul)
    {
        DersSecimVerisi.DersiSec(ders, ortaOkul);
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(true);
        DersBilgisiniGoster(DersSecimVerisi.SeciliDers);
        if (girisBilgisi != null) girisBilgisi.SetActive(false);
    }

    private void DersBilgisiniGoster(int ders)
    {
        if (fenBilgisi != null) fenBilgisi.SetActive(ders == 1);
        if (matematikBilgisi != null) matematikBilgisi.SetActive(ders == 2);
        if (turkceBilgisi != null) turkceBilgisi.SetActive(ders == 3);
    }

    public void KatSec(int sinif)
    {
        if (DersSecimVerisi.SeciliDers == 0 || sinif < 5) return;

        if (DersSecimVerisi.OrtaokulMu)
        {
            if (sinif > 8) return;
            if (!DersSecimVerisi.SinifiSec(sinif)) return;
            OrtaokulKoridorunuAc();
            return;
        }

        if (DersSecimVerisi.SeciliDers >= DersSecimVerisi.LiseFizik &&
            sinif >= 9 && sinif <= 12)
            DersSecimVerisi.SinifiSec(sinif);
    }

    private void OrtaokulKoridorunuAc()
    {
        DersBilgisiniGoster(0);
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(false);
        if (uniteKoridoru != null) uniteKoridoru.SetActive(true);
        uniteKoridorYoneticisi?.GorselleriGuncelle();
        KapilarinEtkilesiminiGuncelle();
    }

    public void UniteSec(int kapiNo)
    {
        if (DersSecimVerisi.SeciliDers == 0 || DersSecimVerisi.SeciliSinif == 0) return;

        if (!DersSecimVerisi.AltKonuEkraniAcik)
        {
            if (!DersSecimVerisi.UniteyiSec(kapiNo)) return;
            uniteKoridorYoneticisi?.GorselleriGuncelle();
            KapilarinEtkilesiminiGuncelle();
            return;
        }

        if (!DersSecimVerisi.AltKonuyuSec(kapiNo)) return;
        if (sahneYonlendirici != null)
            sahneYonlendirici.AltKonuyuAc(
                DersSecimVerisi.OrtaokulMu,
                DersSecimVerisi.SeciliDers,
                DersSecimVerisi.SeciliSinif,
                DersSecimVerisi.SeciliUnite,
                DersSecimVerisi.SeciliAltKonu);
    }

    private void KapilarinEtkilesiminiGuncelle()
    {
        int aktifKapiAdedi = DersSecimVerisi.AltKonuEkraniAcik
            ? DersIcerikKatalogu.AltKonuSayisi(
                DersSecimVerisi.SeciliDers,
                DersSecimVerisi.SeciliSinif,
                DersSecimVerisi.SeciliUnite)
            : DersIcerikKatalogu.UniteSayisi(
                DersSecimVerisi.SeciliDers,
                DersSecimVerisi.SeciliSinif);

        for (int i = 0; uniteButonlari != null && i < uniteButonlari.Length; i++)
            if (uniteButonlari[i] != null)
                uniteButonlari[i].interactable = i < aktifKapiAdedi;
    }

    public void AnaMenuyeDon()
    {
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(false);
        if (uniteKoridoru != null) uniteKoridoru.SetActive(false);
        if (girisBilgisi != null) girisBilgisi.SetActive(true);

        DersSecimVerisi.AnaMenuyeDon();
        DersBilgisiniGoster(0);
        uniteKoridorYoneticisi?.GorselleriGuncelle();
    }
}
