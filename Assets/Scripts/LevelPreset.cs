using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPreset : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }


    //[SerializeField] private float _speed;
    //public float Speed  { get { return _speed; } }
    

    [SerializeField] private ColorPalette _colorPalette;
    public ColorPalette ColorPalette { get { return _colorPalette; } }


    [SerializeField] private GameObject _foodPrefab;
    public GameObject FoodPrefab { get { return _foodPrefab; } }

}
