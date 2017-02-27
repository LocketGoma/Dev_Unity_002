using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Animator anim;
    public Rigidbody rbody;


    private float inputH; // 수평 입력
    private float inputV; // 수직 입력

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {        
       if (Input.GetKeyDown("1"))
       {
            //print("press 1");
            anim.Play("WAIT01", -1, 0f);
       }
       if (Input.GetKeyDown("space"))
       {
           anim.Play("JUMP00", -1, 0f);
       }
       if (Input.GetKey("w"))
       {
           anim.Play("RUN00_F", 0);
       }
       if (Input.GetKeyUp("w"))
       {
           anim.Play("REFLESH00", 0, 0f);
       }
       if (Input.GetMouseButton(0))
       {
           int n = Random.Range(0, 3);
           switch (n)
           {
               case 0: anim.Play("DAMAGED00", -1, 0f); break;
               case 1: anim.Play("DAMAGED00", -1, 0f); break;
               case 2: anim.Play("DAMAGED01", -1, 0f); break;
               default: break;
          }
       }
       // 파라미터 (움직이는 각도, 애니메이션 이용)
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        // 캐릭 '실제 이동' 부분
        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        rbody.velocity = new Vector3(moveX,0f,moveZ);
        // 실제 이동 부분 관련 끝
    }
}
