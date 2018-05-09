using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command
{
    // 教官，负责调用命令对象执行请求
    public class Invokee
    {
        public Command _command;

        public Invokee(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

    // 命令抽象类
    public abstract class Command
    {
        // 命令应该知道接收者是谁，所以有Receiver这个成员变量
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        // 命令执行方法
        public abstract void Action();
    }

    // 
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        {
        }

        public override void Action()
        {
            // 调用接收的方法，因为执行命令的是学生
            _receiver.Run1000Meters();
        }
    }

    // 命令接收者——学生
    public class Receiver
    {
        public void Run1000Meters()
        {
            Console.WriteLine("跑1000米");
            Console.ReadKey();
        }
    }

    // 院领导
    class Program
    {
        static void Main(string[] args)
        {
            // 初始化Receiver、Invoke和Command
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invokee i = new Invokee(c);

            // 院领导发出命令
            i.ExecuteCommand();
        }
    }

    /*
    // 院领导
    class Program
    {
        static void Main(string[] args)
        {
            // 行为的请求者和行为的实现者之间呈现一种紧耦合关系
            Receiver r = new Receiver();

            r.Run1000Meters();
        }
    }
    public class Receiver
    {
        // 操作
        public void Run1000Meters()
        {
            Console.WriteLine("跑1000米");
            Console.ReadKey();
        }
    }*/

}
