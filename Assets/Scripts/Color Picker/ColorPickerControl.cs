using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorPickerControl : MonoBehaviour
{
    public float currentHue, currentSat, currentVal;
    [SerializeField] private RawImage hueImage, satValImage, outputImage;
    [SerializeField] private Slider hueSlider;
    [SerializeField] private TMP_InputField hexInputField;
    private Texture2D hueTexture, svTexture, outputTexture;
    [SerializeField] MeshRenderer changeThisColor;

    private void CreateHueImage()
    {
        hueTexture = new Texture2D(1, 16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "HueTexture";

        for (int i = 0; i < hueTexture.height; i++)
        {
            hueTexture.SetPixel(0, i, Color.HSVToRGB((float)i / hueTexture.height, 1, 0.05f));

        }

        hueTexture.Apply();
        currentHue = 0;

        hueImage.texture = hueTexture;

    }
    private void CreateSVImage()
    {
        svTexture = new Texture2D(16, 16);
        svTexture.wrapMode = TextureWrapMode.Clamp;
        svTexture.name = "SetValTexture";

        for(int y = 0;y < svTexture.height; y++)
        {
            for(int x = 0;x < svTexture.width;x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(
                                    currentHue,
                                    (float)y / svTexture.height,
                                    (float)x / svTexture.width));

            }
        }

        svTexture.Apply();
        currentSat = 0;
        currentVal = 0;

        satValImage.texture = svTexture;

    }




}
