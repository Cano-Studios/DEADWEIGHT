using UnityEngine;
using UnityEngine.TextCore.Text;

public class BodySprite : MonoBehaviour
{
    public CharacterSpriteCollection spriteCollection;

    public CharacterColor color;
    public CharacterShape shape;

    private SpriteRenderer bodyRenderer;

    private void Awake()
    {
        bodyRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    public void SetColor(CharacterColor color)
    {
        this.color = color;
        UpdateSprite();
    }

    public void SetShape(CharacterShape shape)
    {
        this.shape = shape;
        UpdateSprite();
    }

    // updatesprite
    private void UpdateSprite()
    {
        Sprite[] sprites = null;
        switch (color)
        {
            case CharacterColor.Blue:
                sprites = spriteCollection.Blue_Bodies;
                break;
            case CharacterColor.Green:
                sprites = spriteCollection.Green_Bodies;
                break;
            case CharacterColor.Pink:
                sprites = spriteCollection.Pink_Bodies;
                break;
            case CharacterColor.Purple:
                sprites = spriteCollection.Purple_Bodies;
                break;
            case CharacterColor.Red:
                sprites = spriteCollection.Red_Bodies;
                break;
            case CharacterColor.Yellow:
                sprites = spriteCollection.Yellow_Bodies;
                break;
        }

        if (sprites == null)
        {
            Debug.LogError("No sprites found for color: " + color);
            return;
        }

        //color
        bodyRenderer.sprite = sprites[(int)shape];
    }
}