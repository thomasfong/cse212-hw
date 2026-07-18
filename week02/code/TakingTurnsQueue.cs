using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> _queue = new Queue<Person>();

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _queue.Enqueue(person);
    }

    public string GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        Person person = _queue.Dequeue();

    
        if (person.Turns <= 0)
        {
            _queue.Enqueue(person);     
        }
        else
        {
            person.Turns--;              
            if (person.Turns > 0)
            {
                _queue.Enqueue(person); 
            
        }

        return person.Name;
    }

    private class Person
    {
        public string Name { get; set; }
        public int Turns { get; set; }

        public Person(string name, int turns)
        {
            Name = name;
            Turns = turns;
        }
    }
}