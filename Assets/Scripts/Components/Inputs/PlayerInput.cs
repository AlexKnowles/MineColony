using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using UnityEngine;

namespace MineColony.Game.Components.Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        [Range(1,4)]
        public int PlayerNumber = 1;

        public string AxisPrefix { get; internal set; }

        public void OnEnable()
        {
            AxisPrefix = string.Format("Player{0}_", PlayerNumber);
        }

        private void Update()
        {

        }
    }
}