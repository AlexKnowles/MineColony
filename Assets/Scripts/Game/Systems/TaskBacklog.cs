using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using MineColony.Game.ScriptableObjectArchitecture.Collections;
using System.Linq;
using UnityEngine;

namespace MineColony.Game.Systems
{
    [CreateAssetMenu(menuName = "Systems/TaskBacklog")]
    public class TaskBacklog : ScriptableObject
    {
        public TaskCollection TaskCollection;
        public GameEvent OnTaskEnqueue;

        public void Enqueue(Task task)
        {
            TaskCollection.Add(task);

            if (OnTaskEnqueue != null)
            {
                OnTaskEnqueue.Raise();
            }
        }

        public Task Dequeue()
        {
            if(TaskCollection == null || TaskCollection.Count == 0)
            {
                return null;
            }

            Task task = TaskCollection.First();

            TaskCollection.RemoveAt(0);

            return task;
        }
    }
}
