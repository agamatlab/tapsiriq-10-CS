using System.Text;
using UIElements;

class DocumentFactory
{
    public static DocumentProgram? CreateDocument(String type)
    {
        return type switch
        {
            "ProDocumentProgram" => new ProDocumentProgram(),
            "ExpertDocument" => new ExpertDocument(),
            "DocumentProgram" => new DocumentProgram(),
            _ => null
        };
    }
}

class DocumentProgram
{
    public void OpenDocument() => Console.WriteLine("Document Openned");
    public virtual void EditDocument() => Console.WriteLine("Can Edit in Pro and Expert versions");
    public virtual void SaveDocument() => Console.WriteLine("Can Save in Pro and Expert versions");
}

class ProDocumentProgram : DocumentProgram
{
    public sealed override void EditDocument()  => Console.WriteLine("Document Edited");
    public sealed override void SaveDocument()  => Console.WriteLine("Document Saved in doc format, for pdf format buy Expert packet");
}

class ExpertDocument : DocumentProgram
{
    public sealed override void EditDocument() => Console.WriteLine("Document Edited");
    public sealed override void SaveDocument() => Console.WriteLine("Document Saved in pdf format");
}

class Program
{
    static void Main(string[] args)
    {
        UI.ChangeEncoding(Encoding.Unicode, Encoding.Unicode);
        var answers = new string[] { "Pro Document Program", "Expert Document", "Document Program" };

        while (true)
        {
            sbyte choice = (sbyte)UI.GetChoice("Do you want to create:", answers, true);
            if (choice == -1) break;

            DocumentProgram? dc = DocumentFactory.CreateDocument(answers[choice].Replace(" ", String.Empty));

            dc.SaveDocument();
            dc.EditDocument();
            dc.OpenDocument();

            Console.ReadKey();
        }
    }
}