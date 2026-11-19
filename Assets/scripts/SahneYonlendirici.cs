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

    public void UniteyiAc(bool ortaokulMu, int ders, int sinif, int unite)
    {
        if (ders == 0 || sinif == 0 || unite < 1 || unite > 7)
        {
            Debug.LogWarning($"Geçersiz yönlendirme: ders {ders}, sınıf {sinif}, ünite {unite}.", this);
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
