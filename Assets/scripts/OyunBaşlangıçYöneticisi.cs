using UnityEngine;

public class OyunBaşlangıçYöneticisi : MonoBehaviour
{
    public GameObject oyunBasiArkaPlan;
    public GameObject asansor;
    public GameObject uniteKoridoru;

    private void Start()
    {
        if (oyunBasiArkaPlan != null)
            oyunBasiArkaPlan.SetActive(true);

        if (asansor != null)
            asansor.SetActive(false);

        if (uniteKoridoru != null)
            uniteKoridoru.SetActive(false);
    }
}
