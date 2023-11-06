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

    public Collider2D shipWin;
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
        if(winscrn.activeSelf)
        {
            //
        }
        else
        {
            deathscrn.SetActive(true);
        }
        StartCoroutine(PlayerLose());
        
    }

    public void Winner()
    {
        if(deathscrn.activeSelf)
        {
           //
        }
        else
        {
            winscrn.SetActive(true);
        }
        
        shipWin.enabled = false;
        StartCoroutine(PlayerWin());
    }

    

    IEnumerator PlayerLose()
    {
        deathFade.SetTrigger("Dead");
        yield return new WaitForSeconds(deathTime);
    }

    IEnumerator PlayerWin()
    {
        deathFade.SetTrigger("Live");
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
