using Unity.VisualScripting;
using UnityEngine;
using System;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField, Tooltip("The character to edit.")]
    BodySprite body;
    
    [SerializeField, Tooltip("The hands to edit.")]
    HandsSprite hands;

    [SerializeField]

    public void CycleShapeLeft()
    {
        // loop through a circular enum
        CharacterShape shape = body.shape;
        int shapeIndex = (int)shape;
        shapeIndex--;
        if (shapeIndex < 0)
        {
            shapeIndex = Enum.GetValues(typeof(CharacterShape)).Length - 1;
        }

        body.SetShape((CharacterShape)shapeIndex);
    }

    public void CycleShapeRight()
    {
        CharacterShape shape = body.shape;
        int shapeIndex = (int)shape;
        shapeIndex++;
        if (shapeIndex >= Enum.GetValues(typeof(CharacterShape)).Length)
        {
            shapeIndex = 0;
        }

        body.SetShape((CharacterShape)shapeIndex);
    }

    public void CycleColorLeft()
    {
        CharacterColor color = body.color;
        int colorIndex = (int)color;
        colorIndex--;
        if (colorIndex < 0)
        {
            colorIndex = Enum.GetValues(typeof(CharacterColor)).Length - 1;
        }

        body.SetColor((CharacterColor)colorIndex);
        hands.SetColor((CharacterColor)colorIndex);
    }

    public void CycleColorRight()
    {
        CharacterColor color = body.color;
        int colorIndex = (int)color;
        colorIndex++;
        if (colorIndex >= Enum.GetValues(typeof(CharacterColor)).Length)
        {
            colorIndex = 0;
        }

        body.SetColor((CharacterColor)colorIndex);
        hands.SetColor((CharacterColor)colorIndex);

    }

    public void CycleHandLeft()
    {
        CharacterHand hand = hands.hand;
        int handIndex = (int)hand;
        handIndex--;
        if (handIndex < 0)
        {
            handIndex = Enum.GetValues(typeof(CharacterHand)).Length - 1;
        }

        hands.SetHand((CharacterHand)handIndex);
    }

    public void CycleHandRight()
    {
        CharacterHand hand = hands.hand;
        int handIndex = (int)hand;
        handIndex++;
        if (handIndex >= Enum.GetValues(typeof(CharacterHand)).Length)
        {
            handIndex = 0;
        }

        hands.SetHand((CharacterHand)handIndex);
    }
}