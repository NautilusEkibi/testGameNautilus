using System;
using TMPro;
using UnityEngine;

[Serializable]
public sealed class UniteSahneBolumu
{
    public int uniteNo;
    public GameObject unitePaneli;
    public GameObject[] altKonuPanelleri;
}

public sealed class AltKonuSahneYoneticisi : MonoBehaviour
{
    [SerializeField] private int ders;
    [SerializeField] private int sinif;
    [SerializeField] private TMP_Text sahneBasligi;
    [SerializeField] private TMP_Text durumMesaji;
    [SerializeField] private UniteSahneBolumu[] uniteBolumleri;
    [SerializeField] private Sprite pressureTopicImage;

    private void Start()
    {
        SeciliAltKonuyuGoster();
    }

    public void SeciliAltKonuyuGoster()
    {
        if (uniteBolumleri == null)
        {
            if (durumMesaji != null)
            {
                durumMesaji.text = "Bu sahnenin ünite içerikleri bağlı değil.";
                durumMesaji.gameObject.SetActive(true);
            }
            return;
        }

        foreach (UniteSahneBolumu bolum in uniteBolumleri)
        {
            if (bolum == null) continue;
            if (bolum.unitePaneli != null) bolum.unitePaneli.SetActive(false);
            if (bolum.altKonuPanelleri == null) continue;
            foreach (GameObject altKonuPaneli in bolum.altKonuPanelleri)
                if (altKonuPaneli != null) altKonuPaneli.SetActive(false);
            BasliklariGizle(bolum.unitePaneli, "Unite Başlığı");
            foreach (GameObject altKonuPaneli in bolum.altKonuPanelleri)
                BasliklariGizle(altKonuPaneli, "Alt Konu Başlığı");
        }

        bool secimGecerli = DersSecimVerisi.SeciliDers == ders &&
                            DersSecimVerisi.SeciliSinif == sinif &&
                            DersSecimVerisi.SeciliUnite > 0 &&
                            DersSecimVerisi.SeciliAltKonu > 0;

        if (sahneBasligi != null)
            sahneBasligi.text = string.Empty;

        if (!secimGecerli)
        {
            if (durumMesaji != null)
            {
                durumMesaji.text = "Önce ana ekrandan bir alt konu seç.";
                durumMesaji.gameObject.SetActive(true);
            }
            return;
        }

        UniteSahneBolumu seciliBolum = Array.Find(uniteBolumleri, bolum =>
            bolum != null && bolum.uniteNo == DersSecimVerisi.SeciliUnite);
        int altKonuIndex = DersSecimVerisi.SeciliAltKonu - 1;

        if (ders == DersSecimVerisi.Fen && sinif == 8 &&
            DersSecimVerisi.SeciliUnite == 2 && altKonuIndex == 2)
            BasincKonusuEkle(seciliBolum);

        if (seciliBolum == null || seciliBolum.altKonuPanelleri == null ||
            altKonuIndex < 0 || altKonuIndex >= seciliBolum.altKonuPanelleri.Length)
        {
            if (durumMesaji != null)
            {
                durumMesaji.text = "Seçilen alt konu bu sahnede tanımlı değil.";
                durumMesaji.gameObject.SetActive(true);
            }
            return;
        }

        if (seciliBolum.unitePaneli != null)
            seciliBolum.unitePaneli.SetActive(true);
        if (seciliBolum.altKonuPanelleri[altKonuIndex] != null)
        {
            seciliBolum.altKonuPanelleri[altKonuIndex].SetActive(true);
            string[] konuBasliklari = DersIcerikKatalogu.AltKonuBasliklari(
                ders, sinif, DersSecimVerisi.SeciliUnite);
            if (sahneBasligi != null && altKonuIndex < konuBasliklari.Length)
                sahneBasligi.text = konuBasliklari[altKonuIndex];
        }
        if (durumMesaji != null)
            durumMesaji.gameObject.SetActive(false);
    }

    private void BasincKonusuEkle(UniteSahneBolumu bolum)
    {
        if (bolum == null || bolum.altKonuPanelleri == null || bolum.altKonuPanelleri.Length == 0)
            return;

        if (bolum.altKonuPanelleri.Length > 2) return;

        GameObject panel = Instantiate(
            bolum.altKonuPanelleri[bolum.altKonuPanelleri.Length - 1],
            bolum.altKonuPanelleri[bolum.altKonuPanelleri.Length - 1].transform.parent,
            false);
        panel.name = "Alt Konu 03 - Basınç";
        panel.SetActive(false);

        GorselliSoruEtkilesimi soruGorseli = panel.GetComponentInChildren<GorselliSoruEtkilesimi>(true);
        if (soruGorseli != null && pressureTopicImage != null)
            soruGorseli.SetRoomImage(pressureTopicImage);

        GameObject[] paneller = new GameObject[bolum.altKonuPanelleri.Length + 1];
        Array.Copy(bolum.altKonuPanelleri, paneller, bolum.altKonuPanelleri.Length);
        paneller[paneller.Length - 1] = panel;
        bolum.altKonuPanelleri = paneller;
    }

    private static void BasliklariGizle(GameObject panel, string nesneAdi)
    {
        if (panel == null) return;
        foreach (TMP_Text metin in panel.GetComponentsInChildren<TMP_Text>(true))
            if (metin.gameObject.name == nesneAdi)
                metin.gameObject.SetActive(false);
    }

    public int Ders => ders;
    public int Sinif => sinif;
}
