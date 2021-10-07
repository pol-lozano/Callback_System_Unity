//Author: Pol Lozano Llorens
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            Spawn();
    }

    void Spawn()
    {
        GameObject gameObject = Instantiate(prefab, Random.insideUnitSphere * 25, Quaternion.identity);
        DebugInfo debugInfo = new DebugInfo
        {
            obj = gameObject,
            verbosity = 0,
            message = "was spawned"
        };
        EventHandler<DebugEvent>.FireEvent(new DebugEvent(debugInfo));
    }
}