using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderFiller : MonoBehaviour
{
    private Image image;
    private Color color;

    private void Awake(){
        image = GetComponent<Image>();
        color = image.color;
    }

    public Color GetColor() { return color; }
    public void SetColor(Color color){ image.color = color; }
    public void SetColor(float r, float g, float b, float a){
        color = new Vector4(r/255, g/255, b/255, a/255);
        SetColor(color);
    }
    public void SetColor(Vector4 color){
        this.color = color;
        SetColor(this.color);
    }

    private void Start() { }
    private void Update() { }
}
