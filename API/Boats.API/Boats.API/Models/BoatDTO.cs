using System.ComponentModel.DataAnnotations;

namespace Boats.API.Models
{
    public class CreateBoatDTO
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string JobDesciption { get; set; }
        public string Date { get; set; }
        [Required]
        public float Amount { get; set; }

    }
<<<<<<< HEAD
    public class UpdateBoatDTO : CreateBoatDTO
    {
        // can take away the inheritance and only expose fields that we want to update
        //such as
        /*
        [Required]
        public string Name { get; set; }
        [Required]
        public string County { get; set; }
        */
=======

    public class UpdateBoatDTO : CreateBoatDTO
    {
>>>>>>> 533f506a695c57c112b91f00ac997b6f782a8e57

    }
    public class BoatDTO : CreateBoatDTO
    {
        [Required]
        public Guid Id { get; set; }
        
    }

}
