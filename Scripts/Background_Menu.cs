using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Menu : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private MeshRenderer _meshRenderer;

    private Vector2 _meshOffset;

    private void Start()
    {
        _meshOffset = _meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void Update()
    {
        var x = Mathf.Repeat(Time.time * _speed, 1);
        var offset = new Vector2(x, _meshOffset.y);

        _meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }

    private void OnDisable()
    {
        _meshRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
    }
}
