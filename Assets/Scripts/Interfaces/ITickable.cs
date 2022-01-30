/// <summary>
/// Implement in classes that need to tick "infrequently" : i.e. not every frame, and not all at the same time.
/// </summary>
public interface ITickable
{
    public void Staggered_Tick();
}
