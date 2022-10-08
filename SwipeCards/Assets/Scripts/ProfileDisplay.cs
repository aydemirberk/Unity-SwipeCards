using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProfileDisplay : MonoBehaviour
{
    public ProfileSO profile;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image profileImage;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = profile.name + ", " +profile.age;
        descriptionText.text = profile.description;
        profileImage.sprite = profile.profilePicture;
    }

}
