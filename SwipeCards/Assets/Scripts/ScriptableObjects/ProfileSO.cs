using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProfile", menuName = "Profile")]
public class ProfileSO : ScriptableObject
{
    public new string name;
    public string age;
    public string description;
    public Sprite profilePicture;
}
