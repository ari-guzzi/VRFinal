using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoSquenceCode : MonoBehaviour
{
    public Transform[] shapes;
    [SerializeField] 
    private float tweenedValue;
    // Start is called before the first frame update
    void Start()
    {
        // Sequence s = DOTween.Sequence();

        // foreach (Transform shape in shapes)
        // {
        //     s.Append(shape.DOMoveX(5, 2f));
        // }
        // s.OnComplete(() => {
        //     foreach (Transform shape in shapes)
        //     {
        //         s.Append(shape.DOScale(new Vector3(0,0,0), 1f));
        //     }
        // });
        // //tweening values
        // DOVirtual.Float(0, 10, 3f, (float v) => {
        //     tweenedValue = v;
        // });
    shapes[0].DOShakePosition(1f, 0.8f).SetLoops(-1);
    shapes[0].DOKill(); //stops anything happening to the object

    shapes[1].gameObject.GetComponent<MeshRenderer>().material
        .DOColor(Random.ColorHSV(), 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
