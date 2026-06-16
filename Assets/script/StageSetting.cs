using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetting : MonoBehaviour
{
    [SerializeField] private GameObject stagePrefab;
    [SerializeField] private GameObject mineCamera;

    private float x = 0;
    private float y = 0;
    private float z = 0;

    private float cameraX = 0;
    private float cameraY = 0;
    private float cameraZ = 0;
    // Start is called before the first frame update

    public void StageSet(int moleXCount,int moleZCount)
    {
        for (int i = 0; i < moleXCount; i++)
        {
            for (int j = 0; j < moleZCount; j++)
            {
                this.transform.position = new Vector3(x, y, z);
                Instantiate(stagePrefab, transform.position, transform.rotation);

                z += 1f;
            }
            x += 1f;
            cameraX += 1f;
            cameraY += 1f;
            cameraZ += 1f;
            z = 0;
        }

        mineCamera.transform.position = new Vector3((cameraX-1)/2,cameraY,(cameraZ-1)/2);
    }
}

