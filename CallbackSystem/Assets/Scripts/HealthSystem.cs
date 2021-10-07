//Author: Pol Lozano Llorens
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private ParticleSystem deathParticleSystem;
    private Animator anim;

    private void Awake() => anim = GetComponent<Animator>();
  
    private void OnMouseDown()
    {
        StartDying();
    }

    private void StartDying()
    {
        anim.SetTrigger("die");
    }

    private void OnDeathAnimationStart()
    {
        DebugInfo debugInfo = new DebugInfo
        {
            obj = gameObject,
            verbosity = 0,
            message = "is dying"
        };

        EventHandler<DebugEvent>.FireEvent(new DebugEvent(debugInfo));
    }

    private void OnDeathAnimationEnd()
    {
        DeathInfo deathInfo = new DeathInfo
        {
            obj = gameObject,
            sound = deathSound,
            particleSystem = deathParticleSystem
        };

        EventHandler<DeathEvent>.FireEvent(new DeathEvent(deathInfo));
    }
}