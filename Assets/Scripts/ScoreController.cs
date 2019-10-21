using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;
    float starttime;
    void Start()
    {
        starttime = Time.unscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        score = Time.unscaledTime - starttime;

        GetComponent<Text>().text = "Time: " + score;
    }
}
