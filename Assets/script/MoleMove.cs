using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoleMove : MonoBehaviour
{
    MoleSystem system;
    private int moleX;
    private int moleZ;
    private float myTime = 0.0f;
    private bool click = true;
    private float destroyY = -1.75f;

    public void SetUp(int x, int z)
    {
        moleX = x;
        moleZ = z;

        system = GetComponentInParent<MoleSystem>();
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;


        if (transform.position.y < destroyY)
        {
            StartCoroutine(MoleReset(1f));
        }
        else
        {
            MoleMovement();
        }
    }

    private void MoleMovement()
    {
        float sin = Mathf.Sin(myTime);
        float x = moleX;
        float y = -1;
        float z = moleZ;
        this.transform.position = new Vector3(x, sin + y, z);
    }

    private IEnumerator MoleReset(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        system.moles[moleX, moleZ] = false;
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        if(click)
        {
            click = false;
            system.pointCount++;
            StartCoroutine(MoleReset(0f));
        }
    }
}

