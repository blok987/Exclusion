using UnityEngine;

[System.Serializable]
public class BackgroundElement
{
    public SpriteRenderer backgroundSprite;
    [Range(0, 1)] public float scrollSpeed;
    [HideInInspector] public Material spriteMaterial;
}

public class NewParallax : MonoBehaviour
{
    private const float SCROLL_MULTIPLIER = 0.01f;

    [SerializeField] private BackgroundElement[] backgroundElements;

    private void Start()
    {
        foreach (BackgroundElement element in backgroundElements)
        {
            element.spriteMaterial = element.backgroundSprite.material;
        }
    }

    private void Update()
    {
        foreach (BackgroundElement element in backgroundElements)
        {
            element.spriteMaterial.mainTextureOffset = new Vector2(transform.position.x * element.scrollSpeed * SCROLL_MULTIPLIER, 0);
        }
    }
}
