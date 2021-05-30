using System;
using System.Collections.Generic;
using d01_ex01.Tasks;
using d01_ex01.Events;

Task AddNewTask()
{
    Console.WriteLine("Введите заголовок");
    var title = Console.ReadLine();
    Console.WriteLine("Введите описание");
    var summary = Console.ReadLine();
    Console.WriteLine("Введите срок");
    var dueDate = Console.ReadLine();
    Console.WriteLine("Введите тип");
    var type = Console.ReadLine();
    Console.WriteLine("Установите приоритет");
    var prioruty = Console.ReadLine();

    if (!string.IsNullOrEmpty(title) && Enum.TryParse<TaskType>(type, out var rlType))
    {
        if (!Enum.TryParse<TaskPriority>(prioruty, out var rlPriority))
            rlPriority = TaskPriority.Middle;
        DateTime.TryParse(dueDate, out var realDue);
        return new Task()
        {
            Priority = rlPriority,
            Summary = summary,
            Title = title,
            Type = rlType
        };
    }
    return null;
}

void ShowList(List<Task> list)
{
    if (list.Count == 0)
        Console.WriteLine("Список задач пока пуст.");
    else foreach (var task in list)
        Console.WriteLine(task.ToString());
}

void EditTask(List<Task> list, TaskState state)
{
    Console.WriteLine("Введите заголовок");
    var name = Console.ReadLine();
    var find = false;
    foreach (var task in list)
    {
        if (task.Title == name)
        {
            find = true;
            if (task.CanSetState(state))
            {
                if (state == TaskState.Complited)
                    task.EventsList.Add(new TaskDoneEvent(state, DateTime.Now));
                else
                    task.EventsList.Add(new TaskWontDoEvent(state, DateTime.Now));
            }
            else
                Console.WriteLine("Невозможно выставить новый статус");
        }
    }
    if (!find)
        Console.WriteLine("Ошибка ввода. Задача с таким заголовком не найдена.");
}

var quit = true;

var tasks = new List<Task>();

while (quit)
{
    Console.WriteLine("Your command");
    var answer = Console.ReadLine();
    if (answer == "quit" || answer == "q")
        quit = false;
    else if (answer == "add")
    {
        var newTask = AddNewTask();
        if (newTask == null)
            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
        else
            tasks.Add(newTask);
    }
    else if (answer == "list")
        ShowList(tasks);
    else if (answer == "done")
        EditTask(tasks, TaskState.Complited);
    else if (answer == "wontdo")
        EditTask(tasks, TaskState.NotActual);
    else if (answer == "help")
        Console.WriteLine($"Commands: list done wontdo quit");
    else
        Console.WriteLine("Unidentified command! Try again");
}