using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathscrn;
    public Animator deathFade;
    public float deathTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        deathscrn.SetActive(false);
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

    IEnumerator PlayerLose()
    {
        deathFade.SetTrigger("Dead");
        yield return new WaitForSeconds(deathTime);
    }

    private void ResetGame()
    {

    }

    private void MainMenu()
    {

    }
}
