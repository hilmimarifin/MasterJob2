namespace MasterJob.DTO
{
    public class JobTitleDTO
    {
        public string Id { get; set; } = null!;

        public string? Code { get; set; } = null!;

        public string Name { get; set; } = null!;
    }

    public class JobTitleEditDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class JobTitleCreateDTO
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;
    }

    public class JobTitleDeleteDTO
    {
        public string Id { get; set; } = null!;
    }
}
