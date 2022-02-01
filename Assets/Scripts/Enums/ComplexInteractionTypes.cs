[System.Flags]
public enum ComplexInteractionTypes
{
    None = 0,
    CollisionEnter = InteractionTypes.Collision | InteractionTypes.Enter,
    CollisionStay = InteractionTypes.Collision | InteractionTypes.Stay,
    TriggerEnter = InteractionTypes.Trigger | InteractionTypes.Enter,
    TriggerStay = InteractionTypes.Trigger | InteractionTypes.Stay,
}