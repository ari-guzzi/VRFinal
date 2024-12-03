using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoTweenCode : MonoBehaviour
{
    [SerializeField] 
    private Transform demoCube;
    // Start is called before the first frame update
    void Start()
    {
        // transform.DOMoveX(5f, 1f)
        //     .SetEase(Ease.InQuad, 1f)
        //     .SetLoops(-1, LoopType.Yoyo);

        // demoCube.DORotate(new Vector3(0,180,0), 1f, RotateMode.FastBeyond360)
        //     .SetEase(Ease.Linear)
        //     .SetLoops(-1);

        // demoCube.DOLocalMoveY(-2,2f)
        //     .SetEase(Ease.InOutCubic)
        //     .SetLoops(-1, LoopType.Yoyo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
