using UnityEngine;

public class acKapa : MonoBehaviour
{
    public bool acik = false;
    public GameObject panel; // Paneli temsil eden GameObject referansı
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        acik= false;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void acılma()
    {
        if(acik == false)
        {
            panel.SetActive(true); // Paneli aç
            acik = true;
        }
        else
        {
            panel.SetActive(false); // Paneli kapat
            acik = false;
        }
    }
}
