using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basso.Environment
{
    public class EnvironmentManager : MonoBehaviour
    {
        [SerializeField] private List<EnvironmentBlock> _blocks = new List<EnvironmentBlock>();

        private void Start()
        {
            EnvironmentBlock previousBlock;
            EnvironmentBlock block;
            EnvironmentBlock nextBlock;

            for (int i = 0; i < _blocks.Count; i++)
            {
                block = _blocks[i];
                previousBlock = null;
                nextBlock = null;

                if (i == 0)
                {
                    block.SetPosition(null);
                    continue;
                }

                previousBlock = _blocks[i - 1];
                previousBlock.Next = block;

                if (i < _blocks.Count - 1) 
                {
                    nextBlock = _blocks[i + 1];
                }

                block.SetPosition(previousBlock);
            }
        }

        private void Update()
        {
            
        }
    } 
}
