using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject deathscrn;
    public GameObject winscrn;
    public Animator deathFade;
    public Animator winFade;
    public float deathTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        deathscrn.SetActive(false);
        winscrn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        deathscrn.SetActive(true);
        StartCoroutine(PlayerLose());
    }

    public void Winner()
    {
        winscrn.SetActive(false);
        // Time.timeScale = 0;
        StartCoroutine(PlayerWin());
    }

    IEnumerator PlayerLose()
    {
        deathFade.SetTrigger("Dead");
        yield return new WaitForSeconds(deathTime);
    }

    IEnumerator PlayerWin()
    {
        winFade.SetTrigger("Live");
        yield return new WaitForSeconds(deathTime);
    }

    public void ResetGame()
    {
        deathFade.SetTrigger("Re");
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
    }
}
