using Mediator;

Console.Title = "Mediator";
TeamChatRoom teamChatRoom = new();

var tim = new Lawyer("Tim");
var kim = new Lawyer("Kim");

var sean = new AccountManager("Sean");
var jim = new AccountManager("Jim");
var abhi = new AccountManager("Abhi");

teamChatRoom.Register(tim);
teamChatRoom.Register(kim);
teamChatRoom.Register(sean);
teamChatRoom.Register(jim);
teamChatRoom.Register(abhi);

tim.Send("Hi");
kim.Send("OK");

// Send message to any individual
tim.Send("Kim", "Can we have a call?");

// Send message to any whole group
tim.SendTo<AccountManager>("Hello All");

Console.ReadLine();