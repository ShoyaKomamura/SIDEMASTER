using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    // bullet prefab
    public GameObject bullet;

    public Text BulletText;
    int Bullets = 30;

    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public float speed = 500;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // z キーが押された時
        if ( Bullets >= 0 ) {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force;

                force = this.gameObject.transform.right * speed;

                // Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // 弾丸の位置を調整
                bullets.transform.position = muzzle.position;

                SetBulletext();
                Bullets -= 1;
            }

        }

    }

    void SetBulletext()
    {
        BulletText.text = "" + Bullets.ToString();

    }
}
