using UnityEngine;

public class UniteKoridorYoneticisi : MonoBehaviour
{
    public GameObject sinif6Kapilari;
    public GameObject sinif7Kapilari;
    public GameObject sinif8Kapilari;
    public GameObject sinif5Kapilari;

    public static int seciliUnite = 0;

    private void OnEnable()
    {
        GorselleriGuncelle();
    }

    public void GorselleriGuncelle()
    {
        if (!DersAkisYoneticisi.ortaOkulMu || DersAkisYoneticisi.seciliDers != 1)
        {
            TumSinifGorselleriniKapat();
            return;
        }

        TumSinifGorselleriniKapat();
        if (DersAkisYoneticisi.seciliSinif == 5 && sinif5Kapilari != null) sinif5Kapilari.SetActive(true);
        if (DersAkisYoneticisi.seciliSinif == 6 && sinif6Kapilari != null) sinif6Kapilari.SetActive(true);
        if (DersAkisYoneticisi.seciliSinif == 7 && sinif7Kapilari != null) sinif7Kapilari.SetActive(true);
        if (DersAkisYoneticisi.seciliSinif == 8 && sinif8Kapilari != null) sinif8Kapilari.SetActive(true);
    }

    private void TumSinifGorselleriniKapat()
    {
        if (sinif5Kapilari != null) sinif5Kapilari.SetActive(false);
        if (sinif6Kapilari != null) sinif6Kapilari.SetActive(false);
        if (sinif7Kapilari != null) sinif7Kapilari.SetActive(false);
        if (sinif8Kapilari != null) sinif8Kapilari.SetActive(false);
    }
}
