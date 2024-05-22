using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class S_HotbarItem : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI countText;

    public void RefreshSlot(Image newImage, int count)
    {
        gameObject.SetActive(true);
        image.sprite = newImage.sprite;
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void ClearSlot()
    {
        gameObject.SetActive(false);
    }
}
