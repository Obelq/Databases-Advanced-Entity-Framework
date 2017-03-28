namespace SimpleAndAdvancedMapping
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"\n    - {FirstName} {LastName} {Salary:F2}";
        }
    }
}
