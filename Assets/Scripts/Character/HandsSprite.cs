using UnityEngine;

public class HandsSprite : MonoBehaviour
{
    public CharacterSpriteCollection spriteCollection;

    public CharacterColor color;

    public CharacterHand hand;

    private SpriteRenderer leftHandRenderer;
    private SpriteRenderer rightHandRenderer;

    private void Awake()
    {
        leftHandRenderer = transform.Find("LeftHand").GetComponent<SpriteRenderer>();
        rightHandRenderer = transform.Find("RightHand").GetComponent<SpriteRenderer>();
        LoadPrefs();
        UpdateSprite();
    }

    public void SetColor(CharacterColor color)
    {
        this.color = color;
        UpdateSprite();
    }

    public void SetHand(CharacterHand hand)
    {
        this.hand = hand;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        Sprite[] sprites = null;
        switch (color)
        {
            case CharacterColor.Blue:
                sprites = spriteCollection.Blue_Hands;
                break;
            case CharacterColor.Green:
                sprites = spriteCollection.Green_Hands;
                break;
            case CharacterColor.Pink:
                sprites = spriteCollection.Pink_Hands;
                break;
            case CharacterColor.Purple:
                sprites = spriteCollection.Purple_Hands;
                break;
            case CharacterColor.Red:
                sprites = spriteCollection.Red_Hands;
                break;
            case CharacterColor.Yellow:
                sprites = spriteCollection.Yellow_Hands;
                break;
        }

        if (sprites == null)
        {
            Debug.LogError("No sprites found for color: " + color);
            return;
        }

        // hand shape
        leftHandRenderer.sprite = sprites[(int)hand];
        rightHandRenderer.sprite = sprites[(int)hand];
    }

    private void LoadPrefs()
    {
        color = (CharacterColor)PlayerPrefs.GetInt("color", 0);
        hand = (CharacterHand)PlayerPrefs.GetInt("hand", 0);

    }
}