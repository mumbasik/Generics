using System.ComponentModel;

namespace Generics
{


    class Employyers
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }

        

        public Employyers() { }

        public Employyers(string name, string state, int salary, string email)
        {
            this.Email = email;
            this.Name = name;
            this.State = state;
            this.Salary = salary;
            
        }
        public void Print()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("State: " + State);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Email: " + Email);
        }
        public void AddEmployyers(List<Employyers> list, Employyers emp)
        {
          list.Add(emp);
           
        }
        public void RemoveEmployyers(List<Employyers> list, Employyers emp)
        {
            list.Remove(emp);
        }
        public void ChangeInformation(List<Employyers> list, Employyers emp)
        {

            emp.Name = Convert.ToString(Console.ReadLine());
            emp.State = Convert.ToString(Console.ReadLine());
            emp.Email = Convert.ToString(Console.ReadLine());
            emp.Salary = Convert.ToInt32(Console.ReadLine());
            list.Add(emp);
           
        }
        public Employyers FindEmployer(List<Employyers> list, string name)
        {
            return list.FirstOrDefault(emp => emp.Name == name);
        }
    }


    class Menagment
    {
        Dictionary<string, string> workers = new Dictionary<string, string>() {

            {"Vanya227", "pass34242"}, {"xDima1000", "plusis342342"}, {"TolyanMir", "x9034XD"}
        
        };
        public void AddLogin(string username, string password)
        {
            workers.Add(username, password);
            Console.WriteLine($"Работник {username} был добавлен!");
        }
        public void DeleteLogin(string username, string password)
        {
            workers.Remove(username);
            if(username == null)
            {
                password = null;
            }
            Console.WriteLine($"Работник {username}, был добавлен в лист!");
        }
        public void ChangeInformation(string username, string password)
        {
           if(workers.ContainsKey(username))
            {
                username = Console.ReadLine();
                password = Console.ReadLine();
                workers.Add(username, password);
            }
           Console.WriteLine($"Новая информация. Логин: {username}, Пароль: {password}");
        }
        public void GetInfo(string username, string password)
        {
            if( workers.ContainsKey(username)) {
                Console.WriteLine("Пароль: " + password);
            }
        }
        public void Print()
        {
            foreach(var worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }
        }

    }
    //N3
    public class Visitor
    {
        public string Name { get; set; }
        public bool HasReservation { get; set; }

        public Visitor(string name, bool hasReservation)
        {
            Name = name;
            HasReservation = hasReservation;
        }

        public override string ToString()
        {
            return Name + (HasReservation ? " (with reservation)" : "");
        }
    }

    public class Cafe
    {
        private Queue<Visitor> queue = new Queue<Visitor>();
        private List<Visitor> reservedVisitors = new List<Visitor>();
        private int totalTables;
        private int availableTables;

        public Cafe(int tables)
        {
            totalTables = tables;
            availableTables = tables;
        }

      
        public void AddVisitor(Visitor visitor)
        {
            if (visitor.HasReservation)
            {
                reservedVisitors.Add(visitor);
                Console.WriteLine($"{visitor.Name} пришел с резервом.");
            }
            else
            {
                queue.Enqueue(visitor);
                Console.WriteLine($"{visitor.Name} встал в очередь.");
            }

            ProcessQueue();
        }

        public void FreeTable()
        {
            availableTables++;
            Console.WriteLine($"Освобожден столик. Свободных столиков: {availableTables}.");
            ProcessQueue();
        }


        private void ProcessQueue()
        {
            
            while (availableTables > 0 && (reservedVisitors.Count > 0 || queue.Count > 0))
            {
                if (reservedVisitors.Count > 0)
                {
                    
                    var reservedVisitor = reservedVisitors[0];
                    reservedVisitors.RemoveAt(0);
                    availableTables--;
                    Console.WriteLine($"{reservedVisitor.Name} получил зарезервированный столик.");
                }
                else if (queue.Count > 0)
                {
                    
                    var visitor = queue.Dequeue();
                    availableTables--;
                    Console.WriteLine($"{visitor.Name} занял столик.");
                }
            }
        }
    }


    internal class Program
    {

       
        static void Main(string[] args)
        {
            List<Employyers> employyers = new List<Employyers>();
            Employyers emp = new Employyers();

            Employyers employerObj = new Employyers("Vanya", "Manager", 0, "3424242342423");


            emp.AddEmployyers(employyers, employerObj);
            foreach (var val in employyers)
            {
                val.Print();

            }

            var foundEmployer = emp.FindEmployer(employyers, "Vanya");
            if (foundEmployer != null)
            {
                Console.WriteLine("Found Employer:");
                foundEmployer.Print();
            }
            else
            {
                Console.WriteLine("Employer not found.");
            }


            emp.RemoveEmployyers(employyers, employerObj);
            foreach (var val in employyers)
            {
                val.Print();

            }
            //N2
            Menagment ob = new Menagment();
            ob.AddLogin("Andrey3241", "Passwor43242");
            ob.DeleteLogin("xDima1000", "plusis342342");
            ob.GetInfo("Vanya227", "pass34242");
            ob.ChangeInformation("TolyanMir", "x9034XD");
            ob.Print();
            //N3
            Cafe cafe = new Cafe(3);

           
            cafe.AddVisitor(new Visitor("Иван", false));
            cafe.AddVisitor(new Visitor("Ольга", true)); 
            cafe.AddVisitor(new Visitor("Алексей", false));
            cafe.AddVisitor(new Visitor("Марина", false));

           
            cafe.FreeTable();
            cafe.FreeTable();

           
            cafe.AddVisitor(new Visitor("Анна", true));

           
            cafe.FreeTable();

        }
    }
}
