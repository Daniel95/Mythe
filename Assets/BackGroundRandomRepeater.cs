using UnityEngine;
using System.Collections;

public class BackGroundRandomRepeater : BackgroundRepeater {

    [SerializeField]
    private GameObject upperBG;

    private SpriteRandomizer upperBGSpriteRandomizer;

    private SpriteRenderer upperBGSpriteRenderer;

    private SpriteRenderer lowerPartSpriteRenderer;

    protected override void Start()
    {
        base.Start();
        upperBGSpriteRandomizer = upperBG.GetComponent<SpriteRandomizer>();
        upperBGSpriteRenderer = upperBG.GetComponent<SpriteRenderer>();
        lowerPartSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Repeat()
    {
        base.Repeat();
        lowerPartSpriteRenderer.sprite = upperBGSpriteRenderer.sprite;
        upperBGSpriteRandomizer.Randomize();
    }
}
