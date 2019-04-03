using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    EnemyMove EM;

    float time = 3;

    // Use this for initialization
    void Start () {
        EM = GetComponent<EnemyMove>();
		
	}

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 1)
        {
            //位置指定
            Destroy(this.gameObject);
            time = 3;

        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);

            FindObjectOfType<EnemyMove>().E_Damage(10);

        }

        if (hit.gameObject.CompareTag("floor"))
        {
            Destroy(this.gameObject);
        }
    }
}
