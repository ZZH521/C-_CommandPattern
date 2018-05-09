using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command2
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化接收者和具体的命令
            Receiver r = new Receiver();
            Command a = new ConcreteCommandBakeMutton(r);
            Command c = new ConcreteCommandBakeChickenWing(r);
            //Command b = new ConcreteCommandBakeChickenWing(r);
            //实例化发出者
            Invoker i = new Invoker();
            //通过记录命令和执行命令来完成请求
            i.SetCommand(c);
            i.ExecuteCommand();

           // i.SetCommand(b);
           // i.ExecuteCommand();

            i.SetCommand(a);
            i.ExecuteCommand();
            Console.Read();


        }
    }
    class Invoker
    {
        private Command command;
        //接收记录菜单
        public void SetCommand(Command command)
        {
            this.command = command;
        }
        //执行命令
        public void ExecuteCommand()
        {
            command.Execute();
        }
        //这里可以通过取消命令的方法实现撤销类似的功能！
    }
    
    //抽象的Command，用来让子类继承并实现里面具体的方法
    abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        //抽象的方法
        abstract public void Execute();
    }
    
    class ConcreteCommandBakeChickenWing :Command
    {
        //继承父类来实例化执行者类
        public ConcreteCommandBakeChickenWing(Receiver receiver)
            : base(receiver)
        { }
        //执行者执行和此命令有关的方法，这样就实现了把行为封装成对象的作用
        public override void Execute()
        {
            receiver.BakeChickenWing();
            //receiver.BakeMutton();
        }
        //同样可以封装多个方法，这样可以实现一组命令，实现宏命令！

    }
    class ConcreteCommandBakeMutton : Command
    {
        //继承父类来实例化执行者类
        public ConcreteCommandBakeMutton(Receiver receiver)
            : base(receiver)
        { }
        //执行者执行和此命令有关的方法，这样就实现了把行为封装成对象的作用
        public override void Execute()
        {
            //receiver.BakeChickenWing();
            receiver.BakeMutton();
        }
        //同样可以封装多个方法，这样可以实现一组命令，实现宏命令！

    }


    //执行者类
    class Receiver
    {
        //执行烤串的方法
        public void BakeMutton()
        {
            Console.WriteLine("吃烤串！哪吒请！");
        }
       // 执行烤鸡翅的方法
        public void BakeChickenWing()
        {
            Console.WriteLine("吃烤鸡翅！金吒请！");
        }
    }
}






