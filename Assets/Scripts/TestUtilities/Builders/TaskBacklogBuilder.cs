using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using MineColony.Game.ScriptableObjectArchitecture.Collections;
using MineColony.Game.Systems;
using MineColony.TestUtilities.Facades;
using UnityEngine;

namespace MineColony.TestUtilities.Builders
{
    public class TaskBacklogBuilder
    {
        private TaskBacklog _taskBacklog;

        public TaskBacklogBuilder()
        {
            _taskBacklog = ScriptableObject.CreateInstance<TaskBacklog>();
        }

        public TaskBacklog Build()
        {
            return _taskBacklog;
        }

        public TaskBacklogBuilder AddTaskCollection()
        {
            _taskBacklog.TaskCollection = ScriptableObject.CreateInstance<TaskCollection>();

            return this;
        }

        public TaskBacklogBuilder AddTaskCollection(params Task[] tasks)
        {
            TaskCollection taskCollection = ScriptableObject.CreateInstance<TaskCollection>();

            foreach (Task task in tasks)
            {
                taskCollection.Add(task);
            }

            _taskBacklog.TaskCollection = taskCollection;

            return this;
        }

        public TaskBacklogBuilder AddOnTaskEnqueue()
        {
            _taskBacklog.OnTaskEnqueue = ScriptableObject.CreateInstance<GameEvent>();

            return this;
        }

        public TaskBacklogBuilder AddOnTaskEnqueue(GameEventFacade gameEventFacade)
        {
            _taskBacklog.OnTaskEnqueue = gameEventFacade.GameEvent;

            return this;
        }
    }
}