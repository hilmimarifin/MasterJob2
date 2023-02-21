namespace MasterJob.DTO
{
    public class EmployeeDTO
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? JobPositionId { get; set; }

        public string? JobTitleId { get; set; }

        public string? Address { get; set; }

        public string Nik { get; set; } = null!;
    }

    public class EmployeeEditDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Nik { get; set; } = null!;
        public string? JobPositionId { get; set; }

        public string? JobTitleId { get; set; }

        public string? Address { get; set; }

    }

    public class EmployeeCreateDTO
    {

        public string Name { get; set; } = null!;

        public string? JobTitleId { get; set; }

        public string? JobPositionId { get; set; }

        public string? Address { get; set; }

        public string Nik { get; set; } = null!;

    }

    public class EmployeeDeleteDTO
    {
        public string Id { get; set; } = null!;
    }
}
