using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public TextMeshPro CounterTxt;
    [SerializeField] private GameObject stickMan;
    [Range(0f, 1f)][SerializeField] private float DistanceFactor, Radius;

    public Transform enemy;
    public bool attack;

    void Start()
    {
        for (int i = 0; i < Random.Range(20,120); i++)
        {
            Instantiate(stickMan, transform.position, new Quaternion(0f, 100f, 0f ,1f),transform);
        }

        CounterTxt.text = (transform.childCount - 1).ToString();    

       FormatStickMan();
    }

    
    void Update()
    {
        if (attack && transform.childCount > 1) 
        {
            var enemyPos = new Vector3(enemy.position.x, transform.position.y, enemy.position.z);
            
            var enemyDirection  = enemy.position - transform.position;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).rotation = Quaternion.Slerp(transform.GetChild(i).rotation, quaternion.LookRotation(enemyDirection, Vector3.up),
                    Time.deltaTime * 3f);

                if (enemy.childCount>1)
                {
                    var distance = enemy.GetChild(1).position - transform.GetChild(i).position;

                    if (distance.magnitude < 4f)  //mavilerin
                    {
                        transform.GetChild(i).position = Vector3.Lerp(transform.GetChild(i).position,  
                            enemy.GetChild(1).position, Time.deltaTime * 1f); // g˝rm˝z˝lar˝n
                    }
                }
               
            }
        }
    }

    private void FormatStickMan()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * Radius);

            var NewPos = new Vector3(x, 0f, z);

            transform.transform.GetChild(i).localPosition = NewPos;
        }
    }


    public void AttackThem(Transform enemyForce)
    {
        enemy = enemyForce;
        attack = true;
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    transform.GetChild(i).GetComponent<Animator>().SetBool("run", true);
        //}
    }

    public void StopAttacking()
    {
        PlayerManager.PlayerManager›nstance.gameState = attack = false;
    }
}
