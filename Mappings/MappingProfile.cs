using AutoMapper;
using comp306_group7_recipevault.Models;

namespace comp306_group7_recipevault.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<Recipe, RecipeDetailDTO>();
            CreateMap<Recipe, RecipeCreateDTO>();
            CreateMap<RecipeDTO, Recipe>();
            CreateMap<RecipeCreateDTO, Recipe>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CreateCategoryDTO>();
            CreateMap<Category, CategoryListDTO>();
            CreateMap<Category, CategoryDetailDTO>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
