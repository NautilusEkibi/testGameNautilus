using UnityEngine;

public class AnaMenuDonusButonu : MonoBehaviour
{
    public GameObject anaMenuArkaPlani;
    public GameObject asansor;
    public GameObject uniteKoridoru;
    public GameObject asansorPaneli;
    public GameObject katPaneli;
    public GameObject girisBilgisi;

    public void AnaMenuyeDon()
    {
        if (asansorPaneli != null) asansorPaneli.SetActive(false);
        if (katPaneli != null) katPaneli.SetActive(false);
        if (asansor != null) asansor.SetActive(false);
        if (uniteKoridoru != null) uniteKoridoru.SetActive(false);
        if (anaMenuArkaPlani != null) anaMenuArkaPlani.SetActive(true);
        if (girisBilgisi != null) girisBilgisi.SetActive(true);

        DersAkisYoneticisi.seciliDers = 0;
        DersAkisYoneticisi.seciliSinif = 0;
        DersAkisYoneticisi.ortaOkulMu = true;
    }
}
