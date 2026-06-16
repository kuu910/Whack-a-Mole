using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoleSystem : MonoBehaviour
{
    [SerializeField] private MoleMove molePrefab;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private StageSetting stageScript;
    public int pointCount = 0;
    private float moleTime = 1.0f;
    private int moleCount = 0; 
    private int maxMoleCount = 30;
    
    //É}ÉXÇÃçLÇ≥
    public int siz = 3;
    public bool[,] moles;
    // Start is called before the first frame update
    void Start()
    {
        moles = new bool[siz, siz];

        for (int i = 0; i < moles.GetLength(0);i++)
        {
            for(int j = 0; j < moles.GetLength(1); j++)
            {
                moles[i,j] = false;
            }
        }

        stageScript.StageSet(this);
    }

    private void Update()
    {
        if (moleCount < maxMoleCount)
        {
            if (moleTime <= 0.0f)
            {
                MoleSpawn();

                moleTime = 1.0f;
            }
            else
            {
                moleTime -= Time.deltaTime;
            }
        }

        pointText.text = maxMoleCount + "/" + pointCount.ToString();
    }

    private void MoleSpawn()
    {
        moleCount++;
        int x;
        int z;

        do
        {
            x = Random.Range(0, siz);
            z = Random.Range(0, siz);

        } while (moles[x, z]);

        moles[x, z] = true;

        MoleMove newMole = Instantiate(molePrefab, transform);
        newMole.SetUp(x, z);

        newMole.OnHit += HandleMoleHit;
        newMole.OnHit += HandleMoleVanished;
    }

    private void HandleMoleHit(int x, int z)
    {
        pointCount++;
        moles[x, z] = false;
    }

    private void HandleMoleVanished(int x, int z)
    {
        moles[x, z] = false;
    }
}
