using UnityEngine;

public class ToggleScreen : MonoBehaviour
{
    public void OnCloseClick()
    {
        gameObject.SetActive(false);
    }

    // ugly code
    public void onCreditsOpen()
    {
        gameObject.SetActive(true);
    }
}