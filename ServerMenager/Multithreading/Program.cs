//Multithreading (eager)

public class Servers
{
    private static Servers instance = new Servers();
    private List<string> servers;
    private List<string> permittedProtocol = ["http:", "https"];

    private Servers()
    {
        servers = new List<string>();
    }

    public static Servers Instance
    {
        get
        {
            return instance;
        }
    }

    public bool AddServer(string server)
    {

        if (servers.Contains(server))
        {
            return false;
        }
        foreach (string protocol in permittedProtocol)
        {

            if (server.StartsWith(protocol))
            {
                servers.Add(server);
                return true;
            }
        }
        return false;
    }

    public List<string> GetHttpServers()
    {
        return servers.Where(s => s.StartsWith("http:")).ToList();
    }

    public List<string> GetHttpsServers()
    {
        return servers.Where(s => s.StartsWith("https")).ToList();
    }
}



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("https://www.google.comadd add " + Servers.Instance.AddServer("https://www.google.com"));
        Console.WriteLine("http://www.example.com add " + Servers.Instance.AddServer("http://www.example.com"));
        Console.WriteLine("http://www.example.com add " + Servers.Instance.AddServer("http://www.example.com"));
        Console.WriteLine("http://www.example3.com add " + Servers.Instance.AddServer("http://www.example3.com"));
        Console.WriteLine("ftp://www.example.org add " + Servers.Instance.AddServer("ftp://www.example.org"));
        Console.WriteLine();

        Console.WriteLine("HTTP Servers:");
        foreach (var server in Servers.Instance.GetHttpServers())
            Console.WriteLine(server);

        Console.WriteLine("\nHTTPS Servers:");
        foreach (var server in Servers.Instance.GetHttpsServers())
            Console.WriteLine(server);
    }
}
