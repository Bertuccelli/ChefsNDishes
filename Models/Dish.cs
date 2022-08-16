#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId{get;set;}


    [Required(ErrorMessage = "is required")]
    public string Name {get;set;}


    [Required(ErrorMessage = "is required")]
    public int ChefId {get;set;}
    public Chef? Creator {get;set;}


    [Required(ErrorMessage = "is required")]
    public string Tastiness {get;set;}


    [Required(ErrorMessage = "is required")]
    [Range(1,9999)]
    public string Calories {get;set;}


    [Required(ErrorMessage = "is required")]
    public string Description {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}