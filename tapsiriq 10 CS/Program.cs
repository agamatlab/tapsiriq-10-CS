
class DocumentFactory
{
    public static DocumentProgram CreateDocument(String type)
    {
        return type switch
        {
            "ProDocumentProgram" => new ProDocumentProgram(),
            "Expert Document" => new ExpertDocument(),
            _ => new DocumentProgram()
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
    enum Types { ProDocumentProgram, ExpertDocument };
    static void Main(string[] args)
    {
        DocumentProgram dc = DocumentFactory.CreateDocument(Types.ProDocumentProgram.ToString());
        dc.SaveDocument();
        
        
    }
}