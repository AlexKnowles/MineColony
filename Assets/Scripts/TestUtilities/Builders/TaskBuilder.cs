using MineColony.Game.Systems;
using UnityEngine;

namespace MineColony.TestUtilities.Builders
{
    public class TaskBuilder
    {
        private readonly Task _task;

        public TaskBuilder()
        {
            _task = ScriptableObject.CreateInstance<Task>();
        }

        public Task Build()
        {
            return _task;
        }

        public TaskBuilder AddName(string name)
        {
            _task.name = name;

            return this;
        }
    }
}