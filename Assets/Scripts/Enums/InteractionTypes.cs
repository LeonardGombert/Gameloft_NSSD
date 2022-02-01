[System.Flags]
public enum InteractionTypes
{
    Collision = 1 << 0,
    Trigger = 1 << 1,
    Enter = 1 << 2,
    Stay = 1 << 3,
    Exit = 1 << 4,
}