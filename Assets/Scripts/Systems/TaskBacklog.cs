using DanielEverland.ScriptableObjectArchitecture.Collections;
using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using System.Linq;
using UnityEngine;

namespace MineColony.Game.Systems
{
    [CreateAssetMenu(menuName = "Systems/TaskBacklog")]
    public class TaskBacklog : ScriptableObject
    {
        public ObjectCollection TaskCollection;
        public GameEvent OnTaskEnqueue;

        public void Enqueue(Object task)
        {
            TaskCollection.Add(task);

            if (OnTaskEnqueue != null)
            {
                OnTaskEnqueue.Raise();
            }
        }

        public Object Dequeue()
        {
            Object task = TaskCollection.First();

            TaskCollection.RemoveAt(0);

            return task;
        }
    }
}
