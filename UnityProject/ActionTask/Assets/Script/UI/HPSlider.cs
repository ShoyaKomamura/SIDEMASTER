using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{

    public float hp = 100;
    public Image fill;
    Slider hpSlider;
    GameObject Player;
    PlayerMove script;

    [SerializeField] GameObject GameOverImage;
    [SerializeField] GameObject ReplayButton;


    [Header("Color")]
    public bool colorChange = true;
    public Color safetyColor = Color.green;
    public Color warningColor = Color.yellow;
    public Color dangerColor = Color.red;


    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        hpSlider = GetComponent<Slider>();
        script = FindObjectOfType<PlayerMove>();
        hpSlider.value = hp;
        GameOverImage.SetActive(false);
        ReplayButton.SetActive(false);
        GameOverTask();
    }


    // Update is called once per frame
    void Update()
    {
        //テスト用　2を押した時HPが減少する。
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hp -= 10f;
            hpSlider.value = hp;
        }
    }

    public void ColorChanged()
    {
        //HPが50以下ならHPバーを黄色にする
        if (hpSlider.value <= 50f && hpSlider.value > 20f)
        {
            fill.color = warningColor;
        }
        //HPが20以下ならHPバーを紫色にする
        else if (hpSlider.value <= 20f)
        {
            fill.color = dangerColor;
        }
    }

    public void Damage(float damage)
    {
        hpSlider.value = hpSlider.value - damage;
    }

    public void GameOverTask()
    {
        //HPの現在値が0以下の時、GameOverのImageをtrueにする & PlayerMoveをFalseにする。
        if (hpSlider.value <= 0f)
        {
            GameOverImage.SetActive(true);
            ReplayButton.SetActive(true);
            script.enabled = false;

        }
    }
}
