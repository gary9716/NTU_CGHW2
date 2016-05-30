using UnityEngine;
using AIBehavior;


namespace AIBehaviorExamples
{
	public class ExampleProjectile : MonoBehaviour
	{
		public GameObject explosionPrefab;
		public string hitTag = "Player";
		public AttackData attackData;


		void Awake()
		{
			GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000.0f);
			Destroy(gameObject, 10.0f);
		}


		void OnTriggerEnter(Collider col)
		{
			if (col.gameObject.tag == hitTag)
			{
				SpawnFlames();
				col.SendMessage("Damage",  attackData.damage);

				if ( attackData.target != null )
				{
					col.SendMessage("HitDirection", (transform.position - attackData.target.position).normalized);
				}
			}
		}


		void OnCollisionEnter(Collision col)
		{
			SpawnFlames();
		}


		void SpawnFlames()
		{
			Destroy(gameObject);
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		}
	}
}