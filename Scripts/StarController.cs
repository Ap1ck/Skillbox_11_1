using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class StarController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _starPartical;

    private Animator _starAnimation;

    private void Start()
    {
        _starAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _starAnimation.SetTrigger("12");
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
