using auftragsverwaltungs_service.Model.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace auftragsverwaltungs_service.Model.Entities;

public class Customer : BaseEntity
{
    [MaxLength(50)]
    private string Name { get; set; }
    [MaxLength(100)]
    private string Street { get; set; }
    [MaxLength(100)]
    private string Zip { get; set; }
    [MaxLength(100)]
    private string City { get; set; }
    [MaxLength(100)]
    private string Country { get; set; }
    [MaxLength(50)]
    private string Phone { get; set; }
    [MaxLength(100)]
    private string Email { get; set; }
    private string Website { get; set; }
    [MaxLength(80)]
    private string BankName { get; set; }
    [MaxLength(34)]
    private string BankIban { get; set; }
    [MaxLength(8)]
    private string BankBic { get; set; }
    [MaxLength(250)]
    private string Note { get; set; }
}