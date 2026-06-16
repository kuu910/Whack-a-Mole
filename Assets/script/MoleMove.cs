using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoleMove : MonoBehaviour
{
    public event Action<int, int> OnHit;
    public event Action<int, int> OnVanished;

    private int moleX;
    private int moleZ;
    private float myTime = 0.0f;
    private bool click = true;
    private float destroyY = -1.75f;

    public void SetUp(int x, int z)
    {
        moleX = x;
        moleZ = z;
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;


        if (transform.position.y < destroyY)
        {
            OnVanished(moleX, moleZ);
            Destroy(gameObject);
        }
        else
        {
            MoleMovement();
        }
    }

    private void MoleMovement()
    {
        float sin = Mathf.Sin(myTime);
        float y = -1;
        this.transform.position = new Vector3(moleX, sin + y, moleZ);
    }


    private void OnMouseDown()
    {
        if(click)
        {
            click = false;
            OnHit(moleX, moleZ);
            Destroy(gameObject);
        }
    }
}

