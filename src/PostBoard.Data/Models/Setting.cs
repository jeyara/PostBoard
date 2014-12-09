using PostBoard.Data.Repository;

namespace PostBoard.Data.Models
{
    public partial class Setting : BaseEntity
    {
        public Setting() { }

        public Setting(string name, string value, string description = "")
        {
            this.Name = name;
            this.Value = value;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
