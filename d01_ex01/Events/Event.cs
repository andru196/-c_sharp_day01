using d01_ex01.Tasks;
using System;

namespace d01_ex01.Events
{
    public abstract record Event (TaskState State, DateTime DateTime);
}