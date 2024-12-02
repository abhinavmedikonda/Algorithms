using System.Collections.Generic;
using System.Linq;
using System;


namespace Algorithms.Assessments;

class EventManagementSystem
{

    interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    interface IEventInfo
    {
        public string EventName { get; set; }
        public DateOnly EventDate { get; set; }
        public int Capacity { get; set; }
        public bool Canceled { get; set; }
        public List<IPerson> Registrations { get; set; }
        public List<IPerson> Attendees { get; set; }
        void Register(IPerson person);
        void Attend(IPerson person);

    }
    interface IEventManager
    {
        public List<IEventInfo> Events { get; set; }
        void AddEvent(IEventInfo eventInfo);
        void Register(string eventName, IPerson person);
        void Attend(string eventName, IPerson person);
        List<string> GetEventCountByYears();
        List<string> GetEventRegistrationCountByYears();
        List<string> GetEventAttendeesCountByYears();
    }

    /*
    ** Create Person, EventInfo and EventManager classes
    */

    class Person: IPerson{
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public Person(string firstName, string lastName){
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }

    class EventInfo: IEventInfo{
        public string EventName { get; set; }
        public DateOnly EventDate { get; set; }
        public int Capacity { get; set; }
        public bool Canceled { get; set; }
        public List<IPerson> Registrations { get; set; }
        public List<IPerson> Attendees { get; set; }
        public void Register(IPerson person){
            if(!Canceled &&
                Registrations.Count<Capacity &&
                !Registrations.Any(x => x.FirstName.Equals(person.FirstName) && x.LastName.Equals(person.LastName)))
            {
                this.Registrations.Add(person);
            }
        }
        public void Attend(IPerson person){
            if(!Canceled &&
            Registrations.Any(x => x.FirstName.Equals(person.FirstName) && x.LastName.Equals(person.LastName)) &&
            !Attendees.Any(x => x.FirstName.Equals(person.FirstName) && x.LastName.Equals(person.LastName)))
            {
                this.Attendees.Add(person);
            }
        }
        
        public EventInfo(string eventName, DateOnly eventDate, int capacity, Boolean canceled){
            this.EventName = eventName;
            this.EventDate = eventDate;
            this.Capacity = capacity;
            this.Canceled = canceled;
            
            this.Registrations = new List<IPerson>();
            this.Attendees = new List<IPerson>();
        }
    }

    class EventManager: IEventManager{
        public List<IEventInfo> Events { get; set; }
        public void AddEvent(IEventInfo eventInfo){
            if(!Events.Any(x => x.EventName.Equals(eventInfo.EventName))){
                Events.Add(eventInfo);
            }
        }
        public void Register(string eventName, IPerson person){
            if(Events.Any(x => x.EventName.Equals(eventName))){
                Events.First(x => x.EventName.Equals(eventName)).Register(person);
            }
        }
        public void Attend(string eventName, IPerson person){
            if(Events.Any(x => x.EventName.Equals(eventName))){
                Events.First(x => x.EventName.Equals(eventName)).Attend(person);
            }
        }
        public List<string> GetEventCountByYears(){
            var response = Events.GroupBy(x => x.EventDate.Year).Select(group => new { Key = group.Key, Count = group.Count()}).OrderBy(x => x.Key);
            
            var returns = new List<string>();
            
            foreach(var item in response){
                returns.Add($"Year:{item.Key}, Count:{item.Count}");
            }
            
            return returns;
        }
        public List<string> GetEventRegistrationCountByYears(){
            var response = Events.GroupBy(x => x.EventDate.Year).Select(group => new{ Key = group.Key, Count = group.Sum(x => x.Registrations.Count)});
            
            var returns = new List<string>();

            foreach (var item in response)
            {
                returns.Add($"Year:{item.Key}, Event Registrations:{item.Count}");
            }

            return returns;
        }
        public List<string> GetEventAttendeesCountByYears(){
            var response = Events.GroupBy(x => x.EventDate.Year).Select(group => new{ Key = group.Key, Count = group.Sum(x => x.Attendees.Count)});
            
            var returns = new List<string>();

            foreach (var item in response)
            {
                returns.Add($"Year:{item.Key}, Event Attendees:{item.Count}");
            }

            return returns;
        }
        
        public EventManager(){
            this.Events = new List<IEventInfo>();
        }
    }

/*
3
ab hi
na vv
me di
3
one 2024-11-2 5 0
two 2023-11-4 5 0
three 2024-11-8 5 0
3
1 0 0
2 1 1
1 2 2
*/

    // public static void Main(string[] args)
    // {
    //     List<IPerson> persons = new List<IPerson>();
    //     List<IEventInfo> events = new List<IEventInfo>();
    //     EventManager evtM = new EventManager();
        
    //     int n = Convert.ToInt32(Console.ReadLine().Trim());
    //     for (int i = 1; i <= n; i++)
    //     {
    //         var a = Console.ReadLine().Trim().Split(" ");
    //         persons.Add(new Person(a[0], a[1]));
    //     }
        
    //     int m = Convert.ToInt32(Console.ReadLine().Trim());
    //     for (int i = 1; i <= m; i++)
    //     {
    //         var a = Console.ReadLine().Trim().Split(" ");
    //         events.Add(new EventInfo(a[0],
    //                     new DateOnly(Convert.ToInt32(a[1].Split('-')[0]), Convert.ToInt32(a[1].Split('-')[1]), Convert.ToInt32(a[1].Split('-')[2])),
    //                     Convert.ToInt32(a[2]),
    //                     a[3] == "1" ? true : false));
    //     }
        
    //     foreach (var item in events)
    //     {
    //         evtM.AddEvent(item);
    //     }
        
    //     int p = Convert.ToInt32(Console.ReadLine().Trim());
    //     for (int i = 1; i <= p; i++)
    //     {
    //         var a = Console.ReadLine().Trim().Split(" ");
    //         if(a[0]=="1"){
    //             evtM.Register(events[Convert.ToInt32(a[2])].EventName, persons[Convert.ToInt32(a[1])]);
    //         }else if(a[0] =="2"){
    //             evtM.Attend(events[Convert.ToInt32(a[2])].EventName, persons[Convert.ToInt32(a[1])]);
    //         }
    //     }
    //     var yy = evtM.GetEventCountByYears();
    //     var b = evtM.GetEventRegistrationCountByYears();
    //     var c = evtM.GetEventAttendeesCountByYears();
    //     Console.WriteLine("Event Count:");
    //     foreach (var item in yy)
    //     {
    //         Console.WriteLine(item);
    //     }
    //     Console.WriteLine("Registrations:");
    //     foreach (var item in b)
    //     {
    //         Console.WriteLine(item);
    //     }
    //     Console.WriteLine("Attendees:");
    //     foreach (var item in c)
    //     {
    //         Console.WriteLine(item);
    //     }
    // }

}
