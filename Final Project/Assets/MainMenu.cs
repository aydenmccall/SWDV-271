using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isLoading = false;
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //StartCoroutine(Countdown(3));
    }

    private void Update()
    {

        if (Input.anyKeyDown && !isLoading)
        {
            isLoading = true;
            LoadLevel();
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        //gameObject.SetActive(false);
        LoadLevel();
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
