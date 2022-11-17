using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSceneData", menuName = "Data/SceneData/KitchenData")]
public class KitchenData : SceneData
{
    public bool gotKnife = false;
    public bool ovenOpened = false;
    public bool chefActive = false;
    public bool foodObtained = false;
}

