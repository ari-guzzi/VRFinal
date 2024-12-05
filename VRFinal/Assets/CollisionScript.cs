using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] 
    private AudioSource myAudioSource;
    public Transform movingMirror; 
    public Transform mirrorPos;
    private float currentZ;

    // Start is called before the first frame update
    void Start()
    {
        currentZ = movingMirror.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        //movingMirror.position = mirrorPos.position;
         movingMirror.DOMove(mirrorPos.position, 2f)
            .SetEase(Ease.InQuad);
        myAudioSource.Play();
    }
}
