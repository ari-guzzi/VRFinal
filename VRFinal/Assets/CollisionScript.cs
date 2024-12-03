using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionScript : MonoBehaviour
{
    public Transform movingMirror; 
    public Transform mirrorPos;
    //private float currentZ = movingMirror.position.z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        movingMirror.position = mirrorPos.position;

        //movingMirror.DOMove(new Vector3(mirrorPos.position.x, mirrorPos.position.y, currentZ), 2f)
        //    .SetEase(Ease.InQuad);
    }
}
