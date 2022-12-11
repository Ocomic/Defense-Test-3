using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    bool isTransitioning = false;
    

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
        Debug.Log($"{this.name} **Triggered by ** {other.gameObject.name}" );
    }

    void ReloadLevel()
    {

        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        isTransitioning = true;
        //audioSource.Stop();
        //crashParticles.Play();
        //todo add particle effect on crash
        GetComponent<PlayerControler>().enabled = false;
        //audioSource.PlayOneShot(crash);
        Invoke("ReloadLevel", delay);

    }

    

}
