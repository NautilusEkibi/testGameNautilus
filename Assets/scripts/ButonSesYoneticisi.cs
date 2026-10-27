using UnityEngine;
using UnityEngine.UI;

public class ButonSesYoneticisi : MonoBehaviour
{
    public AudioSource sesKaynagi;
    public AudioClip popSesi;
    public Button[] butonlar;

    private void Start()
    {
        if (butonlar == null) return;
        foreach (Button buton in butonlar)
        {
            if (buton == null) continue;
            if (buton.targetGraphic != null)
            {
                buton.targetGraphic.enabled = true;
                buton.targetGraphic.raycastTarget = true;
            }
            buton.interactable = true;
            buton.onClick.AddListener(PopSesiCal);
        }
    }

    private void PopSesiCal()
    {
        if (sesKaynagi != null && popSesi != null)
            sesKaynagi.PlayOneShot(popSesi);
    }
}
