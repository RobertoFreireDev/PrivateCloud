namespace API.db.Entities;

public class FileEntity : BaseEntity
{
    public string Name { get; set; }

    public string Base64 { get; set; }

    public string ContentType { get; set; }   
}