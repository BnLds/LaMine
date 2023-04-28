using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSpectrum : MonoBehaviour
{
    [SerializeField] private FFTWindow _fftWindow = FFTWindow.Hamming;

    private float[] _samples;

    private AudioSource _audioSource;
    private int _sampleSize;

    private void Awake()
    {
        _sampleSize = 512;
        _samples = new float[_sampleSize];

        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audioSource.GetSpectrumData(_samples, 0, _fftWindow);
    }

    public float[] GetSpectrum()
    {
        return _samples;
    }

    public int GetSamplesSize()
    {
        return _sampleSize;
    }
}
