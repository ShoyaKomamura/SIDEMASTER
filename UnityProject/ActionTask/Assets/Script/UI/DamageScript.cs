using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{

    GameObject Damage;
    HPSlider script;

    Vector3 force;
    public float BackSpeed = 5000;


    // Use this for initialization
    void Start()
    {
        Damage = GameObject.Find("Fill");
        script = Damage.GetComponent<HPSlider>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Enemy"))
        {
            //force = this.gameObject.transform.right * BackSpeed;

            FindObjectOfType<HPSlider>().Damage(10f);

        }

    }
}
