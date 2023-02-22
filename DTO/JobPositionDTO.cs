namespace MasterJob.DTO
{
    public class JobPositionDTO
    {
        public string Id { get; set; } = null!;

        public string? Code { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? TitleId { get; set; }

        public string? TitleName { get; set; }

    }

    public class JobPositionEditDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? TitleId { get; set; }

    }

    public class JobPositionCreateDTO
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;
        public string? TitleId { get; set; }

    }

    public class JobPositionDeleteDTO
    {
        public string Id { get; set; } = null!;

    }
}
