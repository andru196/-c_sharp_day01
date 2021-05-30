using System;
using System.Collections;
using System.Collections.Generic;
using d01_ex01.Events;

namespace d01_ex01.Tasks
{
    public class Task
    {
        public TaskPriority Priority {get; init;}
        public TaskType Type {get;init;}
        public string Title {get;init;}
        public string Summary {get;init;}
        public DateTime? Deadline {get;init;}
        public List<Event> EventsList {get;}

        public Task()
        {
            EventsList = new List<Event>()
            {
                new CreatedEvent(TaskState.New, DateTime.Now)
            };
        }

        private Dictionary<TaskState, TaskState[]> _stateTransforms = 
            new Dictionary<TaskState, TaskState[]>
        {
            {TaskState.New, new TaskState[] {TaskState.Complited, TaskState.NotActual}},
            {TaskState.NotActual, Array.Empty<TaskState>()},
            {TaskState.Complited, Array.Empty<TaskState>()},
        };

        public bool CanSetState(TaskState state)
        {
            if (_stateTransforms.TryGetValue(EventsList[EventsList.Count - 1].State, out var arr))
                foreach (var s in arr)
                    if (s == state)
                        return (true);
            return true;
        }

        public override string ToString()
            => $"{Title}\n[{Type}][{EventsList[EventsList.Count - 1].State}]\nPriority: {Priority}, Due till {Deadline}\n{Summary}";
    }
}