using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace WildBall.Inputs
{
    public class ResultWinner : MonoBehaviour
    {
        [SerializeField] private Text _currentQuantityStar;
        [SerializeField] private Text _quantityStar;
        [SerializeField] private Image _image;

        private int _quantity;

        private void OnEnable()
        {
            StarController.star += TakeStar;
        }

        private void OnDisable()
        {
            StarController.star -= TakeStar;
        }

        private void TakeStar(int value)
        {
            _quantity += value;
            _currentQuantityStar.text =": "+ _quantity.ToString();
            _quantityStar.text = _quantity.ToString();
        }

        private void OnCollisionEnter(Collision other)
        {
            _quantityStar.gameObject.SetActive(false);
        }
    }
}

