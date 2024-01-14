using FinalHomework;

internal class Program
{
    private static void Main(string[] args)
    {
        Elevator elevator = new Elevator();

        Agent agent1 = new Agent(SecurityLevel.Confidental, elevator);
        Agent agent2 = new Agent(SecurityLevel.Secret, elevator);
        Agent agent3 = new Agent(SecurityLevel.TopSecret, elevator);

        Thread agentThread1 = new Thread(agent1.MoveAround);
        Thread agentThread2 = new Thread(agent2.MoveAround);
        Thread agentThread3 = new Thread(agent3.MoveAround);
      
        agentThread1.Start();
        agentThread2.Start();
        agentThread3.Start();
      
        agentThread1.Join();
        agentThread2.Join();
        agentThread3.Join();

    }
}