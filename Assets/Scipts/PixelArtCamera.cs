using UnityEngine;
using UnityEngine.UI;
public class PixelArtCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private int _pixeldensity;
    private RenderTexture _renderTexture;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       UpdateRenderTexture(); 
    }

    public void UpdateRenderTexture()
    {
        if(_renderTexture != null) //Falls schon ein Rendertexture obj existiert altes freigeben
        {
            _renderTexture.Release(); 
        }
        float aspectRatio = (float)Screen.width / Screen.height;
        int cameraWidth = Mathf.RoundToInt(aspectRatio * _pixeldensity);

        _renderTexture = new RenderTexture(cameraWidth, _pixeldensity,16, RenderTextureFormat.ARGB32);
        _renderTexture.filterMode = FilterMode.Point; // damit Pixel nicht geblurred werden

        _renderTexture.Create();
        _camera.targetTexture = _renderTexture;
        _rawImage.texture = _renderTexture;
    }
}
