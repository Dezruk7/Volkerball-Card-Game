using UnityEngine;
internal abstract class CardGrowth : MonoBehaviour
{
    [SerializeField] private CardConfig _config;
    public CardConfig cardConfig => _config;
    public CardGrowth(CardConfig config)
    {
        _config = config;
    }
}