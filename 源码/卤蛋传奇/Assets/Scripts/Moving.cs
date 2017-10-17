using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public bool IsMove;
    protected UnityArmatureComponent armature;
    public float speed;
    public bool StopMove = false;

    protected virtual void Start()
    {
        armature = GetComponent<UnityArmatureComponent>();
        armature.animation.Play("站立");
        IsMove = false;

    }

    // 站立
    protected void Stand()
    {
        if (!IsOnMoving() && armature.animation.isCompleted)
        {
            armature.animation.Play("站立");
        }
    }

    // 移动
    protected void Move(Vector3 movement)
    {
        if (IsMove == false && IsOnMove())
        {
            armature.animation.Play("移动", 1);
            IsMove = true;
        }
        else if (IsMove && IsOnMoving())
        {
            if (armature.animation.isCompleted)
                armature.animation.Play("移动", 1);
        }
        else if (IsOnStop())
        {
            IsMove = false;
        }

        var reg = GetComponent<Rigidbody>();
        reg.velocity = movement * speed;
    }

    // 自动移动 对应ai
    protected void AutoMove(Vector3 movement)
    {

        if (StopMove)
        {
            IsMove = false;
        }
        else if (IsMove == false)
        {
            armature.animation.Play("移动", 1);
            IsMove = true;
        }
        else if (IsMove)
        {
            if (armature.animation.isCompleted)
                armature.animation.Play("移动", 1);
        }


        var reg = GetComponent<Rigidbody>();
        reg.velocity = movement * speed;
    }

    /// <summary>
    /// 自动攻击
    /// </summary>
    protected void AutoAttack()
    {
        if (IsMove == false)
        {
            if (!(armature.animation.lastAnimationName == "攻击" && armature.animation.isPlaying))
            {
                armature.animation.Play("攻击", 1);
                Invoke("Stand", armature.animation.lastAnimationState._duration);
            }
        }
    }

    // 判断是否开始移动
    protected bool IsOnMove()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            return true;
        else
            return false;
    }

    // 判断是否移动中
    protected bool IsOnMoving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
            return true;
        else
            return false;
    }

    // 判断是否停止
    protected bool IsOnStop()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
            return true;
        else return false;
    }

    /// <summary>
    /// 攻击
    /// </summary>
    protected void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J) && !IsMove)
        {
            if (!(armature.animation.lastAnimationName == "攻击" && armature.animation.isPlaying))
            {
                armature.animation.Play("攻击", 1);
                Invoke("Stand", armature.animation.lastAnimationState._duration);
            }
        }
    }
}
