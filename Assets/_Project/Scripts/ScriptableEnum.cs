using UnityEngine;

public class ScriptableEnum : ScriptableObject
{
    [SerializeField] private string id;
    public string ID => id;
}
