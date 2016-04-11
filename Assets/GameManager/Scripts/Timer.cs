using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float timer = 10;
    private bool decreaseTime = true;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (decreaseTime == true)
        {
            timer -= Time.smoothDeltaTime;
        }

        if (timer <= 0)
        {
            GameManager.gameOver = true;
            timer = Time.timeScale = 0;
        }

        GetComponent<GUIText>().text = "Time: " + timer;
    }
}
