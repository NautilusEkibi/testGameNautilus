using UnityEngine;
using UnityEngine.SceneManagement;

public class cevapKontrolEdici : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public string answer; // Saklamak istediğin string değişken

    // On End Edit bu fonksiyonu çalıştıracak
    public void SaveAnswer(string inputText)
    {
        answer = inputText;
        Debug.Log("Kaydedilen Cevap: " + answer);
        if (answer == "10")
        {
            SceneManager.LoadScene("girisMenusu");
        }
    }
}
