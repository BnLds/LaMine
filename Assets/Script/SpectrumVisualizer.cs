using UnityEngine;

public class SpectrumVisualizer : MonoBehaviour
{
    [SerializeField] private Transform _cubePrefab;
    [SerializeField] private AudioSpectrum _audioSpectrum;
    [SerializeField] private float _maxScale = 10;

    private Transform[] _cubesSpectrum;
    private float[] _spectrum;
    private int _sampleSize;

    private void Start()
    {
        _sampleSize = _audioSpectrum.GetSamplesSize();
        _spectrum = _audioSpectrum.GetSpectrum();
        _cubesSpectrum = new Transform[_sampleSize];

        for (int i = 0; i < _spectrum.Length; i++)
        {
            Vector3 cubePosition = transform.position;
            Transform cubeParent = transform;
            float cubeRotationAngle = (float)360 / (float)_sampleSize * (float)i;
            Quaternion cubeRotation = Quaternion.Euler(0, cubeRotationAngle, 0);

            Transform cube = Instantiate(_cubePrefab, cubePosition, cubeRotation, cubeParent);
            cube.transform.position = cube.transform.forward * 100;

            _cubesSpectrum[i] = cube;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _sampleSize; i++)
        {
            if(_cubesSpectrum[i] != null)
            {
                _cubesSpectrum[i].transform.localScale = new Vector3 (1, _spectrum[i] * _maxScale, 1);
            }
        }
    }

}
