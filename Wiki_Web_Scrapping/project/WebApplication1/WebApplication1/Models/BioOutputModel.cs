namespace WebApplication1.Models
{
    public class BioOutputModel
    {
        public string Name { get; set; }

        public string? Born { get; set; }

        public string? AlmaMatter { get; set; }

        //public string? Occupation { get; set; }
        public List<String>? Occupations{ get; set; }
        
        //public int? ChildrenCount { get; set; }

        public string? ChildrenCount { get; set; }

        public string? Spouse { get; set; }

        public string? Parents { get; set; }

        public string? Family { get; set; }


        //public List<Spouse>? Spouses { get; set; }

        //public List<Parent>? Parents { get; set; }


    }

    //public class Spouse
    //{
    //    public string Name { get; set; }
    //    public int MarriedYear { get; set; }
    //    public int? DivorcedYear { get; set; }
    //}

    //public class Parent
    //{
    //    public string Name { get; set; }
    //}

}
