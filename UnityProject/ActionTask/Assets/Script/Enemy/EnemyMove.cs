using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    private CharacterController e_contoroller;
    private Vector3 e_Direction;
    private float time = 3;

    public int E_Hp = 30;
    int ValueHP;

    // Use this for initialization
    void Start () {
        e_contoroller = GetComponent<CharacterController>();
        ValueHP = E_Hp;
    }
	
	// Update is called once per frame
	void Update () {
        //地面についているか否かの判定
        if (e_contoroller.isGrounded)
        {
        }

        if (ValueHP == 0)
        {
            Destroy(this.gameObject);
        }

        //e_Direction.x += 20;

        //重力処理
        e_Direction.y -= 20 * Time.deltaTime;

        e_contoroller.Move(e_Direction * Time.deltaTime);

    }

    public void E_Damage(int B_Attack)
    {
        ValueHP = ValueHP - B_Attack;
    }
}
