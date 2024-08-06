using UnityEngine;

namespace Basso.Environment
{
	public class EnvironmentBlock : MonoBehaviour
	{
		[SerializeField] Transform _leftSocket;
		[SerializeField] Transform _rightSocket;

		public EnvironmentBlock Next {  get; set; }
		public Vector2 Position => transform.position;
		public float Width { get; private set; }

        private void Awake()
        {
            Width = Vector2.Distance(_leftSocket.position, _rightSocket.position);
        }

        public void Move(float speed)
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		public void SetPosition(EnvironmentBlock previous)
		{
			Vector2 pos = Vector2.zero;

            if (previous != null)
			{
				pos = previous.Position;
				pos.x += previous.Width;
				transform.position = pos;
				return;
			}

			pos.y = transform.position.y;
			transform.position = pos;
		}
	} 
}
