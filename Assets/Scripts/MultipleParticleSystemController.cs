using UnityEngine;
using System.Collections;

public class MultipleParticleSystemController : MonoBehaviour
{

	private ArrayList particleSystems;

	// Use this for initialization
	void Start()
	{

		// find particle systems
		ParticleSystem[] systems = GetComponentsInChildren<ParticleSystem>();
		particleSystems = new ArrayList(systems.Length);

		foreach (ParticleSystem system in systems)
		{
			particleSystems.Add(system);
		}

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void BeginEmitting()
	{

		foreach (ParticleSystem system in particleSystems)
		{
			system.Play();
		}

	}
}
