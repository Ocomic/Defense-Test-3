using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    
    [SerializeField] int IncreaseScore = 10;
    [SerializeField] int hitPoints = 2;

    GameObject parentGameObject
        ;

    

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidbody();

    }

    void AddRigidbody()
    {
        Rigidbody rbody = gameObject.AddComponent<Rigidbody>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        rbody.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints < 1)
        {
            KillEnemy();
        }
        
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);

        hitPoints--;
        
    }

    private void KillEnemy()
    {
        scoreBoard.ModifyScore(IncreaseScore);

        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);

        
    }

    
}
