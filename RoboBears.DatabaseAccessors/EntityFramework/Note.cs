namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class Note
    {
        public int NoteId { get; set; }

        public int DescriptionId { get; set; }

        public virtual Description Description { get; set; }

        public string Body { get; set; }
    }
}