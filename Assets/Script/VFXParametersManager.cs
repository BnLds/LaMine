using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXParametersManager : MonoBehaviour
{
    private const string CONFORM_SPHERE_RADIUS = "ConformSphereRadius";

    [SerializeField] private AudioSpectrum _audioSpectrum;

    [Header("Exposed Properties Settings")]
    [SerializeField] private int _radiusAmplitude = 1;

    private VisualEffect _visualEffect;
    private float[] _spectrum;

    private void Awake()
    {
        _visualEffect = GetComponent<VisualEffect>();
    }

    private void Start()
    {
        _spectrum = _audioSpectrum.GetSpectrum();
    }

    private void Update()
    {
        _visualEffect.SetFloat(CONFORM_SPHERE_RADIUS, _spectrum[0] * _radiusAmplitude);
    }
}
