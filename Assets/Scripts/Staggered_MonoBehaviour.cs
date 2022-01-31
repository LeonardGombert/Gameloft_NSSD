using UnityEngine;

/// <summary>
/// Allows certain recurrent calls to be staggered across several frames. Decreases the chance that two intensive calls occur during the same frame.
/// 
/// A little overkill, espcially in this context, but I didn't feel like re-writing this code several times, 
/// and and interface implementation wasn't working well enough
/// 
/// </summary>
public class Staggered_MonoBehaviour : MonoBehaviour
{
    private float _tickFrequency = 0.0f;
    private float _timePassed = 0.0f;

    private void Update()
    {
        if (_timePassed >= _tickFrequency)
        {
            Staggered_Tick();

            _timePassed = 0;
            _tickFrequency = Random.Range(0.01f, 0.25f);
        } // ticks occur irregularly. Decreases chance of overlapping ticks of the same nature.
        _timePassed += Time.deltaTime;
    }

    public virtual void Staggered_Tick() { }
}
