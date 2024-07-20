using UnityEngine;

public class FaceSprite : MonoBehaviour
{
    public CharacterSpriteCollection spriteCollection;
    public CharacterFace face;
    private SpriteRenderer faceRenderer;

    private int[] idleFaces = new int[]{
        1, 4, 5, 6, 8, 10
    };

    private void Awake()
    {
        faceRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    void FixedUpdate()
    {
        if (Random.Range(0, 100) == 0)
        {
            int randomFace = Random.Range(0, idleFaces.Length);
            if (System.Array.IndexOf(idleFaces, randomFace) != -1)
            {
                Debug.Log("Idle face change");
                SetFace((CharacterFace)randomFace);
            }
        }
    }

    public void SetFace(CharacterFace face)
    {
        this.face = face;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        faceRenderer.sprite = spriteCollection.Faces[(int)face];
    }

}