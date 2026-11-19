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

    public static int seciliUnite = 0;

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
        GorselGoster(sinif5Kapilari, 1, 5);
        GorselGoster(sinif6Kapilari, 1, 6);
        GorselGoster(sinif7Kapilari, 1, 7);
        GorselGoster(sinif8Kapilari, 1, 8);
        GorselGoster(matematik5Gorselleri, 2, 5);
        GorselGoster(matematik6Gorselleri, 2, 6);
        GorselGoster(matematik7Gorselleri, 2, 7);
        GorselGoster(matematik8Gorselleri, 2, 8);
        GorselGoster(turkce5Gorselleri, 3, 5);
        GorselGoster(turkce6Gorselleri, 3, 6);
        GorselGoster(turkce7Gorselleri, 3, 7);
        GorselGoster(turkce8Gorselleri, 3, 8);
    }

    private static void GorselGoster(GameObject gorseller, int ders, int sinif)
    {
        if (gorseller == null) return;

        bool secili = DersAkisYoneticisi.ortaOkulMu &&
                      DersAkisYoneticisi.seciliDers == ders &&
                      DersAkisYoneticisi.seciliSinif == sinif;
        gorseller.SetActive(secili);
    }
}
