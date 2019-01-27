using DanielEverland.ScriptableObjectArchitecture.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCountOfTiles : MonoBehaviour
{
    public Vector3Collection SelectedTiles;
    public Text TextComponent;

    public void UpdateText()
    {
        TextComponent.text = string.Format("Number of Selected Tiles: {0}", SelectedTiles.Count);
    }

}
