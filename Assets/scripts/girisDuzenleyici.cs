using UnityEngine;

public class girisDuzenleyici : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    
    public GameObject ortamenu;
    public GameObject lisemenu;
    public GameObject anamenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ortamenu.SetActive(false);
        lisemenu.SetActive(false);
        anamenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
