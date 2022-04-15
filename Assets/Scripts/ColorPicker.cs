using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Material materiall;
    public Material Emitionmaterial;

    void Update()
    {
        
        materiall.color = fcp.color;
        Emitionmaterial.SetColor("_EmissionColor", materiall.color);

    }
}
