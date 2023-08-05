
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

public class DbNode // TODO
{
    public Guid Id { get; set; }

    [ForeignKey(nameof(DbNode))]
    public Guid ParentId { get; set; }
    public string Category { get; set; }
    public string Name { get; set; }

}
