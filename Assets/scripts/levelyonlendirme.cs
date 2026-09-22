using UnityEngine;
using UnityEngine.SceneManagement;

public class levelyonlendirme : MonoBehaviour
{
    public GameObject ortamenu;
    public GameObject lisemenu;
    public GameObject anamenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ortaFen()
    {
        SceneManager.LoadScene("ortaFen");
    }
    public void liseKimya()
    {
        SceneManager.LoadScene("liseKimya");
    }
    public void liseFizik()
    {
        SceneManager.LoadScene("liseFizik");
    }
    public void liseBiyoloji()
    {
        SceneManager.LoadScene("liseBiyoloji");
    }
    public void lise()
    {
        anamenu.SetActive(false);
        ortamenu.SetActive(false);
        lisemenu.SetActive(true);
    }
    public void orta()
    {
        anamenu.SetActive(false);
        lisemenu.SetActive(false);
        ortamenu.SetActive(true);
    }
    public void anagerigit()
    {
        anamenu.SetActive(true);
        lisemenu.SetActive(false);
        ortamenu.SetActive(false);
    }
}
