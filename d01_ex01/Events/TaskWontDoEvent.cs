using d01_ex01.Tasks;
using System;

namespace d01_ex01.Events
{
    public record TaskWontDoEvent(TaskState State, DateTime DateTime) : Event(State, DateTime);
}