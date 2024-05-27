using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioClipRefsSO : ScriptableObject
{
    public AudioClip[] chop;
    public AudioClip[] deliveryFailed;
    public AudioClip[] deliverySuccessed;
    public AudioClip[] footstep;
    public AudioClip[] drop;
    public AudioClip[] pickup;
    public AudioClip[] sizzle;
    public AudioClip[] trash;
    public AudioClip[] warning;
}
