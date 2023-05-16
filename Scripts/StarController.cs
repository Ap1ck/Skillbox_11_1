using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]

public class StarController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _starPartical;

    private Animator _starAnimation;

    private int _quintitiCoin=1;

    public static event Action<int> _coin;

    private void Start()
    {
        _starAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _coin?.Invoke(_quintitiCoin);
        _starAnimation.SetTrigger("Destroy");
        Coroutine star = StartCoroutine(deleted());
    }

    private IEnumerator deleted()
    {
        _starPartical.gameObject.SetActive(true);
        _starPartical.Play();
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }
}
