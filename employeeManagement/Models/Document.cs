namespace employeeManagement.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
