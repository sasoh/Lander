using UnityEngine;
using System.Collections;

public class PlayerParticleSystemHelperScript : MonoBehaviour
{

	private ArrayList particleSystems;

	void Start()
	{

		particleSystems = new ArrayList();

		// find particle systems with tag ThrustParticleSystem
		ParticleSystem[] allParticleSystems = GetComponentsInChildren<ParticleSystem>();
		foreach(ParticleSystem system in allParticleSystems)
		{
			if (system.tag == "ThrustParticleSystem")
			{
				particleSystems.Add(system);
			}
		}


	}

	public void SetParticleTrailStatus(bool status)
	{

		foreach (ParticleSystem system in particleSystems)
		{
			system.enableEmission = status;
		}

	}

}
