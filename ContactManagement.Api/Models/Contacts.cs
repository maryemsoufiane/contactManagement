namespace ContactManagement.Api.Models{
  public class Contacts{
    public int Id { get; set; }
    public string FirstName { get; set; }=string.Empty;
    public string LastName { get; set; }=string.Empty;
    public string Email { get; set; }=string.Empty;
    public string PhoneNumber { get; set; }=string.Empty;
    public DateTime CreatedAt { get; set; }

}
}

