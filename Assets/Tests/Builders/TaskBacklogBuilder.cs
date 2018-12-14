using DanielEverland.ScriptableObjectArchitecture.Collections;
using DanielEverland.ScriptableObjectArchitecture.Events.GameEvents;
using MineColony.Game.Systems;
using MineColony.Tests.Utilities;
using UnityEngine;

namespace MineColony.Tests.Builders
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
            _taskBacklog.TaskCollection = new ObjectCollection();

            return this;
        }

        public TaskBacklogBuilder AddOnTaskEnqueue()
        {
            _taskBacklog.OnTaskEnqueue = new GameEvent();

            return this;
        }

        public TaskBacklogBuilder AddOnTaskEnqueue(GameEventListenerFacade gameEventListenerFacade)
        {
            GameEvent gameEvent = new GameEvent();

            gameEvent.AddListener(gameEventListenerFacade);

            _taskBacklog.OnTaskEnqueue = gameEvent;

            return this;
        }
    }
}