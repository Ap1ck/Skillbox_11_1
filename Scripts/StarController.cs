using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]

public class StarController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _starPartical;

    public static Action<int> takeStar;
    private Animator _starAnimation;

    private int _quantity=1;

    private void Start()
    {
        _starAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _starAnimation.SetTrigger("Destroy");
        Coroutine star = StartCoroutine(deleted());
        takeStar?.Invoke(_quantity);
    }

    private IEnumerator deleted()
    {
        _starPartical.gameObject.SetActive(true);
        _starPartical.Play();
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }
}
