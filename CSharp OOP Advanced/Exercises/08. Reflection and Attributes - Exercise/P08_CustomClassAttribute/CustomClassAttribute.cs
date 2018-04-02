namespace CustomClassAttribute
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class CustomClassAttribute : Attribute
    {
        public CustomClassAttribute(string author, int revision, string description, params string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }

        public string Author { get; }
        public int Revision { get; }
        public string Description { get; }
        public string[] Reviewers { get; }
    }
}
