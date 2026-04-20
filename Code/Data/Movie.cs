using Abc.Data.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.Data;

[Table("Movie")]
public class Movie : NamedEntity
{
    [DisplayName("Title")]
    public string Title
    {
        get => Name;
        set => Name = value;
    }

    [DisplayName("ReleaseDate")]
    public DateTime? ReleaseDate
    {
        get => ValidFrom;
        set => ValidFrom = value;
    }

    public string Genre { get; set; }

    [DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public Money Money { get; set; }
    public Country Country { get; set; }
}