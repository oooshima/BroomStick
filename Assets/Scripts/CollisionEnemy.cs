//ぶつかったキノコを飛ばす　playerにアタッチ

using UnityEngine;

namespace Assets.Scripts
{
	public class CollisionEnemy : MonoBehaviour
	{
		private float impulseMagnitude;

		private void Start()
		{
			this.impulseMagnitude = 250.0f;
		}

		private void Update()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
			var rigid = collision.gameObject.GetComponent<Rigidbody>();
			// 衝突相手はRigidbodyをアタッチした立方体で、別途空から降らせる
			//var rigid = collision.gameObject(;

			Vector3 pos = transform.position;
			transform.position = new Vector3(pos.x+10.0f,pos.y,pos.z);
			var impulse = (rigid.position - transform.position).normalized * this.impulseMagnitude;
	

			rigid.AddForce(impulse, ForceMode.Impulse);

		}
	}
}