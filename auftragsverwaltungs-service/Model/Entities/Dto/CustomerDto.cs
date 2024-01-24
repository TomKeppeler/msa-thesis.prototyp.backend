namespace auftragsverwaltung_service.Model.Entities.Dto;

public class CustomerDto : BaseDto
{
    private string Name { get; set; }
    private string Street { get; set; }
    private string Zip { get; set; }
    private string City { get; set; }
    private string Country { get; set; }
    private string Phone { get; set; }
    private string Email { get; set; }
    private string Website { get; set; }
    private string BankName { get; set; }
    private string BankIban { get; set; }
    private string BankBic { get; set; }
    private string Note { get; set; }
}