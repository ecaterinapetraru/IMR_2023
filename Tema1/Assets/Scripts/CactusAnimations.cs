using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    public SpawnManager mSpawnManager;
    public Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
    }

    void InitializeComponents()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PerformAttacks();
        PerformMoreThanOneAttack();
    }

    void PerformAttacks()
    {
        mAnimator.SetTrigger("trigger_attack");
    }

    void PerformMoreThanOneAttack()
    {
        int i, j;

        for (i = 0; i < SpawnManager.ObjectsList.Capacity - 1; i++)
        {
            for (j = i + 1; j < SpawnManager.ObjectsList.Capacity; j++)
            {
                mAnimator.SetTrigger("trigger_attack");
            }
        }
    }
}
