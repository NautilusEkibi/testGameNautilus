using UnityEngine;

public class AsansorPanelButonu : MonoBehaviour
{
    public DersAkisYoneticisi dersAkisi;
    public GameObject asansorPaneli;
    public GameObject ortaokulKatButonlari;
    public GameObject liseKatButonlari;

    public void KatPaneliniAcKapat()
    {
        if (dersAkisi == null || DersAkisYoneticisi.seciliDers == 0 || asansorPaneli == null)
            return;

        bool panelAc = !asansorPaneli.activeSelf;
        if (ortaokulKatButonlari != null)
            ortaokulKatButonlari.SetActive(panelAc && DersAkisYoneticisi.ortaOkulMu);
        if (liseKatButonlari != null)
            liseKatButonlari.SetActive(panelAc && !DersAkisYoneticisi.ortaOkulMu);

        asansorPaneli.SetActive(panelAc);
    }
}
