using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadlevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
    }
    public void debug()
    {
        Debug.Log("FUCK");
    }
}
