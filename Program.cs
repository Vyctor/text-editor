namespace TextEditor
{
  class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }

    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("1 - Abrir um arquivo");
      Console.WriteLine("2 - Criar um novo arquivo");
      Console.WriteLine("0 - Sair");

      short option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 0:
          Environment.Exit(0);
          break;
        case 1:
          OpenFile();
          break;
        case 2:
          EditFile();
          break;
        default:
          Console.WriteLine("Opção inválida");
          Menu();
          break;
      }
    }

    static void OpenFile()
    {
      Console.Clear();
      Console.WriteLine("Digite o caminho do arquivo");
      var path = Console.ReadLine();

      if (path == null)
      {
        throw new Exception("Caminho inválido");
      }
      using (var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
      }
      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }

    static void EditFile()
    {
      Console.Clear();
      Console.WriteLine("Digite seu texto abaixo: (ESC para sair) ");
      Console.WriteLine("==========================================================");

      string text = "";

      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);

      if (text == null)
      {
        throw new Exception("Não foi possível salvar o arquivo");
      }

      Save(text);
    }

    static void Save(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual caminho para salvar o arquivo?");
      var path = Console.ReadLine();

      if (path == null)
      {
        throw new Exception("Não foi possível salvar o arquivo");
      }

      using (var file = new StreamWriter(path))
      {
        file.WriteLine(text);
      }

      Console.WriteLine($"Arquivo {path} salvo com sucesso!");
    }
  }
}