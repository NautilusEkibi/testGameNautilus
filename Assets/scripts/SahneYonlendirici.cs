using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYonlendirici : MonoBehaviour
{
    [Serializable]
    public class SahneRotasi
    {
        public bool ortaokulMu;
        public int ders;
        public int sinif;
        public string sahneAdi;
    }

    public SahneRotasi[] sahneRotalari;

    public void AltKonuyuAc(bool ortaokulMu, int ders, int sinif, int unite, int altKonu)
    {
        string[] altKonuBasliklari = DersIcerikKatalogu.AltKonuBasliklari(ders, sinif, unite);
        if (ders == 0 || sinif == 0 || unite < 1 || unite > 7 ||
            altKonu < 1 || altKonu > altKonuBasliklari.Length ||
            DersSecimVerisi.OrtaokulMu != ortaokulMu ||
            DersSecimVerisi.SeciliDers != ders ||
            DersSecimVerisi.SeciliSinif != sinif ||
            DersSecimVerisi.SeciliUnite != unite ||
            DersSecimVerisi.SeciliAltKonu != altKonu)
        {
            Debug.LogWarning($"Geçersiz alt konu yönlendirmesi: ders {ders}, sınıf {sinif}, ünite {unite}, alt konu {altKonu}.", this);
            return;
        }

        string sahneAdi = SahneAdiBul(ortaokulMu, ders, sinif);
        if (string.IsNullOrWhiteSpace(sahneAdi))
        {
            Debug.LogWarning($"Sahne rotası bulunamadı: {(ortaokulMu ? "Ortaokul" : "Lise")}, ders {ders}, sınıf {sinif}.", this);
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(sahneAdi))
        {
            Debug.LogError($"'{sahneAdi}' sahnesi Build Settings listesinde yok veya bulunamadı.", this);
            return;
        }

        SceneManager.LoadScene(sahneAdi);
    }

    public string SahneAdiBul(bool ortaokulMu, int ders, int sinif)
    {
        if (sahneRotalari == null) return null;

        foreach (SahneRotasi rota in sahneRotalari)
        {
            if (rota != null &&
                rota.ortaokulMu == ortaokulMu &&
                rota.ders == ders &&
                rota.sinif == sinif &&
                !string.IsNullOrWhiteSpace(rota.sahneAdi))
            {
                return rota.sahneAdi;
            }
        }

        return null;
    }
}
