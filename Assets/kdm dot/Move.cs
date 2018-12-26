using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    private bool isUButtonDown = false;
    private bool isDButtonDown = false;
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;


    float delta = 0;
    bool isMove = false;
    Vector3 nowPos = Vector3.zero;
    Vector3 targetPos = Vector3.zero;

    public GameObject Block;
    public GameObject Player;

    Animator animator;

    LayerMask mask = 1 << 8;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //RaycastHit2D result = Physics2D.Linecast (nowPos, targetPos);

        //ヒットしたオブジェクトを出力
        //Debug.Log (result.collider);

        // 右のキーを押した時に１になる、左は−１
        int horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        // 上のキーを押した時に１になる、下は−１
        int vertical = (int)(Input.GetAxisRaw("Vertical"));

        // 動いていない時
        if (!isMove)
        {

            // 右
            if (horizontal == 1 || this.isRButtonDown)
            {
                nowPos = this.transform.position;
                targetPos = this.transform.position + Vector3.right;

                RaycastHit2D result = Physics2D.Linecast(transform.position, targetPos, mask);

                if (result.transform == null)
                {
                    animator.SetInteger("dire", 2);
                    isMove = true;
                }
            }
            // 左
            else if (horizontal == -1 || this.isLButtonDown)
            {
                nowPos = this.transform.position;
                targetPos = this.transform.position - Vector3.right;

                RaycastHit2D result = Physics2D.Linecast(transform.position, targetPos, mask);

                if (result.transform == null)
                {
                    animator.SetInteger("dire", 1);
                    isMove = true;
                }
            }
            // 上
            else if (vertical == 1 || this.isUButtonDown)
            {
                nowPos = this.transform.position;
                targetPos = this.transform.position + Vector3.up;

                RaycastHit2D result = Physics2D.Linecast(transform.position, targetPos, mask);

                if (result.transform == null)
                {
                    animator.SetInteger("dire", 3);
                    isMove = true;
                }
            }
            // 下
            else if (vertical == -1 || this.isDButtonDown)
            {
                nowPos = this.transform.position;
                targetPos = this.transform.position - Vector3.up;

                RaycastHit2D result = Physics2D.Linecast(transform.position, targetPos, mask);

                if (result.transform == null)
                {
                    animator.SetInteger("dire", 0);
                    isMove = true;
                }
            }
        }
        else
        {
            delta += Time.deltaTime * 6;

            this.transform.position = Vector3.Lerp(nowPos, targetPos, delta);

            if (delta >= 1.0f)
            {
                isMove = false;
                delta = 0;
            }
        }
    }
    public void GetMyUpButtonDown()
    {
        this.isUButtonDown = true;
    }
    public void GetMyUpButtonUp()
    {
        this.isUButtonDown = false;
    }
    public void GetMyDownButtonDown()
    {
        this.isDButtonDown = true;
    }
    public void GetMyDownButtonUp()
    {
        this.isDButtonDown = false;
    }

    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }




}