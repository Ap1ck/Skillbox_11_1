using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Collider))]
    public class StarController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _starPartical;
        [SerializeField] private Text _starQuantityText;

        private Animator _starAnimation;

        private int _quatnity = 1;

        public static event Action<int> star;

        private void Start()
        {
            _starAnimation = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                star?.Invoke(_quatnity);
                _starAnimation.SetTrigger("Destroy");
                Coroutine starCoroutine = StartCoroutine(deleted());
            }
        }

        private IEnumerator deleted()
        {
            _starPartical.gameObject.SetActive(true);
            _starPartical.Play();
            yield return new WaitForSecondsRealtime(0.25f);
            Destroy(gameObject);
        }
    }
}

