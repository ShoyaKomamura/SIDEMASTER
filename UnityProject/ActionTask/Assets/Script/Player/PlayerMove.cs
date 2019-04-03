using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Text ScoreText;                              //スコアのテキスト
    public GameObject GoalImage;                        //ゴール時のImage（画像）
    public GameObject ResultButton;                     //リザルトに遷移するボタン
    public static int score ;                           //スコアの数値（Ranking Sceneで使用するため static ）


    private CharacterController contoroller;            //スクリプト<Character contoroller>を指す
    private PlayerMove PM;                              //スクリプト<PlayerMove>を指す
    private Vector3 moveDirection;                      //ベクトルxyzの三つを取得し、名称を指す

    // Use this for initialization
    void Start()
    {
        PM = GetComponent<PlayerMove>();                    //PMにPlayerMoveのスクリプトを取得
        contoroller = GetComponent<CharacterController>();　//contorollerにCharacterContorollerを取得
        score = 0;
        SetScoreText();
        GoalImage.SetActive(false);                         //開始時にゴール時のImageを非表示にする。
        ResultButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        moveDirection.x = 0;

        //右矢印のキーを押した時、ｘのベクトルに正の10が追加される
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x = 10;
        }

        //左矢印のキーを押した時、ｘのベクトルに負の10が追加される
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x = -10;
        }

        //地面についているか否かの判定
        if (contoroller.isGrounded)
        {
            //
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection.y = 11;
            }
        }
        //重力処理
        moveDirection.y -= 20 * Time.deltaTime;

        contoroller.Move(moveDirection * Time.deltaTime);
    }

    void SetScoreText()
    {
        ScoreText.text = "Score:" + score.ToString();

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //衝突したオブジェクトのタグが"Goal"の場合
        if (hit.gameObject.CompareTag("Goal"))
        {
            //GoolTextをtrueにする
            GoalImage.SetActive(true);
            ResultButton.SetActive(true);
            PM.enabled = false;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //衝突したオブジェクトのタグが"Score"だった場合
        if (other.gameObject.CompareTag("Score"))
        {
            //ヒットしたアイテムを消滅させる。
            Destroy(other.gameObject);
            //ヒットしたときにスコアを加算する。
            score = score + 10;
            SetScoreText();
        } else if (other.gameObject.CompareTag("HighScore")) {
            Destroy(other.gameObject);
            score = score + 100;
            SetScoreText();
        }
    }

    public static int getscore()
    {
        return score;
    }
}
