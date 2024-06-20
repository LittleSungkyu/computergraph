using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    Main scoreManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        scoreManager = FindAnyObjectByType<Main>();

        // scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        string myTag = this.gameObject.tag;

        if (collision.gameObject.tag == "GreenBoard")
        {
            //get my tag


            if (myTag == "GreenBall")
            {

                scoreManager.AddScore(1);

            }
            else if (myTag == "BlueBall")
            {

                scoreManager.AddScore(-1);
            }

            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "BlueBoard")
        {
            if (myTag == "GreenBall")
            {
                scoreManager.AddScore(-1);
            }
            else if (myTag == "BlueBall")
            {
                scoreManager.AddScore(1);
            }


            Destroy(this.gameObject);
        }



        // scoreManager.RemoveSphere(this.gameObject);
    }



}
