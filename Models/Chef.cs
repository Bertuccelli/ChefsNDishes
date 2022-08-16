#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get;set;}


    [Required(ErrorMessage = "is required")]
    public string FirstName {get;set;}


    [Required(ErrorMessage = "is required")]
    public string LastName {get;set;}


    [Required(ErrorMessage = "is required")]
    public DateOnly DOB {get;set;}


    [Required(ErrorMessage = "is required")]
    public DateTime Created_At {get;set;} = DateTime.Now;


    [Required(ErrorMessage = "is required")]
    public DateTime Updated_At {get;set;} = DateTime.Now;

    public List<Dish> CreatedDishes {get;set;}

    public string FullName()
    {
        return FirstName + " " + LastName;
    }
    [NotMapped]
    public int Age {get;set;}
}