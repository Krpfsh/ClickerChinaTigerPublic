using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimScaleBank : MonoBehaviour
{
    private Vector3 OrigScale;
    // Start is called before the first frame update
    void Start()
    {
        OrigScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.DOScale(OrigScale * 1.2f, 0.3f)
                .OnComplete(() =>
                {
                    gameObject.transform.DOScale(OrigScale, 0.3f);
                });
        }

    }
}
