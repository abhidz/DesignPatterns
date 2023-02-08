namespace Decorator
{
    ///<summary>
    ///Component (as interface)
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }

    ///<summary>
    ///Concrete Component
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"{message} send via {nameof(CloudMailService)}");
            return true;
        }
    }
    public class OnpremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"{message} send via {nameof(OnpremiseMailService)}");
            return true;
        }
    }

    ///<summary>
    ///Decorator
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;
        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }
        public virtual bool SendMail(string message)
        {
           return _mailService.SendMail(message);
        }
    }

    ///<summary>
    ///Conceret Decorator
    /// </summary>
    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
            return base.SendMail(message);
        }
    }

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> SendMessages { get; private set; } = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            if (base.SendMail(message))
            {
                SendMessages.Add(message);
                return true;
            }
            return false;
        }
    }
}

// Here IMailService is the main componenet and we want to add statistics and MessageDatabase functionality init
// But if we add it in MailService it will break Single responsibilty principle
// Hence, we design an abstarct decorator and implement this on other 2 classes which will add extra behavior
// in the main class separately
