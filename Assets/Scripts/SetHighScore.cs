using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class SetHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;
    bool setscore = true;
    void Start()
    {
        if (SaveGame.Exists("score"))
        {
            score = SaveGame.Load<float>("score", 0f);
        }
        else
        {
            score = 0f;
        }
        GetComponent<Text>().text = "High Score Time(Seconds): " + score;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (setscore)
        {
            GetComponent<Text>().text = "High Score Time(Seconds): " + score;
        }
        */
    }

    private void OnApplicationQuit()
    {
        SaveGame.Save<float>("score", score);
    }
}
