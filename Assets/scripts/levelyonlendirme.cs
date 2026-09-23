using UnityEngine;
using UnityEngine.SceneManagement;

public class levelyonlendirme : MonoBehaviour
{
    public GameObject ortamenu;
    public GameObject lisemenu;
    public GameObject anamenu;
    public GameObject odalarorta;
    public GameObject lisebiyo;
    public GameObject lisekimya;
    public GameObject lisefizik;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lisemenu.SetActive(false);
        ortamenu.SetActive(false);
        odalarorta.SetActive(false);
        lisebiyo.SetActive(false);
        lisekimya.SetActive(false);
        lisefizik.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ortaFen()
    {
        lisemenu.SetActive(false);
        ortamenu.SetActive(false);
        odalarorta.SetActive(true);
        lisebiyo.SetActive(false);
        lisekimya.SetActive(false);
        lisefizik.SetActive(false);
    }
    public void ortaFenlevel1()
    {
        SceneManager.LoadScene("orta_1");
    }
    public void ortaFenlevel2()
    {
        SceneManager.LoadScene("orta_2");
    }
    public void ortaFenlevel3()
    {
        SceneManager.LoadScene("orta_3");
    }
    public void ortaFenlevel4()
    {
        SceneManager.LoadScene("orta_4");
    }
    public void ortaFenlevel5()
    {
        SceneManager.LoadScene("orta_5");
    }



    public void liseKimya()
    {
        lisemenu.SetActive(false);
        ortamenu.SetActive(false);
        odalarorta.SetActive(false);
        lisebiyo.SetActive(false);
        lisekimya.SetActive(true);
        lisefizik.SetActive(false);
    }
    public void lisekimyalevel1()
    {
        SceneManager.LoadScene("liseKimya_1");
    }
    public void lisekimyalevel2()
    {
        SceneManager.LoadScene("liseKimya_2");
    }
    public void lisekimyalevel3(){SceneManager.LoadScene("liseKimya_3");}
    public void lisekimyalevel4(){SceneManager.LoadScene("liseKimya_4");}
    public void lisekimyalevel5(){SceneManager.LoadScene("liseKimya_5");}





    public void liseFizik()
    {
        lisemenu.SetActive(false);
        ortamenu.SetActive(false);
        odalarorta.SetActive(false);
        lisebiyo.SetActive(false);
        lisekimya.SetActive(false);
        lisefizik.SetActive(true);
    }
    public void lisefiziklevel1() { SceneManager.LoadScene("liseFizik_1"); }
    public void lisefiziklevel2() { SceneManager.LoadScene("liseFizik_2"); }
    public void lisefiziklevel3() { SceneManager.LoadScene("liseFizik_3"); }
    public void lisefiziklevel4() { SceneManager.LoadScene("liseFizik_4"); }
    public void lisefiziklevel5() { SceneManager.LoadScene("liseFizik_5"); }





    public void liseBiyoloji()
    {
        lisemenu.SetActive(false);
        ortamenu.SetActive(false);
        odalarorta.SetActive(false);
        lisebiyo.SetActive(true);
        lisekimya.SetActive(false);
        lisefizik.SetActive(false);
    }
    public void lisebiyolojiklevel1() { SceneManager.LoadScene("liseBiyoloji_1"); }
    public void lisebiyolojiklevel2() { SceneManager.LoadScene("liseBiyoloji_2"); }
    public void lisebiyolojiklevel3() { SceneManager.LoadScene("liseBiyoloji_3"); }
    public void lisebiyolojiklevel4() { SceneManager.LoadScene("liseBiyoloji_4"); }
    public void lisebiyolojiklevel5() { SceneManager.LoadScene("liseBiyoloji_5"); }




    public void lise()
    {
        anamenu.SetActive(false);
        ortamenu.SetActive(false);
        lisemenu.SetActive(true);
        odalarorta.SetActive(false);
        lisebiyo.SetActive(false);
        lisekimya.SetActive(false);
        lisefizik.SetActive(false);
    }
    public void orta()
    {
        anamenu.SetActive(false);
        lisemenu.SetActive(false);
        ortamenu.SetActive(true);
        odalarorta.SetActive(false);
        lisebiyo.SetActive(false);
        lisekimya.SetActive(false);
        lisefizik.SetActive(false);
    }
    public void anagerigit()
    {
        anamenu.SetActive(true);
        lisemenu.SetActive(false);
        ortamenu.SetActive(false);
        odalarorta.SetActive(false);
        lisebiyo.SetActive(false);
        lisekimya.SetActive(false);
        lisefizik.SetActive(false);
    }
}
