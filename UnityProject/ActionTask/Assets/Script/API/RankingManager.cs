using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Text
using MiniJSON;		// Json
using System;		// File
using System.IO;	// File
using System.Text;	// File
using UnityEngine.Networking;

public class RankingManager : MonoBehaviour
{
    [SerializeField] private GameObject RankingContentPrefab;
    [SerializeField] private Transform contentTransform;

    // Use this for initialization
    void Start()
    {
        GetJsonFromWww();

    }

    private void GetJsonFromWww()
    {
        // APIが設置してあるURLパス
        string sTgtURL = "http://localhost/rankproject/Ballranking/getRankings";

        StartCoroutine(GetMessages(sTgtURL, CallbackWwwSuccess, CallbackWwwFailed));
    }

    private IEnumerator GetMessages(string sTgtURL, Action<string> cbkSuccess = null, Action cbkFailed = null)
    {

        // WWWを利用してリクエストを送る
        WWW www = new WWW(sTgtURL);

        // WWWレスポンス待ち
        yield return StartCoroutine(ResponceCheckForTimeOutWWW(www, 5.0f));

        if (www.error != null)
        {
            //レスポンスエラーの場合
            Debug.LogError(www.error);
            if (null != cbkFailed)
            {
                cbkFailed();
            }
        }
        else
        if (www.isDone)
        {
            // リクエスト成功の場合
            Debug.Log(string.Format("Success:{0}", www.text));
            if (null != cbkSuccess)
            {
                cbkSuccess(www.text);
            }
        }
    }

    private IEnumerator ResponceCheckForTimeOutWWW(WWW www, float timeout)
    {
        float requestTime = Time.time;

        while (!www.isDone)
        {
            if (Time.time - requestTime < timeout)
            {
                yield return null;
            }
            else
            {
                Debug.LogWarning("TimeOut"); //タイムアウト
                break;
            }
        }
        yield return null;
    }

    private void CallbackWwwSuccess(string response)
    {

        // json データ取得が成功したのでデシリアライズして整形し画面に表示する
        List<RankingData> rankingdataList  = RankingDataModel.DesirializeFromJson(response);
        string sStrOutput = "";
        foreach (RankingData rankingData in rankingdataList)
        {
            sStrOutput += string.Format("id:{0}\n", rankingData.Id);
            sStrOutput += string.Format("name:{0}\n", rankingData.Name);
            sStrOutput += string.Format("score:{0}\n", rankingData.Score);
            sStrOutput += string.Format("time:{0}\n", rankingData.Time);

            CreateRankingContent(rankingData);
        }
        Debug.Log("sStrOutput");
        //DisplayField.text = sStrOutput;*/
    }

    private void CallbackWwwFailed()
    {

        // jsonデータ取得に失敗した
        Debug.Log("sStrOutput");
        //DisplayField.text = "Www Failed";

    }

    private void CreateRankingContent(RankingData rankingData)
    {
        GameObject content = Instantiate(RankingContentPrefab);
        content.transform.SetParent(contentTransform);

        content.GetComponent<RankingContent>().NameText.text = rankingData.Name;
        content.GetComponent<RankingContent>().ScoreText.text = rankingData.Score.ToString();
    }


}