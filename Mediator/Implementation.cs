namespace Mediator
{
    /// <summary>
    /// Mediator
    /// </summary>
    public interface IChatRoom
    {
        void Register(TeamMember teammeber);
        void Send(string from, string message);
        void SendTo<T>(string from, string message) where T : TeamMember;
        void Send(string from, string to, string message);
    }
    /// <summary>
    /// Colleague
    /// </summary>
    public abstract class TeamMember
    {
        private IChatRoom? _chatRoom;
        public string Name { get; set; }

        public TeamMember(string name)
        {
            Name = name;
        }

        internal void SetChatRoom(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public void Send(string message)
        {
            _chatRoom?.Send(Name, message);
        }

        public void Send(string to, string message)
        {
            _chatRoom?.Send(Name, to, message);
        }

        public void SendTo<T>(string message) where T:TeamMember
        {
            _chatRoom?.SendTo<T>(Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"Message {from} to {Name}:{message}");
        }
    }
    /// <summary>
    /// Concerete Colleague
    /// </summary>
    public class Lawyer: TeamMember
    {
        public Lawyer(string name):base(name)
        {

        }
        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(Lawyer)} {Name} received:");
            base.Receive(from, message);
        }

    }

    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name)
        {

        }
        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)} {Name} received:");
            base.Receive(from, message);
        }

    }

    /// <summary>
    /// Concerete Mediator
    /// </summary>
    public class TeamChatRoom : IChatRoom
    {
        private readonly Dictionary<string, TeamMember > teamMembers = new();
        public void Register(TeamMember teammeber)
        {
            teammeber.SetChatRoom(this);
            if (!teamMembers.ContainsKey(teammeber.Name))
            {
                teamMembers.Add(teammeber.Name, teammeber);
            }
        }

        public void Send(string from, string message)
        {
            foreach (var item in teamMembers.Values)
            {
                item.Receive(from, message);
            }
        }

        public void Send(string from, string to, string message)
        {
            var teammember = teamMembers[to];
            teammember.Receive(from, message);
        }

        public void SendTo<T>(string from, string message) where T : TeamMember
        {
            foreach (var teamMember in teamMembers.Values.OfType<T>())
            {
                teamMember.Send(from, message);
            }
        }
    }
}

/*
 Here IChatRoom is the Mediator which defines the interface for communicating with the colleague objects
 TeamMember is the collegaue which has mediator reference
 */