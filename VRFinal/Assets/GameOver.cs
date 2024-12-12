using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneNameToLoad = "GameOver";
    public Transform player;
    void Update() {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance < 5.0f){
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         SceneManager.LoadScene(sceneNameToLoad);
    //     }
    // }
}
