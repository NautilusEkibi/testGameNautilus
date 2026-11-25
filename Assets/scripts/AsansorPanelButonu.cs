using UnityEngine;

public class AsansorPanelButonu : MonoBehaviour
{
    public DersAkisYoneticisi dersAkisi;
    public GameObject asansorPaneli;
    public GameObject ortaokulKatButonlari;
    public GameObject liseKatButonlari;

    public void KatPaneliniAcKapat()
    {
        if (dersAkisi == null || DersSecimVerisi.SeciliDers == 0 || asansorPaneli == null)
            return;

        bool panelAc = !asansorPaneli.activeSelf;
        if (ortaokulKatButonlari != null)
            ortaokulKatButonlari.SetActive(panelAc && DersSecimVerisi.OrtaokulMu);
        if (liseKatButonlari != null)
            liseKatButonlari.SetActive(panelAc && !DersSecimVerisi.OrtaokulMu);

        asansorPaneli.SetActive(panelAc);
    }
}
