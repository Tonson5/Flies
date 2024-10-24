using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    

    public string[] levels;
    public int currentLevel;
    public string nextLevel;
    public string lose;
    public GameObject player;
    void Start()
    {
        
        Object.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        nextLevel = levels[currentLevel + 1];
        
    }
    public void IncreaseLevel()
    {
        SceneManager.LoadScene(nextLevel);
        currentLevel += 1;
    }
    public void Lose()
    {
        SceneManager.LoadScene(lose);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levels[currentLevel]);
    }
}
