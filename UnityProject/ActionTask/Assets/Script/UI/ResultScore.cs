using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{

    public Text ResultScoreText;

    int resultscore = PlayerMove.getscore();


    public void Start()
    {
        ResultText();
    }

    public void Update()
    {

    }

    void ResultText()
    {
        ResultScoreText.text = "あなたのスコアは" + resultscore.ToString()　+ "です";

    }
}