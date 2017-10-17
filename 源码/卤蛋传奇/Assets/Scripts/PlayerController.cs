using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : Moving
{
    public int HP = 100;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        Move(movement);
        Attack();
        Stand();
    }

    void OnTriggerEnter(Collider collider)
    {
        //进入触发器执行的代码
        if (HP > 0)
        {
            HP--;
            Console.WriteLine(HP);
            Debug.Log("剩余血量:" + HP);
        }
        else
        {
            Debug.Log("死了!!!");

        }

    }

    void OnTriggerStay(Collider collider)
    {
        //进入触发器执行的代码
        if (HP > 0)
        {
            HP--;
            Console.WriteLine(HP);
            Debug.Log("剩余血量:" + HP);
        }
        else
        {
            Debug.Log("死了!!!");

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //进入碰撞器执行的代码
    }

}
