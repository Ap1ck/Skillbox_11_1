using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace WildBall.Inputs
{
    public class ResultWinner : MonoBehaviour
    {
        [SerializeField] private Text _coinText;
        [SerializeField] private Image _image;

        public static event Action<Image> _winnerImage;

        private int _quantityCoin = 0;

        private void OnEnable()
        {
            StarController._coin += Result;
        }

        private void OnDisable()
        {
            StarController._coin -= Result;
        }

        private void Result(int value)
        {
            _quantityCoin += value;

            _coinText.text = "Star quantity: " + _quantityCoin.ToString();
        }

        private void OnTriggerEnter(Collider other)
        {
            _winnerImage?.Invoke(_image);
        }
    }
}

