using UnityEngine;

[CreateAssetMenu(menuName = "CardsInfo")]
public class CardConfig : ScriptableObject
{
    [SerializeField, Header("ID")] private int _id;
    public int ID => _id;

    [Header("Cardname & Description")]

    [SerializeField] private string _name;
    [SerializeField, TextArea] private string _description;

    [Header("Ball Properties")]

    [SerializeField] private bool _ballCatchable;
    [SerializeField] private bool _ballCatching;
    [SerializeField] private bool _ballHitting;

    [Space]

    [SerializeField, Range(0.5f, 2f)] private float _ballSize;
    [SerializeField, Range(0.5f, 2f)] private float _ballSpeed;
    [SerializeField, Range(-2f, 2f)] private float _ballTimeInHand;

    [Header("Cooldown")]

    [SerializeField] private float _cooldown;

    [Header("Amount of balls")]

    [SerializeField] private bool _multipleBalls;
    [SerializeField, Range(1, 3)] private int _ballCount;

}