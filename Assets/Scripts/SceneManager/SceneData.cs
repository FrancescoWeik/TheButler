using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSceneData", menuName = "Data/SceneData/BaseData")]
public class SceneData : ScriptableObject
{
    [Header("Lobby")]
    public bool cleaningLadyActive = false;
    [Header("LivingRoom")]
    [Header("Kitchen")]
    public bool gotKnife = false;
    public bool ovenOpened = false;
    public bool chefActive = false;
    public bool foodObtained = false;
    [Header("Garden")]
    public bool alreadyFed = false;
    public bool ropeOnWindow = false;
    [Header("HouseScene")]
    public bool gaveFoto = false;
    public bool ropeObtained = false;
}