using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGecisYoneticisi : MonoBehaviour
{
    [Serializable]
    public class LevelRotasi
    {
        public bool ortaokulMu;
        public int ders;
        public int sinif;
        public int unite;
        public string sahneAdi;
    }

    public LevelRotasi[] levelRotalari;

    public void Unite5Sec()
    {
        SeviyeAc(
            DersAkisYoneticisi.ortaOkulMu,
            DersAkisYoneticisi.seciliDers,
            DersAkisYoneticisi.seciliSinif,
            5);
    }

    public void SeviyeAc(bool ortaokulMu, int ders, int sinif, int unite)
    {
        if (levelRotalari == null) return;

        foreach (LevelRotasi rota in levelRotalari)
        {
            if (rota != null &&
                rota.ortaokulMu == ortaokulMu &&
                rota.ders == ders &&
                rota.sinif == sinif &&
                rota.unite == unite &&
                !string.IsNullOrWhiteSpace(rota.sahneAdi))
            {
                SceneManager.LoadScene(rota.sahneAdi);
                return;
            }
        }
    }
}
