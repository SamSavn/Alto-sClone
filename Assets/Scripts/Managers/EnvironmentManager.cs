using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basso.Environment
{
    public class EnvironmentManager : MonoBehaviour
    {
        [SerializeField] private List<EnvironmentBlock> _blocks = new List<EnvironmentBlock>();
        [SerializeField] private float _speed;
        [SerializeField] private float _limit;

        [Space]
        [SerializeField] private bool _update;

        private void Start()
        {
            EnvironmentBlock previousBlock;
            EnvironmentBlock block;

            for (int i = 0; i < _blocks.Count; i++)
            {
                block = _blocks[i];
                previousBlock = null;

                if (block == null)
                    continue;

                if (i == 0)
                {
                    block.SetPosition(null);
                    continue;
                }

                previousBlock = _blocks[i - 1];
                previousBlock.Next = block;
                block.SetPosition(previousBlock);

                if (i < _blocks.Count - 1) 
                {
                    _lastBlock = _blocks[i + 1];
                }
            }
        }

        private EnvironmentBlock _lastBlock;

        private void Update()
        {
            if (!_update)
                return;

            foreach (EnvironmentBlock block in _blocks)
            {
                if (block == null)
                    continue;

                if (block.Position.x > _limit)
                {
                    block.Move(_speed);
                }
                else
                {
                    block.SetPosition(_lastBlock);
                    _lastBlock.Next = block;
                    _lastBlock = block;
                    _lastBlock.Next = null;
                }
            }
        }
    } 
}
